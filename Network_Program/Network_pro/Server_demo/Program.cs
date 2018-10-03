using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Server_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 13000;
            string ipAddress = "127.0.0.1";
            Socket ServelListener = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress),port);
            ServelListener.Bind(ep);
            ServelListener.Listen(100);
            Console.WriteLine("Server is listening");
            Socket clientsocket = default(Socket);
            int counter = 0;
            Program p = new Program();
            while (true)
            {
                counter++;
                clientsocket = ServelListener.Accept();
                Console.WriteLine("\n"+counter+" client connected");
                Thread usethread = new Thread(new ThreadStart(()=>p.User(clientsocket)));
                usethread.Start();
            }
        }
        public void User(Socket client)
        {
            while (true)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);
                Console.WriteLine();
                for (int i = 0; i < size; i++)
                    Console.Write((char)msg[i]);
                Console.WriteLine();
                client.Send(msg, 0, size, SocketFlags.None);
            }
        }
    }
}
