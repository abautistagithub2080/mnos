namespace _01_SP_BG
{
    partial class Form6
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFiles = new System.Windows.Forms.ComboBox();
            this.txtNomFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxManager = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnDevSource = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 51);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxFiles
            // 
            this.cbxFiles.FormattingEnabled = true;
            this.cbxFiles.Location = new System.Drawing.Point(118, 23);
            this.cbxFiles.Name = "cbxFiles";
            this.cbxFiles.Size = new System.Drawing.Size(297, 21);
            this.cbxFiles.TabIndex = 2;
            this.cbxFiles.SelectedIndexChanged += new System.EventHandler(this.cbxFiles_SelectedIndexChanged);
            // 
            // txtNomFile
            // 
            this.txtNomFile.Location = new System.Drawing.Point(118, 55);
            this.txtNomFile.Name = "txtNomFile";
            this.txtNomFile.Size = new System.Drawing.Size(297, 20);
            this.txtNomFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tema Manager:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxManager
            // 
            this.cbxManager.FormattingEnabled = true;
            this.cbxManager.Location = new System.Drawing.Point(118, 93);
            this.cbxManager.Name = "cbxManager";
            this.cbxManager.Size = new System.Drawing.Size(297, 21);
            this.cbxManager.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(33, 197);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(382, 76);
            this.txtDesc.TabIndex = 7;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(171, 319);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(107, 51);
            this.btnWrite.TabIndex = 8;
            this.btnWrite.Text = "Escribir";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(297, 319);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(110, 51);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "Borrar";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ruta:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(118, 134);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(253, 20);
            this.txtRuta.TabIndex = 11;
            // 
            // btnDevSource
            // 
            this.btnDevSource.Location = new System.Drawing.Point(376, 132);
            this.btnDevSource.Name = "btnDevSource";
            this.btnDevSource.Size = new System.Drawing.Size(39, 23);
            this.btnDevSource.TabIndex = 12;
            this.btnDevSource.Text = "...";
            this.btnDevSource.UseVisualStyleBackColor = true;
            this.btnDevSource.Click += new System.EventHandler(this.btnDevSource_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 398);
            this.Controls.Add(this.btnDevSource);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxManager);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomFile);
            this.Controls.Add(this.cbxFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "Form6";
            this.Text = "Form6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            this.Resize += new System.EventHandler(this.Form6_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFiles;
        private System.Windows.Forms.TextBox txtNomFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxManager;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnDevSource;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}