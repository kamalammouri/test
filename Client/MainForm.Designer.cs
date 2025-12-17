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
        private System.Windows.Forms.Label lblDeptNom;
        private System.Windows.Forms.TextBox txtDeptNom;
        private System.Windows.Forms.Label lblDeptChef;
        private System.Windows.Forms.TextBox txtDeptChefCin;
        private System.Windows.Forms.Button btnAjouterDept;
        private System.Windows.Forms.Button btnListerDept;

        // --- PROJETS Controls ---
        private System.Windows.Forms.DataGridView dgvProjets;
        private System.Windows.Forms.GroupBox grpSaisieProjet;
        private System.Windows.Forms.Label lblProjetNom;
        private System.Windows.Forms.TextBox txtProjetNom;
        private System.Windows.Forms.Label lblProjetBudget;
        private System.Windows.Forms.TextBox txtProjetBudget;
        private System.Windows.Forms.Button btnAjouterProjet;
        private System.Windows.Forms.Button btnListerProjet;

        // --- AFFECTATIONS Controls ---
        private System.Windows.Forms.DataGridView dgvAffectations;
        private System.Windows.Forms.GroupBox grpSaisieAff;
        private System.Windows.Forms.Label lblAffEmp;
        private System.Windows.Forms.TextBox txtAffEmpCin;
        private System.Windows.Forms.Label lblAffProj;
        private System.Windows.Forms.TextBox txtAffProjetId;
        private System.Windows.Forms.Label lblAffHeures;
        private System.Windows.Forms.TextBox txtAffHeures;
        private System.Windows.Forms.Button btnAjouterAff;
        private System.Windows.Forms.Button btnListerAff;

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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabEmployes = new System.Windows.Forms.TabPage();
            this.grpSaisie = new System.Windows.Forms.GroupBox();
            this.lblCinLabel = new System.Windows.Forms.Label();
            this.txtCin = new System.Windows.Forms.TextBox();
            this.lblNomLabel = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblTauxLabel = new System.Windows.Forms.Label();
            this.txtTaux = new System.Windows.Forms.TextBox();
            this.lblHeuresLabel = new System.Windows.Forms.Label();
            this.txtHeures = new System.Windows.Forms.TextBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.dgvEmployes = new System.Windows.Forms.DataGridView();

            this.tabDepartements = new System.Windows.Forms.TabPage();
            this.grpSaisieDept = new System.Windows.Forms.GroupBox();
            this.lblDeptNom = new System.Windows.Forms.Label();
            this.txtDeptNom = new System.Windows.Forms.TextBox();
            this.lblDeptChef = new System.Windows.Forms.Label();
            this.txtDeptChefCin = new System.Windows.Forms.TextBox();
            this.btnAjouterDept = new System.Windows.Forms.Button();
            this.btnListerDept = new System.Windows.Forms.Button();
            this.dgvDepartements = new System.Windows.Forms.DataGridView();

            this.tabProjets = new System.Windows.Forms.TabPage();
            this.grpSaisieProjet = new System.Windows.Forms.GroupBox();
            this.lblProjetNom = new System.Windows.Forms.Label();
            this.txtProjetNom = new System.Windows.Forms.TextBox();
            this.lblProjetBudget = new System.Windows.Forms.Label();
            this.txtProjetBudget = new System.Windows.Forms.TextBox();
            this.btnAjouterProjet = new System.Windows.Forms.Button();
            this.btnListerProjet = new System.Windows.Forms.Button();
            this.dgvProjets = new System.Windows.Forms.DataGridView();

            this.tabAffectations = new System.Windows.Forms.TabPage();
            this.grpSaisieAff = new System.Windows.Forms.GroupBox();
            this.lblAffEmp = new System.Windows.Forms.Label();
            this.txtAffEmpCin = new System.Windows.Forms.TextBox();
            this.lblAffProj = new System.Windows.Forms.Label();
            this.txtAffProjetId = new System.Windows.Forms.TextBox();
            this.lblAffHeures = new System.Windows.Forms.Label();
            this.txtAffHeures = new System.Windows.Forms.TextBox();
            this.btnAjouterAff = new System.Windows.Forms.Button();
            this.btnListerAff = new System.Windows.Forms.Button();
            this.dgvAffectations = new System.Windows.Forms.DataGridView();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            this.tabControlMain.SuspendLayout();
            this.tabEmployes.SuspendLayout();
            this.grpSaisie.SuspendLayout();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).BeginInit();
            this.tabDepartements.SuspendLayout();
            this.grpSaisieDept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartements)).BeginInit();
            this.tabProjets.SuspendLayout();
            this.grpSaisieProjet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjets)).BeginInit();
            this.tabAffectations.SuspendLayout();
            this.grpSaisieAff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffectations)).BeginInit();
            this.statusStrip.SuspendLayout();
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
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(800, 500);
            this.tabControlMain.TabIndex = 0;

            // ---------------- EMPLOYES TAB ----------------
            this.tabEmployes.Location = new System.Drawing.Point(4, 25);
            this.tabEmployes.Name = "tabEmployes";
            this.tabEmployes.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployes.Size = new System.Drawing.Size(792, 471);
            this.tabEmployes.TabIndex = 0;
            this.tabEmployes.Text = "Employes";
            this.tabEmployes.UseVisualStyleBackColor = true;

            this.tabEmployes.Controls.Add(this.grpSaisie);
            this.tabEmployes.Controls.Add(this.grpActions);
            this.tabEmployes.Controls.Add(this.dgvEmployes);

            // Group Saisie Employe
            this.grpSaisie.Location = new System.Drawing.Point(10, 10);
            this.grpSaisie.Size = new System.Drawing.Size(450, 160); // Increased width and height
            this.grpSaisie.Text = "Infos Employe";
            this.grpSaisie.Controls.Add(this.lblCinLabel); this.grpSaisie.Controls.Add(this.txtCin);
            this.grpSaisie.Controls.Add(this.lblNomLabel); this.grpSaisie.Controls.Add(this.txtNom);
            this.grpSaisie.Controls.Add(this.lblTauxLabel); this.grpSaisie.Controls.Add(this.txtTaux);
            this.grpSaisie.Controls.Add(this.lblHeuresLabel); this.grpSaisie.Controls.Add(this.txtHeures);

            // Re-positioned controls with more comfortable spacing
            this.lblCinLabel.Location = new System.Drawing.Point(20, 25); this.lblCinLabel.Text = "CIN:";
            this.lblCinLabel.AutoSize = true;
            this.txtCin.Location = new System.Drawing.Point(130, 22); this.txtCin.Size = new System.Drawing.Size(250, 22);

            this.lblNomLabel.Location = new System.Drawing.Point(20, 55); this.lblNomLabel.Text = "Nom:";
            this.lblNomLabel.AutoSize = true;
            this.txtNom.Location = new System.Drawing.Point(130, 52); this.txtNom.Size = new System.Drawing.Size(250, 22);

            this.lblTauxLabel.Location = new System.Drawing.Point(20, 85); this.lblTauxLabel.Text = "Taux Horaire:";
            this.lblTauxLabel.AutoSize = true;
            this.txtTaux.Location = new System.Drawing.Point(130, 82); this.txtTaux.Size = new System.Drawing.Size(250, 22);

            this.lblHeuresLabel.Location = new System.Drawing.Point(20, 115); this.lblHeuresLabel.Text = "Nb Heures:";
            this.lblHeuresLabel.AutoSize = true;
            this.txtHeures.Location = new System.Drawing.Point(130, 112); this.txtHeures.Size = new System.Drawing.Size(250, 22);

            // Group Actions Employe
            this.grpActions.Location = new System.Drawing.Point(470, 10); // Moved right
            this.grpActions.Size = new System.Drawing.Size(150, 150);
            this.grpActions.Text = "Actions";
            this.grpActions.Controls.Add(this.btnAjouter);
            this.grpActions.Controls.Add(this.btnModifier);
            this.grpActions.Controls.Add(this.btnSupprimer);

            this.btnAjouter.Location = new System.Drawing.Point(10, 20); this.btnAjouter.Size = new System.Drawing.Size(130, 30); this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);

            this.btnModifier.Location = new System.Drawing.Point(10, 60); this.btnModifier.Size = new System.Drawing.Size(130, 30); this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.BtnModifier_Click);

            this.btnSupprimer.Location = new System.Drawing.Point(10, 100); this.btnSupprimer.Size = new System.Drawing.Size(130, 30); this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);

            // DGV Employe
            this.dgvEmployes.Location = new System.Drawing.Point(10, 170);
            this.dgvEmployes.Size = new System.Drawing.Size(770, 290);
            this.dgvEmployes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmployes_CellClick);


            // ---------------- DEPARTEMENTS TAB ----------------
            this.tabDepartements.Location = new System.Drawing.Point(4, 25);
            this.tabDepartements.Name = "tabDepartements";
            this.tabDepartements.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepartements.Size = new System.Drawing.Size(792, 471);
            this.tabDepartements.Text = "Departements";
            this.tabDepartements.UseVisualStyleBackColor = true;

            this.tabDepartements.Controls.Add(this.grpSaisieDept);
            this.tabDepartements.Controls.Add(this.dgvDepartements);


            this.grpSaisieDept.Location = new System.Drawing.Point(10, 10);
            this.grpSaisieDept.Size = new System.Drawing.Size(770, 80);
            this.grpSaisieDept.Text = "Gestion Departements";
            
            this.lblDeptNom.Location = new System.Drawing.Point(20, 30); this.lblDeptNom.Text = "Nom:";
            this.lblDeptNom.AutoSize = true;
            this.txtDeptNom.Location = new System.Drawing.Point(80, 27); this.txtDeptNom.Size = new System.Drawing.Size(200, 22);
            
            this.lblDeptChef.Location = new System.Drawing.Point(300, 30); this.lblDeptChef.Text = "Chef (CIN):";
            this.lblDeptChef.AutoSize = true;
            this.txtDeptChefCin.Location = new System.Drawing.Point(380, 27); this.txtDeptChefCin.Size = new System.Drawing.Size(150, 22);

            this.btnAjouterDept.Location = new System.Drawing.Point(550, 25); this.btnAjouterDept.Size = new System.Drawing.Size(100, 30); this.btnAjouterDept.Text = "Ajouter";
            this.btnAjouterDept.Click += new System.EventHandler(this.BtnAjouterDept_Click);

            this.btnListerDept.Location = new System.Drawing.Point(660, 25); this.btnListerDept.Size = new System.Drawing.Size(100, 30); this.btnListerDept.Text = "Lister";
            this.btnListerDept.Click += new System.EventHandler(this.BtnListerDept_Click);

            this.grpSaisieDept.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblDeptNom, this.txtDeptNom, this.lblDeptChef, this.txtDeptChefCin, this.btnAjouterDept, this.btnListerDept });

            this.dgvDepartements.Location = new System.Drawing.Point(10, 100);
            this.dgvDepartements.Size = new System.Drawing.Size(770, 360);
            this.dgvDepartements.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvDepartements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;


            // ---------------- PROJETS TAB ----------------
            this.tabProjets.Location = new System.Drawing.Point(4, 25);
            this.tabProjets.Name = "tabProjets";
            this.tabProjets.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjets.Size = new System.Drawing.Size(792, 471);
            this.tabProjets.Text = "Projets";
            this.tabProjets.UseVisualStyleBackColor = true;

            this.tabProjets.Controls.Add(this.grpSaisieProjet);
            this.tabProjets.Controls.Add(this.dgvProjets);


            this.grpSaisieProjet.Location = new System.Drawing.Point(10, 10);
            this.grpSaisieProjet.Size = new System.Drawing.Size(770, 80);
            this.grpSaisieProjet.Text = "Gestion Projets";

            this.lblProjetNom.Location = new System.Drawing.Point(20, 30); this.lblProjetNom.Text = "Nom:";
            this.lblProjetNom.AutoSize = true;
            this.txtProjetNom.Location = new System.Drawing.Point(80, 27); this.txtProjetNom.Size = new System.Drawing.Size(200, 22);

            this.lblProjetBudget.Location = new System.Drawing.Point(300, 30); this.lblProjetBudget.Text = "Budget:";
            this.lblProjetBudget.AutoSize = true;
            this.txtProjetBudget.Location = new System.Drawing.Point(380, 27); this.txtProjetBudget.Size = new System.Drawing.Size(150, 22);

            this.btnAjouterProjet.Location = new System.Drawing.Point(550, 25); this.btnAjouterProjet.Size = new System.Drawing.Size(100, 30); this.btnAjouterProjet.Text = "Ajouter";
            this.btnAjouterProjet.Click += new System.EventHandler(this.BtnAjouterProjet_Click);

            this.btnListerProjet.Location = new System.Drawing.Point(660, 25); this.btnListerProjet.Size = new System.Drawing.Size(100, 30); this.btnListerProjet.Text = "Lister";
            this.btnListerProjet.Click += new System.EventHandler(this.BtnListerProjet_Click);

            this.grpSaisieProjet.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblProjetNom, this.txtProjetNom, this.lblProjetBudget, this.txtProjetBudget, this.btnAjouterProjet, this.btnListerProjet });

            this.dgvProjets.Location = new System.Drawing.Point(10, 100);
            this.dgvProjets.Size = new System.Drawing.Size(770, 360);
            this.dgvProjets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvProjets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;


            // ---------------- AFFECTATIONS TAB ----------------
            this.tabAffectations.Location = new System.Drawing.Point(4, 25);
            this.tabAffectations.Name = "tabAffectations";
            this.tabAffectations.Padding = new System.Windows.Forms.Padding(3);
            this.tabAffectations.Size = new System.Drawing.Size(792, 471);
            this.tabAffectations.Text = "Affectations";
            this.tabAffectations.UseVisualStyleBackColor = true;

            this.tabAffectations.Controls.Add(this.grpSaisieAff);
            this.tabAffectations.Controls.Add(this.dgvAffectations);


            this.grpSaisieAff.Location = new System.Drawing.Point(10, 10);
            this.grpSaisieAff.Size = new System.Drawing.Size(770, 80);
            this.grpSaisieAff.Text = "Gestion Affectations";

            this.lblAffEmp.Location = new System.Drawing.Point(20, 30); this.lblAffEmp.Text = "Cin Emp:";
            this.lblAffEmp.AutoSize = true;
            this.txtAffEmpCin.Location = new System.Drawing.Point(100, 27); this.txtAffEmpCin.Size = new System.Drawing.Size(150, 22);

            this.lblAffProj.Location = new System.Drawing.Point(260, 30); this.lblAffProj.Text = "Projet ID:";
            this.lblAffProj.AutoSize = true;
            this.txtAffProjetId.Location = new System.Drawing.Point(340, 27); this.txtAffProjetId.Size = new System.Drawing.Size(100, 22);

            this.lblAffHeures.Location = new System.Drawing.Point(450, 30); this.lblAffHeures.Text = "Heures:";
            this.lblAffHeures.AutoSize = true;
            this.txtAffHeures.Location = new System.Drawing.Point(510, 27); this.txtAffHeures.Size = new System.Drawing.Size(70, 22);

            this.btnAjouterAff.Location = new System.Drawing.Point(590, 25); this.btnAjouterAff.Size = new System.Drawing.Size(90, 30); this.btnAjouterAff.Text = "Ajouter";
            this.btnAjouterAff.Click += new System.EventHandler(this.BtnAjouterAff_Click);

            this.btnListerAff.Location = new System.Drawing.Point(670, 25); this.btnListerAff.Size = new System.Drawing.Size(90, 30); this.btnListerAff.Text = "Lister";
            this.btnListerAff.Click += new System.EventHandler(this.BtnListerAff_Click);

            this.grpSaisieAff.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblAffEmp, this.txtAffEmpCin, this.lblAffProj, this.txtAffProjetId, this.lblAffHeures, this.txtAffHeures, this.btnAjouterAff, this.btnListerAff });

            this.dgvAffectations.Location = new System.Drawing.Point(10, 100);
            this.dgvAffectations.Size = new System.Drawing.Size(770, 360);
            this.dgvAffectations.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvAffectations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;


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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartements)).EndInit();

            this.tabProjets.ResumeLayout(false);
            this.grpSaisieProjet.ResumeLayout(false); this.grpSaisieProjet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjets)).EndInit();

            this.tabAffectations.ResumeLayout(false);
            this.grpSaisieAff.ResumeLayout(false); this.grpSaisieAff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAffectations)).EndInit();

            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
