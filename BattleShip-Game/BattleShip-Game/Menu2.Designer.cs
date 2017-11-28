namespace BattleShip_Game
{
    partial class Menu2
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
            this.Player = new System.Windows.Forms.TextBox();
            this.Jugar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingresa tu nombre: ";
            // 
            // Player
            // 
            this.Player.Location = new System.Drawing.Point(353, 207);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(100, 20);
            this.Player.TabIndex = 1;
            // 
            // Jugar
            // 
            this.Jugar.BackColor = System.Drawing.Color.LightBlue;
            this.Jugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Jugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugar.Location = new System.Drawing.Point(333, 355);
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(75, 31);
            this.Jugar.TabIndex = 2;
            this.Jugar.Text = "Jugar";
            this.Jugar.UseVisualStyleBackColor = false;
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // Menu2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleShip_Game.Properties.Resources.BATTLESHIP;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.Jugar);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Menu2";
            this.Text = "BattleShip";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Player;
        private System.Windows.Forms.Button Jugar;
    }
}