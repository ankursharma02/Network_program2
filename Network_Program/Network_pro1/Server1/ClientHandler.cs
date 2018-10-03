using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace Server1
{
    class ClientHandler
    {
        Socket s;
        string name;
        int k;
        int k1;
        byte[] b;
        bool islogin;
        public ClientHandler(Socket s, string name, int k, int k1)
        {
            this.s = s;
            this.name = name;
            this.k = k;
            this.k1 = k1;

        }

        public void run()
        {

            String received = "";
            while (true)
            {
                try
                {
                    // receive the string 
                    for (int i = 0; i < k; i++)
                        received += Convert.ToChar(b[i]);

                    Console.WriteLine(received);

                    if (received.Equals("logout"))
                    {
                        this.islogin = false;
                        this.s.Close();
                        break;
                    }

                    // break the string into message and recipient part 

                    // search for the recipient in the connected devices list. 
                    // ar is the vector storing client of active users 
                 //   foreach (ClientHandler mc in Program.li)
                    {
                        // if the recipient is found, write on its 
                        // output stream 
                        //if (mc.name.Equals(recipient) && mc.isloggedin == true)
                        //{
                        //    mc.dos.writeUTF(this.name + " : " + MsgToSend);
                        //    break;
                        Console.WriteLine(received);

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            //try
            //{
            //    // closing resources 
            //    this.dis.close();
            //    this.dos.close();

            //}
            //catch (IOException e)
            //{
            //    e.printStackTrace();
            //}
        }

    }
}