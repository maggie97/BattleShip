using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Media;

namespace BattleShips
{
    public partial class Form1 : Form 
    {
        #region PanelesDefinicion
        int n=0;
        //private RectangleF[,] R = new RectangleF[8, 8];
        private RectangleF[] R1 = new RectangleF[64];
        //private Point[,]rectangles = new Point[8,8];
        private RectangleF[] R2 = new RectangleF[64];
        public static Cuadro[,] areaEnemiga = new Cuadro[8, 8];
        public static Cuadro[,] areaPropia = new Cuadro[8, 8];
        #endregion
        #region Inicializa variables Sockets
        private delegate void DAddItem(String s);
        static private string name = "unknow";
        static private NetworkStream stream;
        static private StreamReader streamR;
        static private StreamWriter streamW;
        static private TcpClient client = new TcpClient();

        private IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);
        private IPAddress ipAddr;
        private IPHostEntry ipHost;
        #endregion
        bool Barco1, Barco3, Barco5, bGanaste = true, bPerdiste = false;
        public bool Empezar, bClick, capturaB, enlace = false;
        int b1, b3, b5;
        public string barcos = " Barcos :", clickString = "click = " ;
        private Size tam = new Size(50, 50);
        public Point clickMouse;
        public static bool myTurn = true;
        private System.Windows.Forms.Timer t;
        Explosion exp;

        SoundPlayer player;

