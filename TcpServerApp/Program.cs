using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpServerLibrary;

namespace TcpServerApp
{
    class Program
    {
        /// <summary>
        /// Główna funkcja programu tworzącego serwer
        /// </summary>
        /// <param name="args">
        ///     Pierwszy element tablicy to adres hosta, na którym ma nasłuchiwać serwer.
        ///     Drugi element tablicy to port, na którym ma nasłuchiwać serwer.
        /// </param>
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
                //tcpServer.OutputGenerateFunction = MessageTimeParser.messageParser;
                tcpServer.Listening();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
