using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timbiriche
{
    public partial class Form1 : Form
    {
        private Rectangle[,] R1 = new Rectangle[15, 15];
        public static Cuadro[,] cuadricula = new Cuadro[15, 15];
        private Size tam = new Size(50, 50); // modificar con el tam de la form (algun dia)
        public Form1()
        {
            InitializeComponent();
            #region
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (j % 2 == 0 && i % 2 == 0)
                    {
                        cuadricula[i, j] = new Cuadro(Color.Black, new Point((i/2) * 10 + (i / 2) * 50, j/2 * 10 + (j / 2) * 50), new Size(10, 10));
                        R1[i, j] = new Rectangle(i/2 * 10 + (i / 2) * 50, j/2 * 10 + (j / 2) * 50, 10, 10);
                    }
                    else if (j % 2 == 0 && i % 2 != 0)
                    {
                        cuadricula[i, j] = new Cuadro(Color.White, new Point((i + 1) / 2 * 10 + i / 2 * 50, j / 2 * 10 + (j / 2) * 50), new Size(50, 10));
                        R1[i, j] = new Rectangle((i+1) / 2 * 10 + i /2 * 50, j / 2 * 10 + (j / 2) * 50, 50, 10);
                    }
                    else if (i % 2 == 0 && j % 2 != 0)
                    {
                        cuadricula[i, j] = new Cuadro(Color.White, new Point(i / 2 * 10 + (i / 2) * 50, (j + 1) / 2 * 10 + j / 2 * 50), new Size(10, 50));
                        R1[i, j] = new Rectangle(i / 2 * 10 + (i / 2) * 50, (j + 1) / 2 * 10 + j / 2 * 50, 10, 50);
                    }
                    else
                    {
                        cuadricula[i, j] = new Cuadro(Color.Gray, new Point((i+1)/2 * 10 + (i / 2) * 50, (j+1) / 2 * 10 + j /2 * 50), tam);
                        R1[i, j] = new Rectangle((i + 1) / 2 * 10 + (i / 2) * 50, (j + 1) / 2 * 10 + j / 2 * 50, 50, 50);
                    }
                }
            #endregion
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cuadro x in cuadricula)
                e.Graphics.FillRectangle(new SolidBrush(x.C), x.P.X, x.P.Y, x.S.Width, x.S.Height);
            foreach (Rectangle r in R1)
                e.Graphics.DrawRectangle(new Pen(Color.Black), r);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (e.X > cuadricula[i, j].P.X && e.X < cuadricula[i, j].P.X + cuadricula[i, j].S.Width 
                        && e.Y > cuadricula[i, j].P.Y && e.Y < cuadricula[i, j].P.Y + cuadricula[i, j].S.Height )
                    {
                        if(i%2 == 0 || j%2 == 0)
                            cuadricula[i, j].C = Color.Red;
                        if (cuadricula[i, j].Barco)
                            cuadricula[i, j].C = Color.Gray;
                        break;
                    }
                }
            panel1.Invalidate();
        }
    }
}
