using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Clients2
{
    class Program
    {
        static TcpClient tcpclnt = new TcpClient();
        static string rmsg = "";
        static void Main(string[] args)
        {
            try
            {
                
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("192.168.1.24", 8001);
                Console.WriteLine("Connected");

                Console.WriteLine("\nEnter the string to be transmitted : ");
                while (!rmsg.Trim().Equals("exit"))
                {
                    rmsg = "";
                //    Console.WriteLine();
                    //  Console.Read();
                    Thread t1 = new Thread(read);
                    Thread t2 = new Thread(write);
                    t1.Start();
                    t2.Start();
                    Thread.Sleep(333);                }
                tcpclnt.Close();
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
        public static void read()
        {
            Stream stm = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            //             Console.WriteLine("msg from server....");

          //  Console.WriteLine();
           // stm.Write(ba, 0, ba.Length);
            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);
            for (int i = 0; i < k; i++)
            {
                Console.Write(Convert.ToChar(bb[i]));
                rmsg += Convert.ToChar(bb[i]);
            }

        }
        public static void write()
        {
            
          ASCIIEncoding asen = new ASCIIEncoding();

                
            String str = Console.ReadLine();
            Stream stm = tcpclnt.GetStream();
            byte[] ba = asen.GetBytes(str);

            stm.Write(ba, 0, ba.Length);
            Console.WriteLine();
        }
    }
}