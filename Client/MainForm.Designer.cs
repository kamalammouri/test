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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCin = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtTaux = new System.Windows.Forms.TextBox();
            this.txtHeures = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.dgvEmployes = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCin
            // 
            this.txtCin.Location = new System.Drawing.Point(140, 27);
            this.txtCin.Name = "txtCin";
            this.txtCin.Size = new System.Drawing.Size(200, 22);
            this.txtCin.TabIndex = 0;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(140, 62);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 22);
            this.txtNom.TabIndex = 1;
            // 
            // txtTaux
            // 
            this.txtTaux.Location = new System.Drawing.Point(140, 97);
            this.txtTaux.Name = "txtTaux";
            this.txtTaux.Size = new System.Drawing.Size(200, 22);
            this.txtTaux.TabIndex = 2;
            // 
            // txtHeures
            // 
            this.txtHeures.Location = new System.Drawing.Point(140, 132);
            this.txtHeures.Name = "txtHeures";
            this.txtHeures.Size = new System.Drawing.Size(200, 22);
            this.txtHeures.TabIndex = 3;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(420 + 20, 90);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(100, 40);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.BtnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(420 + 130, 90);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(100, 40);
            this.btnModifier.TabIndex = 5;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.BtnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(420 + 240, 90);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(100, 40);
            this.btnSupprimer.TabIndex = 6;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.BtnSupprimer_Click);
            // 
            // dgvEmployes
            // 
            this.dgvEmployes.Location = new System.Drawing.Point(20, 265);
            this.dgvEmployes.Name = "dgvEmployes";
            this.dgvEmployes.Size = new System.Drawing.Size(760, 230);
            this.dgvEmployes.TabIndex = 7;
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
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 505);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 17);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Statut: Non connecte";
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvEmployes);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtHeures);
            this.Controls.Add(this.txtTaux);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtCin);
            this.Name = "MainForm";
            this.Text = "Gestion des Employes - Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
