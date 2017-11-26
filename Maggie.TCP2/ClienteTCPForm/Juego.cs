using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ClienteTCPForm
{
    public partial class Juego : Form
    {
        static private string name = "unknow";
        static private NetworkStream stream;
        static private StreamReader streamR;
        static private StreamWriter streamW;
        static private TcpClient client = new TcpClient();

        private IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);
        private IPAddress ipAddr;
        private IPHostEntry ipHost;

        private delegate void DAddItem(String s); 

        public Juego(string nombre)
        {
            InitializeComponent();
            name = nombre;
        }
        private void AddItem(String s)
        {
            listBox1.Items.Add(s);
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Juego_Load(object sender, EventArgs e)
        {

        }
    }
}
