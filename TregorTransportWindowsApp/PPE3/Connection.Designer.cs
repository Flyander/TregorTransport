namespace PPE3
{
    partial class Connection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connection));
            this.lblIdentifiant = new System.Windows.Forms.Label();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.tbxIdentifiant = new System.Windows.Forms.TextBox();
            this.tbxMotDePasse = new System.Windows.Forms.TextBox();
            this.btnEntrer = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.ckbxAfficher = new System.Windows.Forms.CheckBox();
            this.lblIncorrect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIdentifiant
            // 
            this.lblIdentifiant.AutoSize = true;
            this.lblIdentifiant.BackColor = System.Drawing.Color.Transparent;
            this.lblIdentifiant.ForeColor = System.Drawing.Color.Black;
            this.lblIdentifiant.Location = new System.Drawing.Point(359, 125);
            this.lblIdentifiant.Name = "lblIdentifiant";
            this.lblIdentifiant.Size = new System.Drawing.Size(69, 17);
            this.lblIdentifiant.TabIndex = 0;
            this.lblIdentifiant.Text = "Identifiant";
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.BackColor = System.Drawing.Color.Transparent;
            this.lblMotDePasse.ForeColor = System.Drawing.Color.Black;
            this.lblMotDePasse.Location = new System.Drawing.Point(345, 204);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(94, 17);
            this.lblMotDePasse.TabIndex = 1;
            this.lblMotDePasse.Text = "Mot de Passe";
            // 
            // tbxIdentifiant
            // 
            this.tbxIdentifiant.Location = new System.Drawing.Point(319, 157);
            this.tbxIdentifiant.Name = "tbxIdentifiant";
            this.tbxIdentifiant.Size = new System.Drawing.Size(147, 22);
            this.tbxIdentifiant.TabIndex = 2;
            // 
            // tbxMotDePasse
            // 
            this.tbxMotDePasse.Location = new System.Drawing.Point(319, 245);
            this.tbxMotDePasse.Name = "tbxMotDePasse";
            this.tbxMotDePasse.Size = new System.Drawing.Size(147, 22);
            this.tbxMotDePasse.TabIndex = 3;
            // 
            // btnEntrer
            // 
            this.btnEntrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEntrer.BackgroundImage")));
            this.btnEntrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrer.ForeColor = System.Drawing.Color.White;
            this.btnEntrer.Location = new System.Drawing.Point(276, 335);
            this.btnEntrer.Name = "btnEntrer";
            this.btnEntrer.Size = new System.Drawing.Size(80, 33);
            this.btnEntrer.TabIndex = 5;
            this.btnEntrer.Text = "Entrer";
            this.btnEntrer.UseVisualStyleBackColor = false;
            this.btnEntrer.Click += new System.EventHandler(this.btnEntrer_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitter.BackgroundImage")));
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.ForeColor = System.Drawing.Color.White;
            this.btnQuitter.Location = new System.Drawing.Point(423, 335);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(80, 33);
            this.btnQuitter.TabIndex = 6;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // ckbxAfficher
            // 
            this.ckbxAfficher.AutoSize = true;
            this.ckbxAfficher.BackColor = System.Drawing.Color.Transparent;
            this.ckbxAfficher.ForeColor = System.Drawing.Color.Black;
            this.ckbxAfficher.Location = new System.Drawing.Point(303, 273);
            this.ckbxAfficher.Name = "ckbxAfficher";
            this.ckbxAfficher.Size = new System.Drawing.Size(182, 21);
            this.ckbxAfficher.TabIndex = 7;
            this.ckbxAfficher.Text = "Afficher le mot de passe";
            this.ckbxAfficher.UseVisualStyleBackColor = false;
            this.ckbxAfficher.CheckedChanged += new System.EventHandler(this.ckbxAfficher_CheckedChanged);
            // 
            // lblIncorrect
            // 
            this.lblIncorrect.AutoSize = true;
            this.lblIncorrect.BackColor = System.Drawing.Color.Transparent;
            this.lblIncorrect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblIncorrect.Location = new System.Drawing.Point(273, 81);
            this.lblIncorrect.Name = "lblIncorrect";
            this.lblIncorrect.Size = new System.Drawing.Size(237, 17);
            this.lblIncorrect.TabIndex = 8;
            this.lblIncorrect.Text = "Identifiant ou mot de passe incorrect";
            this.lblIncorrect.Visible = false;
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblIncorrect);
            this.Controls.Add(this.ckbxAfficher);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnEntrer);
            this.Controls.Add(this.tbxMotDePasse);
            this.Controls.Add(this.tbxIdentifiant);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.lblIdentifiant);
            this.Name = "Connection";
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Connection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIdentifiant;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.TextBox tbxIdentifiant;
        private System.Windows.Forms.TextBox tbxMotDePasse;
        private System.Windows.Forms.Button btnEntrer;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.CheckBox ckbxAfficher;
        private System.Windows.Forms.Label lblIncorrect;
    }
}