using SurperSocket.Core.Service.Tools;
using System;

namespace SurperSocket.Service
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SocketServiceEasyClient easyClient = new SocketServiceEasyClient();
            easyClient.InitEasyClient();

            Console.WriteLine("输入'quit'以停止服务");
            ReadConsoleCommand();
            easyClient.Stop();

            Console.WriteLine("The SuperSocket ServiceEndine has been stopped!");
        }

        private static void ReadConsoleCommand()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                if ("quit".Equals(line, StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
        }
    }
}
