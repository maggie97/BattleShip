using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System;
using System.Xml;

namespace timbiriche
{
    public partial class Form1 : Form
    {
        private Rectangle[,] R1 = new Rectangle[15, 15];
        public static Cuadro[,] cuadricula = new Cuadro[15, 15];
        private delegate void DAddItem(String s);
        private Size tam = new Size(50, 50); // modificar con el tam de la form (algun dia)
        #region Inicializa variables Sockets
        static private string name = "unknow";
        static private NetworkStream stream;
        static private StreamReader streamR;
        static private StreamWriter streamW;
        static private TcpClient client = new TcpClient();

        private IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);
        private IPAddress ipAddr;
        private IPHostEntry ipHost;
        #endregion

        #region XML
        XmlDocument xml;
        string strXML = "C:\\Users\\USER-PC\\Desktop\\BattleShip\\timbiriche\\xml.xml";
        #endregion
        public Form1()
        {
            InitializeComponent();
            //name = nombre;
            //Es la parte visual del Timbiriche
            #region Visual  

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
            xml = new XmlDocument();
            //xml.Load(strXML);
            //conecta al servidor 
            IntentaConexion();
            //InicializaXML();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) //dibuja el timbiriche
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (j % 2 == 0 && i % 2 == 0)
                    {
                        e.Graphics.DrawEllipse(new Pen(Color.Black), R1[i, j]);
                        e.Graphics.FillEllipse(new SolidBrush(cuadricula[i, j].C), 
                            cuadricula[i, j].P.X, cuadricula[i, j].P.Y,
                            cuadricula[i, j].S.Width, cuadricula[i, j].S.Height);
                    }
                    else if(j % 2 != 0 && i % 2 != 0)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Black), R1[i, j]);
                        e.Graphics.FillRectangle(new SolidBrush(cuadricula[i, j].C),
                            cuadricula[i, j].P.X, cuadricula[i, j].P.Y,
                            cuadricula[i, j].S.Width, cuadricula[i, j].S.Height);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(new Pen(Color.Black), R1[i, j]);
                        e.Graphics.FillEllipse(new SolidBrush(cuadricula[i, j].C),
                            cuadricula[i, j].P.X, cuadricula[i, j].P.Y, 
                            cuadricula[i, j].S.Width, cuadricula[i, j].S.Height);
                    }
                }
            /*foreach (Cuadro x in cuadricula)
                e.Graphics.FillRectangle(new SolidBrush(x.C), x.P.X, x.P.Y, x.S.Width, x.S.Height);
            foreach (Rectangle r in R1)
                e.Graphics.DrawRectangle(new Pen(Color.Black), r);*/
        }
        private void InicializaXML()
        {
            XmlElement objPunto = xml.CreateElement("punto");
            XmlElement objLinea = xml.CreateElement("linea");
            XmlElement objCuadro = xml.CreateElement("cuadro");

            objPunto.InnerText = "true";
            objLinea.InnerText = "true";
            objLinea.SetAttribute("Color", "WHITE");
            objLinea.SetAttribute("Juagdor", name);
            objCuadro.InnerText = "true";
            objCuadro.SetAttribute("Color", "GRAY");
            objCuadro.SetAttribute("Ganado", "false");
            objCuadro.SetAttribute("Jugador", "none");
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
      
        private void AddItem(String s)
        {
            listBox1.Items.Add(s);
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            streamW.WriteLine(txtEnvia.Text);
            streamW.Flush();
            txtEnvia.Clear();
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

            client.Connect("192.168.0.16", 8000);
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
                    this.Invoke(new DAddItem(AddItem), streamR.ReadLine());
                }
                catch
                {
                    Exit(2);
                }
            }
        }
        private void Exit(int op)
        {
            switch (op)
            {
                case 1:
                    MessageBox.Show("Servidor no Disponible");
                    break;
                case 2:
                    MessageBox.Show("No se ha podido conectar al servidor");
                    break;
            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            

            streamW.WriteLine(xml);
            streamW.Flush();
            txtEnvia.Clear();
        }
        int cuadriTam = 15;
        private void Juega()
        {
            bool cuadCerrado = true;
            for (int i = 0; i < cuadriTam; i++)
                for (int j = 0; j < cuadriTam; j++)
                {

                    if (j % 2 == 0 && i % 2 != 0) //lineas horizontales
                    {
                        if(cuadricula[i, j].C == Color.Gray)
                        {
                            if (LineaVertical(i, j))
                            {
                                cuadCerrado = true;
                                Console.WriteLine
                            }
                            else if(j == 1)
                            {
                                //primer columna
                            }
                            else if(j == cuadriTam - 2)
                            {
                                //ultima columna
                            }
                            else
                            {
                                //columnas y filas internas
                            }
                        }
                    }
                    else if (i % 2 == 0 && j % 2 != 0) //lineas verticales
                    {
                        
                    }
                }
        }
        private bool LineaVertical(int i , int j)
        {
            bool vertical = false;
            if (i == 1)
            {
                //linea superior
                if (cuadricula[i + 2, j].C == Color.Gray)
                    vertical = true;
            }
            else if (i == cuadriTam - 2)
            {
                //ultima linea
                if (cuadricula[i - 2, j].C == Color.Gray)
                    vertical = true;
            }
            else
            {
                if (cuadricula[i + 2, j].C == Color.Gray)
                    vertical = true;
                else if (cuadricula[i - 2, j].C == Color.Gray)
                    vertical = true;
            }
            return vertical;
        }
    }
}
