using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClienteTCP.Networking;
using ClienteTCP.Networking.Packets;

namespace ClienteTCP
{
    class Program
    {
        private static ClientSocket ClientSocket = new ClientSocket();

        static void Main(string[] args)
        {
            ClientSocket.Connect("127.0.0.1", 6556);

            while (true)
            {
                string msg = Console.ReadLine();
                Message packet = new Message(msg);
                packet.Text = msg;
                ClientSocket.Send(packet.Data);
            }
        }
    }
}
