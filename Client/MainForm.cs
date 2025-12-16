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
        private TextBox txtCin;
        private TextBox txtNom;
        private TextBox txtTaux;
        private TextBox txtHeures;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Label lblStatus;
        private DataGridView dgvEmployes;

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Name = "MainForm";
            this.Text = "Gestion des Employes - Client";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += MainForm_Load;
            this.ResumeLayout(false);
        }

        private void InitializeUI()
        {
            // Titre
            Label lblTitre = new Label
            {
                Text = "GESTION DES EMPLOYES",
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(280, 15),
                AutoSize = true
            };
            this.Controls.Add(lblTitre);

            // GroupBox Saisie
            GroupBox grpSaisie = new GroupBox
            {
                Text = "Informations Employe",
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(380, 180)
            };
            this.Controls.Add(grpSaisie);

            // CIN
            grpSaisie.Controls.Add(new Label { Text = "CIN:", Location = new System.Drawing.Point(15, 30), AutoSize = true });
            txtCin = new TextBox { Location = new System.Drawing.Point(140, 27), Width = 200 };
            grpSaisie.Controls.Add(txtCin);

            // Nom
            grpSaisie.Controls.Add(new Label { Text = "Nom:", Location = new System.Drawing.Point(15, 65), AutoSize = true });
            txtNom = new TextBox { Location = new System.Drawing.Point(140, 62), Width = 200 };
            grpSaisie.Controls.Add(txtNom);

            // Taux
            grpSaisie.Controls.Add(new Label { Text = "Taux Horaire:", Location = new System.Drawing.Point(15, 100), AutoSize = true });
            txtTaux = new TextBox { Location = new System.Drawing.Point(140, 97), Width = 200 };
            grpSaisie.Controls.Add(txtTaux);

            // Heures
            grpSaisie.Controls.Add(new Label { Text = "Nombre Heures:", Location = new System.Drawing.Point(15, 135), AutoSize = true });
            txtHeures = new TextBox { Location = new System.Drawing.Point(140, 132), Width = 200 };
            grpSaisie.Controls.Add(txtHeures);

            // GroupBox Actions
            GroupBox grpActions = new GroupBox
            {
                Text = "Actions",
                Location = new System.Drawing.Point(420, 50),
                Size = new System.Drawing.Size(360, 180)
            };
            this.Controls.Add(grpActions);

            // Bouton Ajouter
            btnAjouter = new Button
            {
                Text = "Ajouter",
                Location = new System.Drawing.Point(20, 40),
                Width = 100,
                Height = 40,
                BackColor = System.Drawing.Color.LightGreen
            };
            btnAjouter.Click += BtnAjouter_Click;
            grpActions.Controls.Add(btnAjouter);

            // Bouton Modifier
            btnModifier = new Button
            {
                Text = "Modifier",
                Location = new System.Drawing.Point(130, 40),
                Width = 100,
                Height = 40,
                BackColor = System.Drawing.Color.LightBlue
            };
            btnModifier.Click += BtnModifier_Click;
            grpActions.Controls.Add(btnModifier);

            // Bouton Supprimer
            btnSupprimer = new Button
            {
                Text = "Supprimer",
                Location = new System.Drawing.Point(240, 40),
                Width = 100,
                Height = 40,
                BackColor = System.Drawing.Color.LightCoral
            };
            btnSupprimer.Click += BtnSupprimer_Click;
            grpActions.Controls.Add(btnSupprimer);

            // DataGridView
            this.Controls.Add(new Label
            {
                Text = "Liste des Employes:",
                Location = new System.Drawing.Point(20, 240),
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold)
            });

            dgvEmployes = new DataGridView
            {
                Location = new System.Drawing.Point(20, 265),
                Size = new System.Drawing.Size(760, 230),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                BackgroundColor = System.Drawing.Color.White
            };
            dgvEmployes.CellClick += DgvEmployes_CellClick;
            this.Controls.Add(dgvEmployes);

            // Statut
            lblStatus = new Label
            {
                Text = "Statut: Non connecte",
                Location = new System.Drawing.Point(20, 505),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Red,
                Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Bold)
            };
            this.Controls.Add(lblStatus);
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
