using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Game
{
    public partial class Form1 : Form
    {
        int n=0;
        //private RectangleF[,] R = new RectangleF[8, 8];
        private RectangleF[] R1 = new RectangleF[64];
        //private Point[,]rectangles = new Point[8,8];
        private RectangleF[] R2 = new RectangleF[64];
        public static Cuadro[,] areaEnemiga = new Cuadro[8, 8];
        public static Cuadro[,] areaPropia = new Cuadro[8, 8];
        bool Barco1, Barco3, Barco5, Empezar;
        private Size tam = new Size(50, 50);
        public Form1(string nombre)
        {
            InitializeComponent();
            lbName.Text = nombre;
            Barco1 = Barco3 = Barco5 = Empezar = false;
            #region

            /*for (int i = 0; i < 8; i++)
                rectangles
            /*for (int i = 1; i < 8;i ++)
                R1[i] = new RectangleF(i*50 , 0, 50, 50*/
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    areaEnemiga[i, j] = new Cuadro(Color.FromArgb(20, 120, 200), new Point(i * 50, j * 50), tam);
                    areaPropia[i, j] = new Cuadro(Color.FromArgb(50,70, 200), new Point(i * 20, j * 20), new Size(20,20));
                    //rectangles[i, j] = new Point(i * 50, j * 50);
                    R1[n] = new RectangleF(i * 50, j * 50, 50, 50);
                    R2[n] = new RectangleF(i * 20, j * 20, 20, 20);
                    //R[i, j] = new RectangleF(i * 50, j * 50, 50, 50);
                    n++;
                }
            #endregion
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cuadro x in areaEnemiga)
                e.Graphics.FillRectangle(new SolidBrush(x.C), x.P.X, x.P.Y, x.S.Width, x.S.Height);
            e.Graphics.DrawRectangles(new Pen(Color.Black), R1);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cuadro x in areaPropia)
                e.Graphics.FillRectangle(new SolidBrush(x.C), x.P.X, x.P.Y, x.S.Width, x.S.Height);
            e.Graphics.DrawRectangles(new Pen(Color.Black), R2);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (e.X > areaEnemiga[i, j].P.X && e.X < areaEnemiga[i , j ].P.X + areaEnemiga[i, j].S.Width && e.Y > areaEnemiga[i, j].P.Y && e.Y < areaEnemiga[i, j].P.Y + areaEnemiga[i, j].S.Height)
                    {
                        areaEnemiga[i, j].C = Color.Red;
                        if(areaEnemiga[i, j].Barco)
                            areaEnemiga[i, j].C = Color.Gray;
                        break;
                    }
                }
            panel1.Invalidate();
        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            Empezar = true;
            btnBarco1.Visible = false;
            btnBarco3.Visible = false;
            btnBarco5.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBarco5_Click(object sender, EventArgs e) { Barco5 = true; }

        private void btnBarco1_Click(object sender, EventArgs e) { Barco1 = true; }

        private void btnBarco3_Click(object sender, EventArgs e) { Barco3 = true; }
    }
}
