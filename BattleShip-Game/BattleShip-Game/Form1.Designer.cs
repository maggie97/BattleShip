namespace BattleShip_Game
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBarco1 = new System.Windows.Forms.Button();
            this.btnBarco3 = new System.Windows.Forms.Button();
            this.btnBarco5 = new System.Windows.Forms.Button();
            this.chBHorizontal = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 442);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(509, 267);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(199, 187);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.Location = new System.Drawing.Point(527, 36);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(42, 18);
            this.lblTurn.TabIndex = 13;
            this.lblTurn.Text = "Turno";
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpezar.Location = new System.Drawing.Point(568, 217);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(93, 31);
            this.btnEmpezar.TabIndex = 12;
            this.btnEmpezar.Text = "Empezar";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(549, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Barcos :";
            // 
            // btnBarco1
            // 
            this.btnBarco1.Image = global::BattleShip_Game.Properties.Resources.Barco3;
            this.btnBarco1.Location = new System.Drawing.Point(635, 118);
            this.btnBarco1.Name = "btnBarco1";
            this.btnBarco1.Size = new System.Drawing.Size(44, 61);
            this.btnBarco1.TabIndex = 10;
            this.btnBarco1.UseVisualStyleBackColor = true;
            this.btnBarco1.Click += new System.EventHandler(this.btnBarco1_Click);
            // 
            // btnBarco3
            // 
            this.btnBarco3.Image = global::BattleShip_Game.Properties.Resources.Barco2;
            this.btnBarco3.Location = new System.Drawing.Point(585, 118);
            this.btnBarco3.Name = "btnBarco3";
            this.btnBarco3.Size = new System.Drawing.Size(44, 61);
            this.btnBarco3.TabIndex = 9;
            this.btnBarco3.UseVisualStyleBackColor = true;
            this.btnBarco3.Click += new System.EventHandler(this.btnBarco3_Click);
            // 
            // btnBarco5
            // 
            this.btnBarco5.Image = global::BattleShip_Game.Properties.Resources.Barco1;
            this.btnBarco5.Location = new System.Drawing.Point(536, 118);
            this.btnBarco5.Name = "btnBarco5";
            this.btnBarco5.Size = new System.Drawing.Size(43, 61);
            this.btnBarco5.TabIndex = 8;
            this.btnBarco5.UseVisualStyleBackColor = true;
            this.btnBarco5.Click += new System.EventHandler(this.btnBarco5_Click);
            // 
            // chBHorizontal
            // 
            this.chBHorizontal.AutoSize = true;
            this.chBHorizontal.Location = new System.Drawing.Point(568, 185);
            this.chBHorizontal.Name = "chBHorizontal";
            this.chBHorizontal.Size = new System.Drawing.Size(73, 17);
            this.chBHorizontal.TabIndex = 14;
            this.chBHorizontal.Text = "Horizontal";
            this.chBHorizontal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(527, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Jugador :";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(595, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(48, 18);
            this.lbName.TabIndex = 16;
            this.lbName.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chBHorizontal);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.btnEmpezar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBarco1);
            this.Controls.Add(this.btnBarco3);
            this.Controls.Add(this.btnBarco5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "BattleShip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBarco1;
        private System.Windows.Forms.Button btnBarco3;
        private System.Windows.Forms.Button btnBarco5;
        private System.Windows.Forms.CheckBox chBHorizontal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbName;
    }
}

