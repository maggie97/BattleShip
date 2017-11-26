using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using TCP.Networking.Packets;

namespace TCP.Networking
{
    public static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            ushort packetLength = BitConverter.ToUInt16(packet, 0);
            ushort packetType = BitConverter.ToUInt16(packet, 2);

            Console.WriteLine("Received packet!! Length: {0} | Type: {1}", packetLength, packetType);
            switch (packetType)
            {
                case 2000:
                    Message msg = new Message(packet);
                    Console.WriteLine(msg.Text);
                    break;
            }
        }

    }
}
