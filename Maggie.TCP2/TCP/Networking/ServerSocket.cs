using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCP.Networking
{
    class ServerSocket
    {

        private Socket _socket;
        //private List<Socket> listSocket;
        //byte[] _buffer = new byte[1024];

        private TcpListener servidorPrincipal;

        private TcpListener server;
        private TcpClient cliente = new TcpClient();
        private IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.7"), 8000);
        private IPAddress ipAddr;
        private IPHostEntry ipHost;
        private SocketPermission permission;
        List<Connection> list = new List<Connection>();
        Connection con;

        private struct Connection
        {
            public NetworkStream stream;
            public StreamReader streamR;
            public StreamWriter streamW;
            public string name;
        }

        public ServerSocket()
        {
            //listSocket = new List<Socket>();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Load();
        }
        public void Load()
        {
            ipHost = Dns.GetHostEntry(Dns.GetHostName());
            ipAddr = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddr, 8000);
            Console.WriteLine("Servidor Listo");
            servidorPrincipal = new TcpListener(ipEndPoint);
            servidorPrincipal.Start();
            permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);
            _socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            while (true)
            {
                cliente = servidorPrincipal.AcceptTcpClient();
                con = new Connection();
                con.stream = cliente.GetStream();
                con.streamR = new StreamReader(con.stream);
                con.streamW = new StreamWriter(con.stream);

                con.name = con.streamR.ReadLine();
                list.Add(con);
                Console.WriteLine(con.name + " se a conectado.");

                Thread t = new Thread(EscucharConeccion);
                t.Start();
            }
        }
        public void EscucharConeccion()
        {
            Connection hcon = con;
            do
            {
                try
                {
                    string tmp = hcon.streamR.ReadLine();
                    Console.WriteLine(hcon.name + " : " + tmp);
                    foreach (Connection c in list)
                    {
                        try
                        {
                            c.streamW.WriteLine(hcon.name + " : " + tmp);
                            c.streamW.Flush();
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                    list.Remove(hcon);
                    Console.WriteLine(con.name + " se a desconectado");
                    break;
                }
            } while (true);
        }
        /*
        public void Bind(int port)
=======
       /* public void Bind(int port)
>>>>>>> origin/master
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }
        public void Listen(int backlog)
        {
            _socket.Listen(10);
        }
        public void Accept()
        {
            _socket.BeginAccept(AcceptCallBack, null);
        }
        public void AcceptCallBack(IAsyncResult result)
        {
            Socket clientSocket = _socket.EndAccept(result);
            _buffer = new byte[1024];
            Accept();
            listSocket.Add(clientSocket);
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);
            Console.WriteLine("Client connected, waiting for request...");
        }
        public void ReceivedCallback(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
            int bufferSize;// = clientSocket.EndReceive(result);
            try
            {
                bufferSize = clientSocket.EndReceive(result);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Client forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                clientSocket.Close();
                listSocket.Remove(clientSocket);
                return;
            }
            byte[] packet = new byte[bufferSize];
            if (_buffer[0] == 0 || _buffer[2] == 0)
                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);
            Array.Copy(_buffer,packet, packet.Length);
            
            //handle the packet
            PacketHandler.Handle(packet, clientSocket);

            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, clientSocket);
        }*/
    }
}
