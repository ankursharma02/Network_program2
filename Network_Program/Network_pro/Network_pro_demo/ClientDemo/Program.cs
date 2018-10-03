using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 13000;
            string ipAddress = "127.0.0.1";
            Socket ClientListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            ClientListener.Connect(ep);
            Console.WriteLine("Client is connected");
            while (true)
            {
                string msgfromclient = null;
                Console.WriteLine("Enter the message  ");
                msgfromclient = Console.ReadLine();
                ClientListener.Send(System.Text.Encoding.ASCII.GetBytes(msgfromclient),0,msgfromclient.Length,SocketFlags.None);
                byte[] msg = new byte[1024];
                int size=ClientListener.Receive(msg);
                Console.WriteLine("Server "+System.Text.Encoding.ASCII.GetString(msg,0,size));

            }


        }
    }
}
