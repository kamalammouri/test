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
                
                // Initial Load
                ChargerListeEmployes();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Statut: Erreur de connexion";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        //  EMPLOYES
        // ==========================================

        private void ChargerListeEmployes()
        {
            try
            {
                List<Employe> employes = serviceProxy.ListerTousEmployes();
                dgvEmployes.DataSource = null;
                dgvEmployes.DataSource = employes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur listing employes : {ex.Message}");
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
                if (string.IsNullOrWhiteSpace(txtCin.Text) || string.IsNullOrWhiteSpace(txtNom.Text))
                {
                    MessageBox.Show("Champs CIN et Nom requis.");
                    return;
                }

                Employe emp = new Employe
                {
                    Cin = txtCin.Text.Trim(),
                    Nom = txtNom.Text.Trim(),
                    Taux = double.Parse(txtTaux.Text),
                    NbrHeure = int.Parse(txtHeures.Text)
                };

                if (serviceProxy.AjouterEmploye(emp))
                {
                    MessageBox.Show("Employe ajoute!");
                    ViderChampsEmploye();
                    ChargerListeEmployes();
                }
                else
                {
                    MessageBox.Show("Erreur (CIN duplique?)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                Employe emp = new Employe
                {
                    Cin = txtCin.Text.Trim(),
                    Nom = txtNom.Text.Trim(),
                    Taux = double.Parse(txtTaux.Text),
                    NbrHeure = int.Parse(txtHeures.Text)
                };

                if (serviceProxy.ModifierEmploye(emp))
                {
                    MessageBox.Show("Employe modifie!");
                    ViderChampsEmploye();
                    ChargerListeEmployes();
                }
                else
                {
                    MessageBox.Show("Erreur modification");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirmer suppression?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (serviceProxy.SupprimerEmploye(txtCin.Text.Trim()))
                    {
                        MessageBox.Show("Supprime!");
                        ViderChampsEmploye();
                        ChargerListeEmployes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void ViderChampsEmploye()
        {
            txtCin.Text = ""; txtNom.Text = ""; txtTaux.Text = ""; txtHeures.Text = "";
        }

        // ==========================================
        //  DEPARTEMENTS
        // ==========================================

        private void BtnListerDept_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDepartements.DataSource = null;
                dgvDepartements.DataSource = serviceProxy.ListerDepartements();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnAjouterDept_Click(object sender, EventArgs e)
        {
            try
            {
                Departement d = new Departement
                {
                    Nom = txtDeptNom.Text,
                    ChefCin = string.IsNullOrWhiteSpace(txtDeptChefCin.Text) ? null : txtDeptChefCin.Text
                };
                if (serviceProxy.AjouterDepartement(d))
                {
                    MessageBox.Show("Departement ajoute!");
                    txtDeptNom.Text = ""; txtDeptChefCin.Text = "";
                    BtnListerDept_Click(sender, e);
                }
                else MessageBox.Show("Erreur ajout Departement");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ==========================================
        //  PROJETS
        // ==========================================

        private void BtnListerProjet_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProjets.DataSource = null;
                dgvProjets.DataSource = serviceProxy.ListerProjets();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnAjouterProjet_Click(object sender, EventArgs e)
        {
            try
            {
                Projet p = new Projet
                {
                    Nom = txtProjetNom.Text,
                    Budget = double.Parse(txtProjetBudget.Text)
                };
                if (serviceProxy.AjouterProjet(p))
                {
                    MessageBox.Show("Projet ajoute!");
                    txtProjetNom.Text = ""; txtProjetBudget.Text = "";
                    BtnListerProjet_Click(sender, e);
                }
                else MessageBox.Show("Erreur ajout Projet");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ==========================================
        //  AFFECTATIONS
        // ==========================================

        private void BtnListerAff_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAffectations.DataSource = null;
                dgvAffectations.DataSource = serviceProxy.ListerAffectations();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnAjouterAff_Click(object sender, EventArgs e)
        {
            try
            {
                Affectation a = new Affectation
                {
                    EmployeCin = txtAffEmpCin.Text,
                    ProjetId = int.Parse(txtAffProjetId.Text),
                    Heures = int.Parse(txtAffHeures.Text)
                };
                if (serviceProxy.AjouterAffectation(a))
                {
                    MessageBox.Show("Affectation ajoutee!");
                    txtAffEmpCin.Text = ""; txtAffProjetId.Text = ""; txtAffHeures.Text = "";
                    BtnListerAff_Click(sender, e);
                }
                else MessageBox.Show("Erreur ajout Affectation");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
