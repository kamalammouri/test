namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI controls
        private System.Windows.Forms.TextBox txtCin;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtTaux;
        private System.Windows.Forms.TextBox txtHeures;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvEmployes;

        // Layout controls
        private System.Windows.Forms.GroupBox grpSaisie;
        private System.Windows.Forms.TableLayoutPanel tblInputs;
        private System.Windows.Forms.Label lblCinLabel;
        private System.Windows.Forms.Label lblNomLabel;
        private System.Windows.Forms.Label lblTauxLabel;
        private System.Windows.Forms.Label lblHeuresLabel;
        private System.Windows.Forms.GroupBox grpActions;
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

        /// <summary>
        /// InitializeComponent - builds a cleaner, responsive layout for the form.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpSaisie = new System.Windows.Forms.GroupBox();
            this.tblInputs = new System.Windows.Forms.TableLayoutPanel();
            this.lblCinLabel = new System.Windows.Forms.Label();
            this.lblNomLabel = new System.Windows.Forms.Label();
            this.lblTauxLabel = new System.Windows.Forms.Label();
            this.lblHeuresLabel = new System.Windows.Forms.Label();

            this.txtCin = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtTaux = new System.Windows.Forms.TextBox();
            this.txtHeures = new System.Windows.Forms.TextBox();

            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();

            this.dgvEmployes = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).BeginInit();
            this.grpSaisie.SuspendLayout();
            this.tblInputs.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpSaisie
            // 
            this.grpSaisie.Controls.Add(this.tblInputs);
            this.grpSaisie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpSaisie.Location = new System.Drawing.Point(16, 16);
            this.grpSaisie.Name = "grpSaisie";
            this.grpSaisie.Size = new System.Drawing.Size(420, 160);
            this.grpSaisie.TabIndex = 0;
            this.grpSaisie.TabStop = false;
            this.grpSaisie.Text = "Informations Employe";

            // 
            // tblInputs
            // 
            this.tblInputs.ColumnCount = 2;
            this.tblInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblInputs.RowCount = 4;
            this.tblInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInputs.Padding = new System.Windows.Forms.Padding(8);

            // Labels
            this.lblCinLabel.Text = "CIN:";
            this.lblCinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCinLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;

            this.lblNomLabel.Text = "Nom:";
            this.lblNomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNomLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;

            this.lblTauxLabel.Text = "Taux Horaire:";
            this.lblTauxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTauxLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;

            this.lblHeuresLabel.Text = "Nb Heures:";
            this.lblHeuresLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeuresLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;

            // Add controls to table
            this.tblInputs.Controls.Add(this.lblCinLabel, 0, 0);
            this.tblInputs.Controls.Add(this.txtCin, 1, 0);
            this.tblInputs.Controls.Add(this.lblNomLabel, 0, 1);
            this.tblInputs.Controls.Add(this.txtNom, 1, 1);
            this.tblInputs.Controls.Add(this.lblTauxLabel, 0, 2);
            this.tblInputs.Controls.Add(this.txtTaux, 1, 2);
            this.tblInputs.Controls.Add(this.lblHeuresLabel, 0, 3);
            this.tblInputs.Controls.Add(this.txtHeures, 1, 3);

            // TextBoxes anchor
            this.txtCin.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNom.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtTaux.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtHeures.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Tooltips
            this.toolTip.SetToolTip(this.txtCin, "Identifiant unique de l'employe");
            this.toolTip.SetToolTip(this.txtTaux, "Taux horaire en currency (ex: 15.50)");
            this.toolTip.SetToolTip(this.txtHeures, "Nombre d'heures travaillees");

            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnAjouter);
            this.grpActions.Controls.Add(this.btnModifier);
            this.grpActions.Controls.Add(this.btnSupprimer);
            this.grpActions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpActions.Location = new System.Drawing.Point(456, 16);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(324, 160);
            this.grpActions.TabIndex = 1;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Actions";

            // Buttons styling and anchors
            this.btnAjouter.Size = new System.Drawing.Size(140, 40);
            this.btnAjouter.Location = new System.Drawing.Point(24, 30);
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAjouter.TabIndex = 10;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAjouter.UseVisualStyleBackColor = true;

            this.btnModifier.Size = new System.Drawing.Size(140, 40);
            this.btnModifier.Location = new System.Drawing.Point(24, 70);
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnModifier.TabIndex = 11;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModifier.UseVisualStyleBackColor = true;

            this.btnSupprimer.Size = new System.Drawing.Size(140, 40);
            this.btnSupprimer.Location = new System.Drawing.Point(24, 110);
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSupprimer.TabIndex = 12;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSupprimer.UseVisualStyleBackColor = true;

            // Wire events (existing handlers in MainForm.cs)
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            this.btnModifier.Click += new System.EventHandler(this.BtnModifier_Click);
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);

            // 
            // dgvEmployes
            // 
            this.dgvEmployes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployes.Location = new System.Drawing.Point(16, 192);
            this.dgvEmployes.Name = "dgvEmployes";
            this.dgvEmployes.Size = new System.Drawing.Size(764, 300);
            this.dgvEmployes.TabIndex = 2;
            this.dgvEmployes.ReadOnly = true;
            this.dgvEmployes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployes.AllowUserToAddRows = false;
            this.dgvEmployes.AllowUserToDeleteRows = false;
            this.dgvEmployes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployes.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvEmployes_CellClick);

            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(16, 504);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Statut: Non connecte";
            this.lblStatus.ForeColor = System.Drawing.Color.Red;

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 540);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpSaisie);
            this.Controls.Add(this.dgvEmployes);
            this.Controls.Add(this.lblStatus);
            this.MinimumSize = new System.Drawing.Size(820, 580);
            this.Name = "MainForm";
            this.Text = "Gestion des Employes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.grpSaisie.ResumeLayout(false);
            this.tblInputs.ResumeLayout(false);
            this.tblInputs.PerformLayout();
            this.grpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
