using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Server2
{
    class Program
    {
        public static IPAddress ipAd = IPAddress.Parse("192.168.1.24");
        public static TcpListener myList = new TcpListener(ipAd, 8001);
        public static Socket s;
        public static ASCIIEncoding asen = new ASCIIEncoding();
       // static List<Socket> li;
        static void Main(string[] args)
        {
            try
            {

                myList.Start();
                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is  :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                s = myList.AcceptSocket();
           //     li.Add(s);
                Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
               
                while (true)
                {
                    // string msg = "";
                    //  Console.WriteLine("enter <exit> for close else enter msg ");
                    // int i = 0;
                    //s = myList.AcceptSocket();
                    ////li.Add(s);
                    //foreach (Socket i in li)
                    //{
                    //    if (i.Equals(s.RemoteEndPoint))
                    //    {

                    //        Thread t1 = new Thread(new ThreadStart(() => read(i)));
                    //        Thread t2 = new Thread(new ThreadStart(() => write(i)));
                    //        Thread.Sleep(222);


                    //    }
                    //}
                    Thread t1 = new Thread(read);
                    Thread t2 = new Thread(write);
                    t1.Start();
                    t2.Start();
                    Thread.Sleep(222);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
            finally
            {
                s.Close();
                myList.Stop();
            }
            Console.ReadLine();
        }
        public static void read()
        {
            
            byte[] b = new byte[1000];
            int k = s.Receive(b);

            Console.WriteLine("\nRecieved...");
            for (int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(b[i]));
            }

            Console.WriteLine();
        }
        public static void write()
        {
            string msg;
         
            msg = Console.ReadLine();
            s.Send(asen.GetBytes(msg));
            Console.WriteLine("\nSent msg  ");
        }

    }
}
