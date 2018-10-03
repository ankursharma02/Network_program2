using System;
using System.Net.Sockets;
using System.Threading;
public class AsynchIOServer
{
    static TcpListener tcpListener = new TcpListener(10);

    private static string GetData()
    {
        //Ack from sql server
        return "ack";
    }
    static void listeners()
    {

        Socket socketforclient = tcpListener.AcceptSocket();
        if (socketforclient.Connected)
        {
            Console.WriteLine("client now connected to server.");
            NetworkStream networkstream = new NetworkStream(socketforclient);
            System.IO.StreamWriter streamwriter =new System.IO.StreamWriter(networkstream);
            System.IO.StreamReader streamreader = new System.IO.StreamReader(networkstream);

            //here we send message to client
            Console.WriteLine("type your message to be recieved by client:");
           
            string thestring =  GetData();
            streamwriter.WriteLine(thestring);
            //console.writeline(thestring);
            streamwriter.Flush();

            //here we recieve client's text if any.
            thestring = streamreader.ReadLine();
            Console.WriteLine("message recieved by client:" + thestring);
            streamreader.Close();
            networkstream.Close();
            streamwriter.Close();
        }
        socketforclient.Close();
        Console.WriteLine("press any key to exit from server program");
        Console.ReadKey();
    }


    //static void Listeners()
    //{

    //    Socket socketForClient = tcpListener.AcceptSocket();
    //    if (socketForClient.Connected)
    //    {
    //        Console.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
    //        NetworkStream networkStream = new NetworkStream(socketForClient);
    //        System.IO.StreamWriter streamWriter =
    //        new System.IO.StreamWriter(networkStream);
    //        System.IO.StreamReader streamReader =
    //        new System.IO.StreamReader(networkStream);

    //        ////here we send message to client
    //        //Console.WriteLine("type your message to be recieved by client:");
    //        //string theString = Console.ReadLine();
    //        //streamWriter.WriteLine(theString);
    //        ////Console.WriteLine(theString);
    //        //streamWriter.Flush();

    //        //while (true)
    //        //{
    //        //here we recieve client's text if any.
    //        while (true)
    //        {
    //            string theString = streamReader.ReadLine();
    //            Console.WriteLine("Message recieved by client:" + theString);
    //            if (theString == "exit")
    //                break;
    //        }
    //        streamReader.Close();
    //        networkStream.Close();
    //        streamWriter.Close();
    //        //}

    //    }
    //    socketForClient.Close();
    //    Console.WriteLine("Press any key to exit from server program");
    //    Console.ReadKey();
    //}

    public static void Main()
    {
   //     TcpListener tcpListener = new TcpListener(10);
        tcpListener.Start();
        Console.WriteLine("************This is Server program************");
        Console.WriteLine("Hoe many clients are going to connect to this server?:");
        int numberOfClientsYouNeedToConnect = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
        {
            Thread newThread = new Thread(new ThreadStart(listeners));
            newThread.Start();
        }



     
    }
}