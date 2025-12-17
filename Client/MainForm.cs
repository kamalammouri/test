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
        // Variables pour stocker les IDs selectionnes (au lieu de TextBoxes visibles)
        private int _selectedDeptId = -1;
        private int _selectedProjetId = -1;
        private int _selectedAffId = -1;

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
                
                // Initial Load for all tabs
                ChargerListeEmployes();
                ChargerDepartements();
                ChargerProjets();
                ChargerAffectations();
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
                if (string.IsNullOrWhiteSpace(txtCin.Text)) return;

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
                else MessageBox.Show("Erreur ajout");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCin.Text)) return;

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
                else MessageBox.Show("Erreur modification");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCin.Text)) return;

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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ViderChampsEmploye()
        {
            txtCin.Text = ""; txtNom.Text = ""; txtTaux.Text = ""; txtHeures.Text = "";
        }

        // ==========================================
        //  DEPARTEMENTS
        // ==========================================

        private void ChargerDepartements()
        {
            try
            {
                dgvDepartements.DataSource = null;
                dgvDepartements.DataSource = serviceProxy.ListerDepartements();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DgvDepartements_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDepartements.Rows[e.RowIndex];
                // On recupere l'ID mais on ne l'affiche pas
                _selectedDeptId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "-1");
                txtDeptNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
                txtDeptChefCin.Text = row.Cells["ChefCin"].Value?.ToString() ?? "";
            }
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
                    ViderChampsDept();
                    ChargerDepartements();
                }
                else MessageBox.Show("Erreur ajout Departement");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnModifierDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedDeptId == -1) return;
                Departement d = new Departement
                {
                    Id = _selectedDeptId,
                    Nom = txtDeptNom.Text,
                    ChefCin = string.IsNullOrWhiteSpace(txtDeptChefCin.Text) ? null : txtDeptChefCin.Text
                };
                if (serviceProxy.ModifierDepartement(d))
                {
                    MessageBox.Show("Departement Modifie!");
                    ViderChampsDept();
                    ChargerDepartements();
                }
                else MessageBox.Show("Erreur modif Departement");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSupprimerDept_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedDeptId == -1) return;
                if (MessageBox.Show("Confirmer suppression Dept?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (serviceProxy.SupprimerDepartement(_selectedDeptId))
                    {
                        MessageBox.Show("Supprime!");
                        ViderChampsDept();
                        ChargerDepartements();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ViderChampsDept()
        {
            _selectedDeptId = -1; txtDeptNom.Text = ""; txtDeptChefCin.Text = "";
        }

        // ==========================================
        //  PROJETS
        // ==========================================

        private void ChargerProjets()
        {
            try
            {
                dgvProjets.DataSource = null;
                dgvProjets.DataSource = serviceProxy.ListerProjets();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DgvProjets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProjets.Rows[e.RowIndex];
                _selectedProjetId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "-1");
                txtProjetNom.Text = row.Cells["Nom"].Value?.ToString() ?? "";
                txtProjetBudget.Text = row.Cells["Budget"].Value?.ToString() ?? "";
            }
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
                    ViderChampsProjet();
                    ChargerProjets();
                }
                else MessageBox.Show("Erreur ajout Projet");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnModifierProjet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProjetId == -1) return;
                Projet p = new Projet
                {
                    Id = _selectedProjetId,
                    Nom = txtProjetNom.Text,
                    Budget = double.Parse(txtProjetBudget.Text)
                };
                if (serviceProxy.ModifierProjet(p))
                {
                    MessageBox.Show("Projet Modifie!");
                    ViderChampsProjet();
                    ChargerProjets();
                }
                else MessageBox.Show("Erreur modif Projet");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSupprimerProjet_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedProjetId == -1) return;
                if (MessageBox.Show("Confirmer suppression Projet?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (serviceProxy.SupprimerProjet(_selectedProjetId))
                    {
                        MessageBox.Show("Supprime!");
                        ViderChampsProjet();
                        ChargerProjets();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ViderChampsProjet()
        {
            _selectedProjetId = -1; txtProjetNom.Text = ""; txtProjetBudget.Text = "";
        }

        // ==========================================
        //  AFFECTATIONS
        // ==========================================

        private void ChargerAffectations()
        {
            try
            {
                dgvAffectations.DataSource = null;
                dgvAffectations.DataSource = serviceProxy.ListerAffectations();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DgvAffectations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAffectations.Rows[e.RowIndex];
                _selectedAffId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "-1");
                txtAffEmpCin.Text = row.Cells["EmployeCin"].Value?.ToString() ?? "";
                txtAffProjetId.Text = row.Cells["ProjetId"].Value?.ToString() ?? "";
                txtAffHeures.Text = row.Cells["Heures"].Value?.ToString() ?? "";
            }
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
                    ViderChampsAff();
                    ChargerAffectations();
                }
                else MessageBox.Show("Erreur ajout Affectation");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnModifierAff_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAffId == -1) return;
                Affectation a = new Affectation
                {
                    Id = _selectedAffId,
                    EmployeCin = txtAffEmpCin.Text,
                    ProjetId = int.Parse(txtAffProjetId.Text),
                    Heures = int.Parse(txtAffHeures.Text)
                };
                if (serviceProxy.ModifierAffectation(a))
                {
                    MessageBox.Show("Affectation Modifiee!");
                    ViderChampsAff();
                    ChargerAffectations();
                }
                else MessageBox.Show("Erreur modif Affectation");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSupprimerAff_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAffId == -1) return;
                if (MessageBox.Show("Confirmer suppression Affectation?", "Info", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (serviceProxy.SupprimerAffectation(_selectedAffId))
                    {
                        MessageBox.Show("Supprime!");
                        ViderChampsAff();
                        ChargerAffectations();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ViderChampsAff()
        {
            _selectedAffId = -1; txtAffEmpCin.Text = ""; txtAffProjetId.Text = ""; txtAffHeures.Text = "";
        }
    }
}
