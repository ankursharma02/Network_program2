using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
namespace Server1
{
    class Program
    {
        private static byte[] _buffer = new byte[1000];
        private static List<Socket> _clientSockets=new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        static void Main(string[] args)
        {
            Console.Title = "Server";
            SetupServer();
            Console.ReadLine();
        }
        private static void SetupServer()
        {
            Console.WriteLine("Setting up Server ...");
            _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            

        }
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(socket);
            socket.BeginReceive(_buffer,0,_buffer.Length,SocketFlags.None,new AsyncCallback(AcceptCallback),socket);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

            
        }
        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] databuf = new byte[received];
            Array.Copy(_buffer, databuf, received);
            string text = Encoding.ASCII.GetString(databuf);
            Console.WriteLine("Text Received :" + text);
            string response = string.Empty;
            if (text.ToLower() != "get time")
            {
                response = "Invalid Request";
               
            }
            else
            {
                response = DateTime.Now.ToLongTimeString();
            }
            byte[] data = Encoding.ASCII.GetBytes(DateTime.Now.ToLongTimeString());
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(AcceptCallback), socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(AcceptCallback), socket);

        }
        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }
    }
}