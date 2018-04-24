using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
class Broadcast
{
    public static void Main()
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);
        IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse("172.16.101.12"), 9050);

        //EndPoint ep = (IPEndPoint)iep1;
        string hostname = Dns.GetHostName();
        byte[] data = Encoding.ASCII.GetBytes(hostname);
        sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
        sock.SendTo(data, iep1);
        sock.SendTo(data, iep2);


        //sock.Bind(ep);
        //sock.ReceiveFrom(data, ref ep);
        //sock.SendTo(data, ep);
        sock.Close();
        Console.ReadLine();
      

    }
     
   
    }



