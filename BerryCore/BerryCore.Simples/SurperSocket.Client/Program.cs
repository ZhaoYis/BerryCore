using SuperSocket.ClientEngine;
using SurperSocket.Core;
using SurperSocket.Core.Client.AppBase;
using SurperSocket.Core.Client.Tools;
using System;
using System.Net;

namespace SurperSocket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClientEasyClient client = new SocketClientEasyClient(new IPEndPoint(IPAddress.Parse("192.168.31.38"), 9005));
            EasyClient<CustomPackageInfo> res = client.InitEasyClient();

            while (Console.ReadLine() != "")
            {
                string data = Console.ReadLine();
                string json = data.GetTransmitPackets(SocketCommand.SystemMessage);
                res.Send(SocketCommand.SystemMessage, json);
            }
        }
    }
}
