using System;
using TcpServerLibrary;
using TcpServerApp;

namespace TcpServerMultiClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            if (args.Length > 0) { host = args[0]; }
            int port = 5555;
            if (args.Length > 1) { port = int.Parse(args[1]); }
            try
            {
                TcpServer tcpServer = new TcpServer(host, port);
                Console.WriteLine($"Uruchomiono serwer na adresie {host}:{port}");
                //tcpServer.Listening(MessageTimeParser.messageParser);
                tcpServer.OutputGenerateFunction = MessageTimeParser.messageParser;
                tcpServer.ListeningMultipleClient();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
