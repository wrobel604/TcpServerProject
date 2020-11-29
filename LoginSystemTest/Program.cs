using System;
using TcpServerLibrary;
using LoginSystem;

namespace LoginSystemTest
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
                tcpServer.ServerMessageParserFunction = LoginSystem.LoginSystem.messageParser;//Zeby to zadziałało to messageParser musi być statyczna
                tcpServer.Listening();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
