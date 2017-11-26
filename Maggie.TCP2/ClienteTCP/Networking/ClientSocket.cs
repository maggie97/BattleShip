using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ClienteTCP.Networking
{
    class ClientSocket
    {
        private Socket _socket;
        private byte[] _buffer;
        
        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect(string ipAddress, int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port),ConnectCallback, null);
        }
        public void ConnectCallback(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                Console.WriteLine("Connected to the server");
                _buffer = new byte[1024];
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
               
            }
            else Console.WriteLine("Could not connect");
        } 
        public void ReceivedCallback(IAsyncResult result)
        {
            int bufLenght = _socket.EndReceive(result);
            byte[] packet = new byte[bufLenght];
            Array.Copy(_buffer, packet, packet.Length);

            // handle packet

            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
        }

        public void Send(byte[] data)
        {
            _socket.Send(data);
        }
    }
}
