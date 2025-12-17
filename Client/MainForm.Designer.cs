namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Main Layout
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabEmployes;
        private System.Windows.Forms.TabPage tabDepartements;
        private System.Windows.Forms.TabPage tabProjets;
        private System.Windows.Forms.TabPage tabAffectations;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        // --- EMPLOYES Controls ---
        private System.Windows.Forms.TextBox txtCin;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtTaux;
        private System.Windows.Forms.TextBox txtHeures;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.DataGridView dgvEmployes;
        private System.Windows.Forms.GroupBox grpSaisie;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Label lblCinLabel;
        private System.Windows.Forms.Label lblNomLabel;
        private System.Windows.Forms.Label lblTauxLabel;
        private System.Windows.Forms.Label lblHeuresLabel;

        // --- DEPARTEMENTS Controls ---
        private System.Windows.Forms.DataGridView dgvDepartements;
        private System.Windows.Forms.GroupBox grpSaisieDept;
        private System.Windows.Forms.GroupBox grpActionsDept;
        private System.Windows.Forms.Label lblDeptNom;
        private System.Windows.Forms.TextBox txtDeptNom;
        private System.Windows.Forms.Label lblDeptChef;
        private System.Windows.Forms.TextBox txtDeptChefCin;
        private System.Windows.Forms.Button btnAjouterDept;
        private System.Windows.Forms.Button btnModifierDept;
        private System.Windows.Forms.Button btnSupprimerDept;

        // --- PROJETS Controls ---
        private System.Windows.Forms.DataGridView dgvProjets;
        private System.Windows.Forms.GroupBox grpSaisieProjet;
        private System.Windows.Forms.GroupBox grpActionsProjet;
        private System.Windows.Forms.Label lblProjetNom;
        private System.Windows.Forms.TextBox txtProjetNom;
        private System.Windows.Forms.Label lblProjetBudget;
        private System.Windows.Forms.TextBox txtProjetBudget;
        private System.Windows.Forms.Button btnAjouterProjet;
        private System.Windows.Forms.Button btnModifierProjet;
        private System.Windows.Forms.Button btnSupprimerProjet;

        // --- AFFECTATIONS Controls ---
        private System.Windows.Forms.DataGridView dgvAffectations;
        private System.Windows.Forms.GroupBox grpSaisieAff;
        private System.Windows.Forms.GroupBox grpActionsAff;
        private System.Windows.Forms.Label lblAffEmp;
        private System.Windows.Forms.TextBox txtAffEmpCin;
        private System.Windows.Forms.Label lblAffProj;
        private System.Windows.Forms.TextBox txtAffProjetId;
        private System.Windows.Forms.Label lblAffHeures;
        private System.Windows.Forms.TextBox txtAffHeures;
        private System.Windows.Forms.Button btnAjouterAff;
        private System.Windows.Forms.Button btnModifierAff;
        private System.Windows.Forms.Button btnSupprimerAff;

        private System.Windows.Forms.ToolTip toolTip;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            // Instantiate Layout Containers
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabEmployes = new System.Windows.Forms.TabPage();
            this.tabDepartements = new System.Windows.Forms.TabPage();
            this.tabProjets = new System.Windows.Forms.TabPage();
            this.tabAffectations = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            // Instantiate Employes Controls
            this.grpSaisie = new System.Windows.Forms.GroupBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.dgvEmployes = new System.Windows.Forms.DataGridView();
            this.lblCinLabel = new System.Windows.Forms.Label(); this.txtCin = new System.Windows.Forms.TextBox();
            this.lblNomLabel = new System.Windows.Forms.Label(); this.txtNom = new System.Windows.Forms.TextBox();
            this.lblTauxLabel = new System.Windows.Forms.Label(); this.txtTaux = new System.Windows.Forms.TextBox();
            this.lblHeuresLabel = new System.Windows.Forms.Label(); this.txtHeures = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();

            // Instantiate Departements Controls
            this.grpSaisieDept = new System.Windows.Forms.GroupBox();
            this.grpActionsDept = new System.Windows.Forms.GroupBox();
            this.dgvDepartements = new System.Windows.Forms.DataGridView();
            this.lblDeptNom = new System.Windows.Forms.Label(); this.txtDeptNom = new System.Windows.Forms.TextBox();
            this.lblDeptChef = new System.Windows.Forms.Label(); this.txtDeptChefCin = new System.Windows.Forms.TextBox();
            this.btnAjouterDept = new System.Windows.Forms.Button();
            this.btnModifierDept = new System.Windows.Forms.Button();
            this.btnSupprimerDept = new System.Windows.Forms.Button();

            // Instantiate Projets Controls
            this.grpSaisieProjet = new System.Windows.Forms.GroupBox();
            this.grpActionsProjet = new System.Windows.Forms.GroupBox();
            this.dgvProjets = new System.Windows.Forms.DataGridView();
            this.lblProjetNom = new System.Windows.Forms.Label(); this.txtProjetNom = new System.Windows.Forms.TextBox();
            this.lblProjetBudget = new System.Windows.Forms.Label(); this.txtProjetBudget = new System.Windows.Forms.TextBox();
            this.btnAjouterProjet = new System.Windows.Forms.Button();
            this.btnModifierProjet = new System.Windows.Forms.Button();
            this.btnSupprimerProjet = new System.Windows.Forms.Button();

            // Instantiate Affectations Controls
            this.grpSaisieAff = new System.Windows.Forms.GroupBox();
            this.grpActionsAff = new System.Windows.Forms.GroupBox();
            this.dgvAffectations = new System.Windows.Forms.DataGridView();
            this.lblAffEmp = new System.Windows.Forms.Label(); this.txtAffEmpCin = new System.Windows.Forms.TextBox();
            this.lblAffProj = new System.Windows.Forms.Label(); this.txtAffProjetId = new System.Windows.Forms.TextBox();
            this.lblAffHeures = new System.Windows.Forms.Label(); this.txtAffHeures = new System.Windows.Forms.TextBox();
            this.btnAjouterAff = new System.Windows.Forms.Button();
            this.btnModifierAff = new System.Windows.Forms.Button();
            this.btnSupprimerAff = new System.Windows.Forms.Button();

            // Suspend Layout
            this.tabControlMain.SuspendLayout();
            this.tabEmployes.SuspendLayout();
            this.grpSaisie.SuspendLayout();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).BeginInit();
            
            this.tabDepartements.SuspendLayout();
            this.grpSaisieDept.SuspendLayout();
            this.grpActionsDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartements)).BeginInit();

            this.tabProjets.SuspendLayout();
            this.grpSaisieProjet.SuspendLayout();
            this.grpActionsProjet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjets)).BeginInit();

            this.tabAffectations.SuspendLayout();
            this.grpSaisieAff.SuspendLayout();
            this.grpActionsAff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffectations)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabEmployes);
            this.tabControlMain.Controls.Add(this.tabDepartements);
            this.tabControlMain.Controls.Add(this.tabProjets);
            this.tabControlMain.Controls.Add(this.tabAffectations);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 500);

            // ===========================================
            // TAB EMPLOYES
            // ===========================================
            this.tabEmployes.Controls.Add(this.grpSaisie);
            this.tabEmployes.Controls.Add(this.grpActions);
            this.tabEmployes.Controls.Add(this.dgvEmployes);
            this.tabEmployes.Location = new System.Drawing.Point(4, 25);
            this.tabEmployes.Text = "Employes";
            this.tabEmployes.Padding = new System.Windows.Forms.Padding(3);

            // Grp Saisie
            this.grpSaisie.Controls.Add(this.lblCinLabel); this.grpSaisie.Controls.Add(this.txtCin);
            this.grpSaisie.Controls.Add(this.lblNomLabel); this.grpSaisie.Controls.Add(this.txtNom);
            this.grpSaisie.Controls.Add(this.lblTauxLabel); this.grpSaisie.Controls.Add(this.txtTaux);
            this.grpSaisie.Controls.Add(this.lblHeuresLabel); this.grpSaisie.Controls.Add(this.txtHeures);
            this.grpSaisie.Location = new System.Drawing.Point(10, 10);
            this.grpSaisie.Size = new System.Drawing.Size(460, 160);
            this.grpSaisie.Text = "Infos Employe";

            this.lblCinLabel.Location = new System.Drawing.Point(20, 25); this.lblCinLabel.Text = "CIN:"; this.lblCinLabel.AutoSize = true;
            this.txtCin.Location = new System.Drawing.Point(130, 22); this.txtCin.Size = new System.Drawing.Size(250, 22);

            this.lblNomLabel.Location = new System.Drawing.Point(20, 55); this.lblNomLabel.Text = "Nom:"; this.lblNomLabel.AutoSize = true;
            this.txtNom.Location = new System.Drawing.Point(130, 52); this.txtNom.Size = new System.Drawing.Size(250, 22);

            this.lblTauxLabel.Location = new System.Drawing.Point(20, 85); this.lblTauxLabel.Text = "Taux Horaire:"; this.lblTauxLabel.AutoSize = true;
            this.txtTaux.Location = new System.Drawing.Point(130, 82); this.txtTaux.Size = new System.Drawing.Size(250, 22);

            this.lblHeuresLabel.Location = new System.Drawing.Point(20, 115); this.lblHeuresLabel.Text = "Nb Heures:"; this.lblHeuresLabel.AutoSize = true;
            this.txtHeures.Location = new System.Drawing.Point(130, 112); this.txtHeures.Size = new System.Drawing.Size(250, 22);

            // Grp Actions
            this.grpActions.Controls.Add(this.btnAjouter);
            this.grpActions.Controls.Add(this.btnModifier);
            this.grpActions.Controls.Add(this.btnSupprimer);
            this.grpActions.Location = new System.Drawing.Point(480, 10);
            this.grpActions.Size = new System.Drawing.Size(150, 160);
            this.grpActions.Text = "Actions";

            this.btnAjouter.Location = new System.Drawing.Point(10, 20); this.btnAjouter.Size = new System.Drawing.Size(130, 30); this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);

            this.btnModifier.Location = new System.Drawing.Point(10, 60); this.btnModifier.Size = new System.Drawing.Size(130, 30); this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.BtnModifier_Click);
            
            this.btnSupprimer.Location = new System.Drawing.Point(10, 100); this.btnSupprimer.Size = new System.Drawing.Size(130, 30); this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);

            // DGV
            this.dgvEmployes.Location = new System.Drawing.Point(10, 180);
            this.dgvEmployes.Size = new System.Drawing.Size(770, 280);
            this.dgvEmployes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmployes_CellClick);


            // ===========================================
            // TAB DEPARTEMENTS
            // ===========================================
            this.tabDepartements.Controls.Add(this.grpSaisieDept);
            this.tabDepartements.Controls.Add(this.grpActionsDept);
            this.tabDepartements.Controls.Add(this.dgvDepartements);
            this.tabDepartements.Location = new System.Drawing.Point(4, 25);
            this.tabDepartements.Text = "Departements";
            this.tabDepartements.Padding = new System.Windows.Forms.Padding(3);

            // Grp Saisie
            this.grpSaisieDept.Controls.Add(this.lblDeptNom); this.grpSaisieDept.Controls.Add(this.txtDeptNom);
            this.grpSaisieDept.Controls.Add(this.lblDeptChef); this.grpSaisieDept.Controls.Add(this.txtDeptChefCin);
            this.grpSaisieDept.Location = new System.Drawing.Point(10, 10);
            this.grpSaisieDept.Size = new System.Drawing.Size(460, 160);
            this.grpSaisieDept.Text = "Infos Departement";

            this.lblDeptNom.Location = new System.Drawing.Point(20, 25); this.lblDeptNom.Text = "Nom:"; this.lblDeptNom.AutoSize = true;
            this.txtDeptNom.Location = new System.Drawing.Point(130, 22); this.txtDeptNom.Size = new System.Drawing.Size(250, 22);

            this.lblDeptChef.Location = new System.Drawing.Point(20, 55); this.lblDeptChef.Text = "Chef (CIN):"; this.lblDeptChef.AutoSize = true;
            this.txtDeptChefCin.Location = new System.Drawing.Point(130, 52); this.txtDeptChefCin.Size = new System.Drawing.Size(250, 22);

            // Grp Actions
            this.grpActionsDept.Controls.Add(this.btnAjouterDept);
            this.grpActionsDept.Controls.Add(this.btnModifierDept);
            this.grpActionsDept.Controls.Add(this.btnSupprimerDept);
            this.grpActionsDept.Location = new System.Drawing.Point(480, 10);
            this.grpActionsDept.Size = new System.Drawing.Size(150, 160);
            this.grpActionsDept.Text = "Actions";

            this.btnAjouterDept.Location = new System.Drawing.Point(10, 20); this.btnAjouterDept.Size = new System.Drawing.Size(130, 30); this.btnAjouterDept.Text = "Ajouter";
            this.btnAjouterDept.Click += new System.EventHandler(this.BtnAjouterDept_Click);

            this.btnModifierDept.Location = new System.Drawing.Point(10, 60); this.btnModifierDept.Size = new System.Drawing.Size(130, 30); this.btnModifierDept.Text = "Modifier";
            this.btnModifierDept.Click += new System.EventHandler(this.BtnModifierDept_Click);

            this.btnSupprimerDept.Location = new System.Drawing.Point(10, 100); this.btnSupprimerDept.Size = new System.Drawing.Size(130, 30); this.btnSupprimerDept.Text = "Supprimer";
            this.btnSupprimerDept.Click += new System.EventHandler(this.BtnSupprimerDept_Click);

            // DGV
            this.dgvDepartements.Location = new System.Drawing.Point(10, 180);
            this.dgvDepartements.Size = new System.Drawing.Size(770, 280);
            this.dgvDepartements.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDepartements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartements.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDepartements_CellClick);


            // ===========================================
            // TAB PROJETS
            // ===========================================
            this.tabProjets.Controls.Add(this.grpSaisieProjet);
            this.tabProjets.Controls.Add(this.grpActionsProjet);
            this.tabProjets.Controls.Add(this.dgvProjets);
            this.tabProjets.Location = new System.Drawing.Point(4, 25);
            this.tabProjets.Text = "Projets";
            this.tabProjets.Padding = new System.Windows.Forms.Padding(3);

            // Grp Saisie
            this.grpSaisieProjet.Controls.Add(this.lblProjetNom); this.grpSaisieProjet.Controls.Add(this.txtProjetNom);
            this.grpSaisieProjet.Controls.Add(this.lblProjetBudget); this.grpSaisieProjet.Controls.Add(this.txtProjetBudget);
            this.grpSaisieProjet.Location = new System.Drawing.Point(10, 10);
            this.grpSaisieProjet.Size = new System.Drawing.Size(460, 160);
            this.grpSaisieProjet.Text = "Infos Projet";

            this.lblProjetNom.Location = new System.Drawing.Point(20, 25); this.lblProjetNom.Text = "Nom:"; this.lblProjetNom.AutoSize = true;
            this.txtProjetNom.Location = new System.Drawing.Point(130, 22); this.txtProjetNom.Size = new System.Drawing.Size(250, 22);

            this.lblProjetBudget.Location = new System.Drawing.Point(20, 55); this.lblProjetBudget.Text = "Budget:"; this.lblProjetBudget.AutoSize = true;
            this.txtProjetBudget.Location = new System.Drawing.Point(130, 52); this.txtProjetBudget.Size = new System.Drawing.Size(250, 22);

            // Grp Actions
            this.grpActionsProjet.Controls.Add(this.btnAjouterProjet);
            this.grpActionsProjet.Controls.Add(this.btnModifierProjet);
            this.grpActionsProjet.Controls.Add(this.btnSupprimerProjet);
            this.grpActionsProjet.Location = new System.Drawing.Point(480, 10);
            this.grpActionsProjet.Size = new System.Drawing.Size(150, 160);
            this.grpActionsProjet.Text = "Actions";

            this.btnAjouterProjet.Location = new System.Drawing.Point(10, 20); this.btnAjouterProjet.Size = new System.Drawing.Size(130, 30); this.btnAjouterProjet.Text = "Ajouter";
            this.btnAjouterProjet.Click += new System.EventHandler(this.BtnAjouterProjet_Click);

            this.btnModifierProjet.Location = new System.Drawing.Point(10, 60); this.btnModifierProjet.Size = new System.Drawing.Size(130, 30); this.btnModifierProjet.Text = "Modifier";
            this.btnModifierProjet.Click += new System.EventHandler(this.BtnModifierProjet_Click);

            this.btnSupprimerProjet.Location = new System.Drawing.Point(10, 100); this.btnSupprimerProjet.Size = new System.Drawing.Size(130, 30); this.btnSupprimerProjet.Text = "Supprimer";
            this.btnSupprimerProjet.Click += new System.EventHandler(this.BtnSupprimerProjet_Click);

            // DGV
            this.dgvProjets.Location = new System.Drawing.Point(10, 180);
            this.dgvProjets.Size = new System.Drawing.Size(770, 280);
            this.dgvProjets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProjets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProjets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProjets_CellClick);


            // ===========================================
            // TAB AFFECTATIONS
            // ===========================================
            this.tabAffectations.Controls.Add(this.grpSaisieAff);
            this.tabAffectations.Controls.Add(this.grpActionsAff);
            this.tabAffectations.Controls.Add(this.dgvAffectations);
            this.tabAffectations.Location = new System.Drawing.Point(4, 25);
            this.tabAffectations.Text = "Affectations";
            this.tabAffectations.Padding = new System.Windows.Forms.Padding(3);

            // Grp Saisie
            this.grpSaisieAff.Controls.Add(this.lblAffEmp); this.grpSaisieAff.Controls.Add(this.txtAffEmpCin);
            this.grpSaisieAff.Controls.Add(this.lblAffProj); this.grpSaisieAff.Controls.Add(this.txtAffProjetId);
            this.grpSaisieAff.Controls.Add(this.lblAffHeures); this.grpSaisieAff.Controls.Add(this.txtAffHeures);
            this.grpSaisieAff.Location = new System.Drawing.Point(10, 10);
            this.grpSaisieAff.Size = new System.Drawing.Size(460, 160);
            this.grpSaisieAff.Text = "Infos Affectation";

            this.lblAffEmp.Location = new System.Drawing.Point(20, 25); this.lblAffEmp.Text = "Cin Emp:"; this.lblAffEmp.AutoSize = true;
            this.txtAffEmpCin.Location = new System.Drawing.Point(130, 22); this.txtAffEmpCin.Size = new System.Drawing.Size(250, 22);

            this.lblAffProj.Location = new System.Drawing.Point(20, 55); this.lblAffProj.Text = "Projet ID:"; this.lblAffProj.AutoSize = true;
            this.txtAffProjetId.Location = new System.Drawing.Point(130, 52); this.txtAffProjetId.Size = new System.Drawing.Size(250, 22);

            this.lblAffHeures.Location = new System.Drawing.Point(20, 85); this.lblAffHeures.Text = "Heures:"; this.lblAffHeures.AutoSize = true;
            this.txtAffHeures.Location = new System.Drawing.Point(130, 82); this.txtAffHeures.Size = new System.Drawing.Size(250, 22);

            // Grp Actions
            this.grpActionsAff.Controls.Add(this.btnAjouterAff);
            this.grpActionsAff.Controls.Add(this.btnModifierAff);
            this.grpActionsAff.Controls.Add(this.btnSupprimerAff);
            this.grpActionsAff.Location = new System.Drawing.Point(480, 10);
            this.grpActionsAff.Size = new System.Drawing.Size(150, 160);
            this.grpActionsAff.Text = "Actions";

            this.btnAjouterAff.Location = new System.Drawing.Point(10, 20); this.btnAjouterAff.Size = new System.Drawing.Size(130, 30); this.btnAjouterAff.Text = "Ajouter";
            this.btnAjouterAff.Click += new System.EventHandler(this.BtnAjouterAff_Click);

            this.btnModifierAff.Location = new System.Drawing.Point(10, 60); this.btnModifierAff.Size = new System.Drawing.Size(130, 30); this.btnModifierAff.Text = "Modifier";
            this.btnModifierAff.Click += new System.EventHandler(this.BtnModifierAff_Click);

            this.btnSupprimerAff.Location = new System.Drawing.Point(10, 100); this.btnSupprimerAff.Size = new System.Drawing.Size(130, 30); this.btnSupprimerAff.Text = "Supprimer";
            this.btnSupprimerAff.Click += new System.EventHandler(this.BtnSupprimerAff_Click);

            // DGV
            this.dgvAffectations.Location = new System.Drawing.Point(10, 180);
            this.dgvAffectations.Size = new System.Drawing.Size(770, 280);
            this.dgvAffectations.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvAffectations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAffectations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAffectations_CellClick);


            // ---------------- MAIN FORM ----------------
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip.Location = new System.Drawing.Point(0, 510);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.statusStrip);
            this.Name = "MainForm";
            this.Text = "Gestion d'Entreprise Integrée";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.tabControlMain.ResumeLayout(false);
            this.tabEmployes.ResumeLayout(false);
            this.grpSaisie.ResumeLayout(false); this.grpSaisie.PerformLayout();
            this.grpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).EndInit();

            this.tabDepartements.ResumeLayout(false);
            this.grpSaisieDept.ResumeLayout(false); this.grpSaisieDept.PerformLayout();
            this.grpActionsDept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartements)).EndInit();

            this.tabProjets.ResumeLayout(false);
            this.grpSaisieProjet.ResumeLayout(false); this.grpSaisieProjet.PerformLayout();
            this.grpActionsProjet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjets)).EndInit();

            this.tabAffectations.ResumeLayout(false);
            this.grpSaisieAff.ResumeLayout(false); this.grpSaisieAff.PerformLayout();
            this.grpActionsAff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffectations)).EndInit();

            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
