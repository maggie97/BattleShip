﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip_Game
{
    class Client
    {
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
        Form1 juego;
        public string n;

        public Client(string nombre)
        {
            n = nombre;
            
        }
        public Point Valores()
        {
            Point p = new Point();
            return p;
        } 
        public void AddItem(String s)
        {
            if (s.Contains("click="))
            {
                //decodifica 
                int x = Convert.ToInt16(s.Substring(s.IndexOf("click=") + 7, 2));
                int y = Convert.ToInt16(s.Substring(s.LastIndexOf(",") + 1, 2));
            }

        }
        private void SendChat(String s)
        {
            streamW.WriteLine(s);
            streamW.Flush();
            
            //txtEnvia.Clear();
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
            juego = new Form1(n);
            juego.Visible = true;
        }
        private void Conectar()
        {
            ipHost = Dns.GetHostEntry(Dns.GetHostName());
            ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, 8000);

            client.Connect("10.103.35.170", 8000);
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
                    juego.Invoke(new DAddItem(AddItem), streamR.ReadLine());
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
    }
}