        public Form1(string nom)
        {
            //name = "Player " + Convert.ToInt16(nom) + 1;
            name = nom;
            IntentaConexion();
            InitializeComponent();
            Barco1 = Barco3 = Barco5 = capturaB = Empezar = bClick = false;
            b1 = b3 = 2; b5 = 1;
            clickMouse = new Point();
            #region

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    areaEnemiga[i, j] = new Cuadro(Color.FromArgb(20, 120, 200), new Point(i * 50, j * 50), tam);
                    areaPropia[i, j] = new Cuadro(Color.FromArgb(50,70, 200), new Point(i * 20, j * 20), new Size(20,20));
                    
                    R1[n] = new RectangleF(i * 50, j * 50, 50, 50);
                    R2[n] = new RectangleF(i * 20, j * 20, 20, 20);
                    n++;
                }
            #endregion
            t = new System.Windows.Forms.Timer();
            t.Interval = (int)((1.0 / 60.0) * 1000.0);
            t.Tick += t_Tick;
            t.Start();
            exp = new Explosion();
        }
        #region Visualizacion
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            foreach (Cuadro x in areaEnemiga)
                e.Graphics.FillRectangle(new SolidBrush(x.C), x.P.X, x.P.Y, x.S.Width, x.S.Height);
            foreach (Cuadro x in areaEnemiga)
                e.Graphics.DrawImage(x.ship.frameActual, x.P.X, x.P.Y);
            e.Graphics.DrawRectangles(new Pen(Color.Black), R1);
            e.Graphics.DrawImage(exp.frameActual, clickMouse.X, clickMouse.Y);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (Cuadro x in areaPropia)
            {
                e.Graphics.FillRectangle(new SolidBrush(x.C), x.P.X, x.P.Y, x.S.Width, x.S.Height);
                if (x.Barco)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Cyan), x.P.X, x.P.Y, x.S.Width, x.S.Height);
                }
            }
        
            e.Graphics.DrawRectangles(new Pen(Color.Black), R2);
        }

        void t_Tick(object sender, EventArgs e)
        {
            exp.Update();
            //panel1.Invalidate(new Region(new Rectangle(clickMouse, 
            if(exp.act == exp.explosion && exp.cambio)
                panel1.Invalidate();
            bClick = false;
        }
        private void BarcoT3(int i, int j)
        {
            if (chBHorizontal.Checked)
            {
                for (int a = 0; a < 5; a++)
                {
                    if (i + a >= 8) { i--; }//+= (i+a)-9; }
                    if (areaEnemiga[i + a, j].C == Color.DarkBlue)
                    {
                        MessageBox.Show("Empalme de barcos");
                        return;
                    }
                }
                for (int a = 0; a < 5; a++)
                {
                    areaEnemiga[i + a, j].C = Color.DarkBlue;
                    areaEnemiga[i + a, j].ship.Load(3, a, true);
                }
            }
            else
            {
                for (int a = 0; a < 5; a++)
                {
                    if (j + a >= 8) { j--; }//+= (i+a)-9; }
                    if (areaEnemiga[i , j + a].C == Color.DarkBlue)
                    {
                        MessageBox.Show("Empalme de barcos");
                        return;
                    }
                }
                for (int a = 0; a < 5; a++)
                {
                    areaEnemiga[i, j + a].C = Color.DarkBlue;
                    areaEnemiga[i, j + a].ship.Load(3, a, false);
                }
            }
            Barco5 = false;
            b5--;
        }
        private void BarcoT2(int i, int j)
        {
            if (chBHorizontal.Checked)
            {
                for (int a = 0; a < 3; a++)
                {
                    if (i + a >= 8) { i--; }//+= (i+a)-9; }
                    if (areaEnemiga[i + a, j].C == Color.DarkBlue)
                    {
                        MessageBox.Show("Empalme de barcos");
                        return;
                    }
                }
                for (int a = 0; a < 3; a++)
                {
                    areaEnemiga[i + a, j].C = Color.DarkBlue;
                    areaEnemiga[i + a, j].ship.Load(2, a, true);
                }
            }
            else
            {
                for (int a = 0; a < 3; a++)
                {
                    if (j + a >= 8) { j--; }//+= (i+a)-9; }
                    if (areaEnemiga[i , j + a].C == Color.DarkBlue)
                    {
                        MessageBox.Show("Empalme de barcos");
                        return;
                    }
                }
                for (int a = 0; a < 3; a++)
                {
                    areaEnemiga[i, j + a].C = Color.DarkBlue;
                    areaEnemiga[i, j + a].ship.Load(2, a, false);
                }
            }
            
            Barco3 = false;
            b3--;
        }
        private void BarcoT1(int i, int j)
        {
            areaEnemiga[i, j].C = Color.DarkBlue;
            areaEnemiga[i, j].ship.Load(1, 1, chBHorizontal.Checked);
            Barco1 = false;
            b1--;
        }
        #endregion

        private void music()
        {
            player = new SoundPlayer(@"Musica\Mar.wav");
            player.Play();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (myTurn)
                    {
                        if (e.X > areaEnemiga[i, j].P.X && e.X < areaEnemiga[i, j].P.X + areaEnemiga[i, j].S.Width && e.Y > areaEnemiga[i, j].P.Y && e.Y < areaEnemiga[i, j].P.Y + areaEnemiga[i, j].S.Height)
                        {
                            if (Empezar)
                            {
                                clickAtaque(i, j);
                                
                            }
                            else
                            {
                                if (Barco1 && b1 > 0)
                                {
                                    BarcoT1(i, j);
                                }
                                else if (Barco3 && b3 > 0)
                                {
                                    BarcoT2(i, j);
                                }
                                else if (Barco5 && b5 > 0)
                                {
                                    BarcoT3(i, j);
                                }
                                CheckBtn();
                            }
                            bClick = true;
                            break;
                        }
                    }
                }
            panel2.Invalidate();
            panel1.Invalidate();
        }
       
        private void clickAtaque(int i, int j)
        {
            areaEnemiga[i, j].C = Color.Beige;
            if (areaEnemiga[i, j].Barco)
            {
                areaEnemiga[i, j].C = Color.Red;
                areaEnemiga[i, j].ship.Ataque(); // cambio por barco morido
            }
            else
                areaEnemiga[i, j].ship.AtaqueAgua();
            clickMouse = areaEnemiga[i, j].P;
            exp.Explota();

            clickString += "X=" + i + "Y=" + j;
            SendClick();
            myTurn = false;
            lblTurn.Text = "Turno Enemigo";
            //bClick = true;
        }
        private void chBHorizontal_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region Cliente
        public void LimpiaClick()
        {
            clickString = "click = ";
            Ganaste();
            
        }

        public void click(int x, int y)
        {
            //clickMouse = new Point(x, y);
            if(areaPropia[x, y].Barco)
                areaPropia[x, y].C = Color.Red;
            else
                areaPropia[x, y].C = Color.Pink;
            panel2.Invalidate();
        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            if (b1 == 0 && b5 == 0 && b3 == 0)
            {
                music();
                Empezar = true;
                btnBarco1.Visible = false;
                btnBarco3.Visible = false;
                btnBarco5.Visible = false;
                btnEmpezar.Visible = false;
                label1.Visible = false;
                chBHorizontal.Visible = false;
                myTurn = true;

                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (areaEnemiga[i, j].C == Color.DarkBlue)
                        {
                            areaPropia[i, j].Barco = true;
                            areaEnemiga[i, j].C = Color.FromArgb(20, 120, 200);
                            barcos += "X=" + i + " Y=" + j + " TB=" + areaEnemiga[i, j].ship.Tipo + " id="+ areaEnemiga[i, j].ship.IdB + ";";
                            areaEnemiga[i, j].ship.Load(0);
                        }
                    }
                //panel1.Enabled = false;
                SendBarcos();
                myTurn = false;
                lblTurn.Text = "Turno Enemigo";
                panel2.Invalidate();
                panel1.Invalidate();
            }
            else
            {
                MessageBox.Show("Termina de Acomodar tus Barcos!");
            }
        }
        public void Decodificar(String s)
        {
            int f = s.LastIndexOf(":") + 1;
            string nueva = s.Remove(0, f);
            f = nueva.IndexOf(";") + 1 ;
            if (s.Contains(name)) { return; }
            for (int i = 0; i < 13; i++)
            {
                if (s.Contains("X="))
                {
                    int x = Convert.ToInt16(nueva.Substring(nueva.IndexOf("X=") + 2 , 1)),
                        y = Convert.ToInt16(nueva.Substring(nueva.IndexOf("Y=") + 2 , 1)),
                        tipo = Convert.ToInt16(nueva.Substring(nueva.IndexOf("TB=") + 3, 1)),
                        id = Convert.ToInt16(nueva.Substring(nueva.IndexOf("id=") + 3, 1));
                    areaEnemiga[x, y].Barco = true;
                    areaEnemiga[x, y].ship.IdB = id;
                    areaEnemiga[x, y].ship.Tipo = tipo;
                    nueva = nueva.Remove(0, f) ;
                    f = nueva.IndexOf(";")+1;
                }
            }
            myTurn = true;
            lblTurn.Text = "Mi Turno";
            panel1.Enabled = true;    
        }

        private void btnBarco5_Click(object sender, EventArgs e){ Barco5 = true; }

        private void btnBarco1_Click(object sender, EventArgs e) { Barco1 = true;  }

        private void btnBarco3_Click(object sender, EventArgs e){ Barco3 = true; }
        
        private void Ganaste()
        {
            //if (!enlace) { Ganaste(); return; }
            bGanaste = true;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (areaEnemiga[i, j].Barco && areaEnemiga[i, j].C != Color.Red)
                    {
                        bGanaste = false;
                        break;
                    }
                }
            if (bGanaste)
            {
                panel1.Invalidate();
                MessageBox.Show("Ganaste");
                Application.Exit();
            }
        }
        private void Perdiste()
        {
            //if (!enlace) { Ganaste(); return; }
            bPerdiste = true;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (areaPropia[i, j].Barco && areaPropia[i, j].C != Color.Red)
                    {
                        bPerdiste = false;
                        break;
                    }
                }
            if (bPerdiste)
            {
                panel1.Invalidate();
                MessageBox.Show("Haz Perdido");
                Application.Exit();
            }
        }
        private void CheckBtn()
        {
            if (b5 <= 0) btnBarco5.Enabled = false;
            if (b1 <= 0) btnBarco1.Enabled = false;
            if (b3 <= 0) btnBarco3.Enabled = false;
        }
        
        public Point Valores()
        {
            Point p = new Point();
            return p;
        }
        public void AddItem(String s)
        {
            if (s.Contains("click"))
            {
                int x = Convert.ToInt16(s.Substring(s.IndexOf("X=") + 2, 1));
                int y = Convert.ToInt16(s.Substring(s.LastIndexOf("Y=") + 2, 1));
                click(x, y);
                myTurn = true;
                lblTurn.Text = "Mi Turno";
                Perdiste();
            }
            else if (s.Contains("Barcos :"))
            {
                Decodificar(s.ToString());
            }
        
        }
        private void SendClick()
        {
            streamW.WriteLine(clickString);
            LimpiaClick();
            streamW.Flush();
        }
        private void SendBarcos()
        {
            streamW.WriteLine(barcos);
            streamW.Flush();
        }
        public void IntentaConexion()
        {
            try
            {
                Conectar();
            }
            catch (Exception ex)
            {
                Exit(1);
            }
        }
        private void Conectar()
        {
            ipHost = Dns.GetHostEntry(Dns.GetHostName());
            ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, 8000);

            //client.Connect("148.224.51.180", 8000);
            client.Connect("192.168.100.7", 8000);//"192.168.0.16", 8000);
            //client.Connect("192.168.0.7",8000); //casa karen
            //client.Connect("127.0.0.1", 8000); 10.103.35.73
            //client.Connect("10.103.35.78", 8000);
            //client.Connect("148.224.51.142",8000);
            if (client.Connected)
            {
                Thread t = new Thread(Listen);

                stream = client.GetStream();
                streamR = new StreamReader(stream);
                streamW = new StreamWriter(stream);

                streamW.WriteLine(name);
                streamW.Flush();

                t.Start();
            }
            else
            {
                Exit(1);
            }
        }
        private void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    Invoke(new DAddItem(AddItem), streamR.ReadLine());
                }
                catch
                {
                    Exit(2);
                }
            }
        }
        private void Exit(int op)
        {
            string s = "";
            switch (op)
            {
                case 1:
                    MessageBox.Show("Servidor no Disponible");
                    break;
                case 2:
                    MessageBox.Show("No se ha podido conectar al servidor");
                    break;
            }
            //juego.Close();

            Application.Exit();
        }
        #endregion 
    }
}
