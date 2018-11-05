namespace Proyecto_final_de_Facturacion
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsariotextBox = new System.Windows.Forms.TextBox();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.CancelarTextBox = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "password";
            // 
            // UsariotextBox
            // 
            this.UsariotextBox.Location = new System.Drawing.Point(113, 164);
            this.UsariotextBox.Name = "UsariotextBox";
            this.UsariotextBox.Size = new System.Drawing.Size(274, 22);
            this.UsariotextBox.TabIndex = 3;
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(113, 217);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.PasswordChar = '*';
            this.PasswordtextBox.Size = new System.Drawing.Size(274, 22);
            this.PasswordtextBox.TabIndex = 4;
            this.PasswordtextBox.UseSystemPasswordChar = true;
            // 
            // CancelarTextBox
            // 
            this.CancelarTextBox.Image = global::Proyecto_final_de_Facturacion.Properties.Resources.error;
            this.CancelarTextBox.Location = new System.Drawing.Point(257, 272);
            this.CancelarTextBox.Name = "CancelarTextBox";
            this.CancelarTextBox.Size = new System.Drawing.Size(83, 65);
            this.CancelarTextBox.TabIndex = 6;
            this.CancelarTextBox.Text = "Cancelar";
            this.CancelarTextBox.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CancelarTextBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::Proyecto_final_de_Facturacion.Properties.Resources.entrar;
            this.button1.Location = new System.Drawing.Point(113, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 65);
            this.button1.TabIndex = 5;
            this.button1.Text = "Login";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto_final_de_Facturacion.Properties.Resources.usuario_registrados;
            this.pictureBox1.Location = new System.Drawing.Point(173, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(433, 349);
            this.Controls.Add(this.CancelarTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordtextBox);
            this.Controls.Add(this.UsariotextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsariotextBox;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CancelarTextBox;
    }
}

