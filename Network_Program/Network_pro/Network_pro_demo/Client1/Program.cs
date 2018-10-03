using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

using System.Net.Sockets;

namespace Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("192.168.1.24", 8001);
                Console.WriteLine("Connected");
                
                string rmsg = "";
                while (!rmsg.Trim().Equals("exit"))
                {
                    rmsg = "";
                    Console.WriteLine("\nEnter the string to be transmitted : ");
                    String str = Console.ReadLine();
                Stream stm = tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("msg from server....");
                
                    
                    stm.Write(ba, 0, ba.Length);
                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(bb[i]));
                        rmsg += Convert.ToChar(bb[i]);
                    }
                    
                  //  Console.Read();
                }
                    tcpclnt.Close();
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
    }
}