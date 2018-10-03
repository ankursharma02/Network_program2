using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Network_pro_demo
{
    class Get_Ip_addres_demo
    {
        static void Main(string[] args)
        {

                String strHostName = string.Empty; //getting the Host Name.
                strHostName = Dns.GetHostName();
                Console.WriteLine("Local Machine's Host Name: " + strHostName);
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);// Using Host Name,IP address is obtained.
                IPAddress[] addr = ipEntry.AddressList;

                for (int i = 0; i < addr.Length; i++)
                {
                    Console.WriteLine("IP Address  : "+ addr[i].ToString()
                        );
                }
                Console.ReadLine();
           

        }
    }
}
