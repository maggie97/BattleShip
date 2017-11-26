using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCP.Networking;

namespace TCP
{
    class Program
    {
        public static ServerSocket serverSocket = new ServerSocket();

        static void Main(string[] args)
        {
           // serverSocket.Bind(6556);
            //serverSocket.Listen(500);
            //serverSocket.Accept();

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
