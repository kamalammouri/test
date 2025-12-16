namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur.
        /// Ne modifiez pas le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSaisie = new System.Windows.Forms.GroupBox();
            this.txtHeures = new System.Windows.Forms.TextBox();
            this.txtTaux = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtCin = new System.Windows.Forms.TextBox();
            this.lblHeures = new System.Windows.Forms.Label();
            this.lblTaux = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblCin = new System.Windows.Forms.Label();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblListe = new System.Windows.Forms.Label();
            this.dgvEmployes = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpSaisie.SuspendLayout();
            this.grpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSaisie
            // 
            this.grpSaisie.Controls.Add(this.txtHeures);
            this.grpSaisie.Controls.Add(this.txtTaux);
            this.grpSaisie.Controls.Add(this.txtNom);
            this.grpSaisie.Controls.Add(this.txtCin);
            this.grpSaisie.Controls.Add(this.lblHeures);
            this.grpSaisie.Controls.Add(this.lblTaux);
            this.grpSaisie.Controls.Add(this.lblNom);
            this.grpSaisie.Controls.Add(this.lblCin);
            this.grpSaisie.Location = new System.Drawing.Point(20, 50);
            this.grpSaisie.Name = "grpSaisie";
            this.grpSaisie.Size = new System.Drawing.Size(380, 180);
            this.grpSaisie.TabIndex = 0;
            this.grpSaisie.TabStop = false;
            this.grpSaisie.Text = "Informations Employé";
            // 
            // txtHeures
            // 
            this.txtHeures.Location = new System.Drawing.Point(140, 132);
            this.txtHeures.Name = "txtHeures";
            this.txtHeures.Size = new System.Drawing.Size(200, 22);
            this.txtHeures.TabIndex = 7;
            // 
            // txtTaux
            // 
            this.txtTaux.Location = new System.Drawing.Point(140, 97);
            this.txtTaux.Name = "txtTaux";
            this.txtTaux.Size = new System.Drawing.Size(200, 22);
            this.txtTaux.TabIndex = 6;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(140, 62);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 22);
            this.txtNom.TabIndex = 5;
            // 
            // txtCin
            // 
            this.txtCin.Location = new System.Drawing.Point(140, 27);
            this.txtCin.Name = "txtCin";
            this.txtCin.Size = new System.Drawing.Size(200, 22);
            this.txtCin.TabIndex = 4;
            // 
            // lblHeures
            // 
            this.lblHeures.AutoSize = true;
            this.lblHeures.Location = new System.Drawing.Point(15, 135);
            this.lblHeures.Name = "lblHeures";
            this.lblHeures.Size = new System.Drawing.Size(119, 16);
            this.lblHeures.TabIndex = 3;
            this.lblHeures.Text = "Nombre d\'Heures:";
            // 
            // lblTaux
            // 
            this.lblTaux.AutoSize = true;
            this.lblTaux.Location = new System.Drawing.Point(15, 100);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(89, 16);
            this.lblTaux.TabIndex = 2;
            this.lblTaux.Text = "Taux Horaire:";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(15, 65);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(39, 16);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Nom:";
            // 
            // lblCin
            // 
            this.lblCin.AutoSize = true;
            this.lblCin.Location = new System.Drawing.Point(15, 30);
            this.lblCin.Name = "lblCin";
            this.lblCin.Size = new System.Drawing.Size(33, 16);
            this.lblCin.TabIndex = 0;
            this.lblCin.Text = "CIN:";
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnSupprimer);
            this.grpActions.Controls.Add(this.btnModifier);
            this.grpActions.Controls.Add(this.btnAjouter);
            this.grpActions.Location = new System.Drawing.Point(420, 50);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(360, 100);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.LightCoral;
            this.btnSupprimer.Location = new System.Drawing.Point(240, 35);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(100, 40);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.LightBlue;
            this.btnModifier.Location = new System.Drawing.Point(130, 35);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(100, 40);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.BtnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.LightGreen;
            this.btnAjouter.Location = new System.Drawing.Point(20, 35);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(100, 40);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(180, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(461, 29);
            this.lblTitre.TabIndex = 2;
            this.lblTitre.Text = "GESTION DES EMPLOYÉS - 3-Tiers";
            // 
            // lblListe
            // 
            this.lblListe.AutoSize = true;
            this.lblListe.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblListe.Location = new System.Drawing.Point(20, 240);
            this.lblListe.Name = "lblListe";
            this.lblListe.Size = new System.Drawing.Size(172, 19);
            this.lblListe.TabIndex = 3;
            this.lblListe.Text = "Liste des Employés:";
            // 
            // dgvEmployes
            // 
            this.dgvEmployes.AllowUserToAddRows = false;
            this.dgvEmployes.AllowUserToDeleteRows = false;
            this.dgvEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployes.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvEmployes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployes.Location = new System.Drawing.Point(20, 265);
            this.dgvEmployes.Name = "dgvEmployes";
            this.dgvEmployes.ReadOnly = true;
            this.dgvEmployes.RowHeadersWidth = 51;
            this.dgvEmployes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployes.Size = new System.Drawing.Size(760, 230);
            this.dgvEmployes.TabIndex = 4;
            this.dgvEmployes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmployes_CellClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(20, 505);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(138, 18);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Statut: Non connecté";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvEmployes);
            this.Controls.Add(this.lblListe);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpSaisie);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Employés - Client 3-Tiers";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpSaisie.ResumeLayout(false);
            this.grpSaisie.PerformLayout();
            this.grpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpSaisie;
        private System.Windows.Forms.TextBox txtHeures;
        private System.Windows.Forms.TextBox txtTaux;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtCin;
        private System.Windows.Forms.Label lblHeures;
        private System.Windows.Forms.Label lblTaux;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblCin;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblListe;
        private System.Windows.Forms.DataGridView dgvEmployes;
        private System.Windows.Forms.Label lblStatus;
    }
}
