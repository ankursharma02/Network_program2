using System;
using System.Net;
using System.Net.Sockets;

namespace Network_pro_demo
{
    class Alias_demo
    {
        public static void Main()
        {
            IPHostEntry IPHost = Dns.Resolve("www.google.com");
          //  IPHostEntry IPHost = Dns.Resolve("192.168.1.24");
            Console.WriteLine(IPHost.HostName);
            string[] aliases = IPHost.Aliases;
            Console.WriteLine(aliases.Length);
            IPAddress[] addr = IPHost.AddressList;
            Console.WriteLine(addr.Length);
            for (int i = 0; i < addr.Length; i++)
            {
                Console.WriteLine(addr[i]);
            }
            Console.ReadLine();
        }
    }
}
