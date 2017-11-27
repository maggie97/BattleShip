namespace timbiriche
{
    partial class Principal
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
            this.buttonJugar = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Colors = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(89, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 109);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timbiriche";
            // 
            // buttonJugar
            // 
            this.buttonJugar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonJugar.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJugar.Location = new System.Drawing.Point(267, 394);
            this.buttonJugar.Name = "buttonJugar";
            this.buttonJugar.Size = new System.Drawing.Size(147, 65);
            this.buttonJugar.TabIndex = 1;
            this.buttonJugar.Text = "Jugar";
            this.buttonJugar.UseVisualStyleBackColor = false;
            this.buttonJugar.Click += new System.EventHandler(this.buttonJugar_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.labelName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(174, 254);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(109, 26);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Nombre :";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.labelColor.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelColor.ForeColor = System.Drawing.Color.White;
            this.labelColor.Location = new System.Drawing.Point(205, 299);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(85, 26);
            this.labelColor.TabIndex = 3;
            this.labelColor.Text = "Color :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(311, 260);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(137, 20);
            this.txtName.TabIndex = 4;
            // 
            // Colors
            // 
            this.Colors.FormattingEnabled = true;
            this.Colors.Items.AddRange(new object[] {
            "Rojo",
            "Azul",
            "Amarillo"});
            this.Colors.Location = new System.Drawing.Point(311, 299);
            this.Colors.Name = "Colors";
            this.Colors.Size = new System.Drawing.Size(121, 21);
            this.Colors.TabIndex = 6;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::timbiriche.Properties.Resources.timbiriche3;
            this.ClientSize = new System.Drawing.Size(674, 471);
            this.Controls.Add(this.Colors);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonJugar);
            this.Controls.Add(this.label1);
            this.Name = "Principal";
            this.Text = "Principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonJugar;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox Colors;
    }
}