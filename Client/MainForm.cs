using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;
using Common;

namespace Client
{
    public partial class MainForm : Form
    {
        private IRPC serviceProxy;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);

                serviceProxy = (IRPC)Activator.GetObject(
                    typeof(IRPC),
                    "tcp://localhost:1234/EmployeService"
                );

                lblStatus.Text = "Statut: Connecte au serveur";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                ChargerListeEmployes();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Statut: Erreur de connexion";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerListeEmployes()
        {
            try
            {
                List<Employe> employes = serviceProxy.ListerTousEmployes();
                dgvEmployes.DataSource = null;
                dgvEmployes.DataSource = employes;

                if (dgvEmployes.Columns.Count > 0)
                {
                    dgvEmployes.Columns["Cin"].HeaderText = "CIN";
                    dgvEmployes.Columns["Nom"].HeaderText = "Nom";
                    dgvEmployes.Columns["Taux"].HeaderText = "Taux Horaire";
                    dgvEmployes.Columns["NbrHeure"].HeaderText = "Nb Heures";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEmployes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployes.Rows[e.RowIndex];
                txtCin.Text = row.Cells["Cin"].Value?.ToString() ?? "";
                txtNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
                txtTaux.Text = row.Cells["Taux"].Value?.ToString() ?? "";
                txtHeures.Text = row.Cells["NbrHeure"].Value?.ToString() ?? "";
            }
        }

        private void BtnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCin.Text) || string.IsNullOrWhiteSpace(txtNom.Text) ||
                    string.IsNullOrWhiteSpace(txtTaux.Text) || string.IsNullOrWhiteSpace(txtHeures.Text))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Employe employe = new Employe
                {
                    Cin = txtCin.Text.Trim(),
                    Nom = txtNom.Text.Trim(),
                    Taux = double.Parse(txtTaux.Text),
                    NbrHeure = int.Parse(txtHeures.Text)
                };

                if (serviceProxy.AjouterEmploye(employe))
                {
                    MessageBox.Show("Employe ajoute!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViderChamps();
                    ChargerListeEmployes();
                }
                else
                {
                    MessageBox.Show("Echec (CIN existe deja?).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Valeurs numeriques invalides.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCin.Text))
                {
                    MessageBox.Show("Selectionnez un employe.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Employe employe = new Employe
                {
                    Cin = txtCin.Text.Trim(),
                    Nom = txtNom.Text.Trim(),
                    Taux = double.Parse(txtTaux.Text),
                    NbrHeure = int.Parse(txtHeures.Text)
                };

                if (serviceProxy.ModifierEmploye(employe))
                {
                    MessageBox.Show("Employe modifie!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViderChamps();
                    ChargerListeEmployes();
                }
                else
                {
                    MessageBox.Show("Echec de la modification.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCin.Text))
                {
                    MessageBox.Show("Selectionnez un employe.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Supprimer l'employe CIN: {txtCin.Text}?", "Confirmation", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (serviceProxy.SupprimerEmploye(txtCin.Text.Trim()))
                    {
                        MessageBox.Show("Employe supprime!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViderChamps();
                        ChargerListeEmployes();
                    }
                    else
                    {
                        MessageBox.Show("Echec de la suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViderChamps()
        {
            txtCin.Text = "";
            txtNom.Text = "";
            txtTaux.Text = "";
            txtHeures.Text = "";
        }
    }
}
