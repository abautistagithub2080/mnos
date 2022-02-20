namespace _01_SP_BG
{
    partial class Form4
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.cbxContacto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomCorto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTele = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(36, 433);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(460, 433);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(123, 40);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // cbxContacto
            // 
            this.cbxContacto.FormattingEnabled = true;
            this.cbxContacto.Location = new System.Drawing.Point(36, 26);
            this.cbxContacto.Name = "cbxContacto";
            this.cbxContacto.Size = new System.Drawing.Size(238, 21);
            this.cbxContacto.TabIndex = 2;
            this.cbxContacto.SelectedIndexChanged += new System.EventHandler(this.cbxContacto_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre Corto";
            // 
            // txtNomCorto
            // 
            this.txtNomCorto.Location = new System.Drawing.Point(36, 79);
            this.txtNomCorto.Name = "txtNomCorto";
            this.txtNomCorto.Size = new System.Drawing.Size(238, 20);
            this.txtNomCorto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nombre";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(36, 133);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(235, 20);
            this.txtNom.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Paterno";
            // 
            // txtPat
            // 
            this.txtPat.Location = new System.Drawing.Point(36, 188);
            this.txtPat.Name = "txtPat";
            this.txtPat.Size = new System.Drawing.Size(232, 20);
            this.txtPat.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Materno";
            // 
            // txtMat
            // 
            this.txtMat.Location = new System.Drawing.Point(36, 245);
            this.txtMat.Name = "txtMat";
            this.txtMat.Size = new System.Drawing.Size(229, 20);
            this.txtMat.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Correo Electronico";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(354, 79);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(229, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Telefono";
            // 
            // txtTele
            // 
            this.txtTele.Location = new System.Drawing.Point(354, 133);
            this.txtTele.Name = "txtTele";
            this.txtTele.Size = new System.Drawing.Size(229, 20);
            this.txtTele.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Celular";
            // 
            // txtCel
            // 
            this.txtCel.Location = new System.Drawing.Point(354, 188);
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(229, 20);
            this.txtCel.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Descripcción";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(36, 299);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDesc.Size = new System.Drawing.Size(547, 106);
            this.txtDesc.TabIndex = 18;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 498);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTele);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomCorto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxContacto);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSave);
            this.Name = "Form4";
            this.Text = "Form4";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.Resize += new System.EventHandler(this.Form4_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.ComboBox cbxContacto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomCorto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTele;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesc;
    }
}