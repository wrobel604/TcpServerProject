using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TcpServerLibrary
{
    /// <summary>
    /// Klasa obsługująca serwer TCP
    /// </summary>
    public class TcpServer
    {
        protected TcpListener tcpListener;
        // protected Func<byte[], int, byte[]> outputGenerateFunction;
        /*public Func<byte[], int, byte[]> OutputGenerateFunction
        {
            set => outputGenerateFunction = value;
        }*/
        protected Action<NetworkStream> serverFunction;
        public Action<NetworkStream> ServerMessageParserFunction
        {
            set => serverFunction = value;
        }

        /// <summary>
        /// Konstruktor klasy tworzącej serwer TCP
        /// </summary>
        /// <param name="host">Adres na którym serwer będzie nasłuchiwał</param>
        /// <param name="port">Port na którym serwer będzie nasłuchiwał</param>
        public TcpServer(string host, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(host), port);
            serverFunction = null;
        }

        /// <summary>
        /// Włącza nasłuchiwanie przez serwer.
        /// Odebrane dane są przekazywane do funkcji podanej jako argument, która zwraca dane do odesłania jako odpowiedź (zwrócony null lub pusty ciąg kończy działanie funkcji).
        /// </summary>
        /// <param name="outputgenerator">Delegat do funkcji służącej do obsługi odebranych danych (pierwszy argument delegatu to dane, natomiast drugi to ilość danych). </param>
        public void Listening()
        {
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream stream = tcpClient.GetStream();
            serverFunction(stream);
            tcpListener.Stop();
        }

        public void ListeningMultipleClient()
        {
            tcpListener.Start();
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Task task = new Task((x) => {
                    NetworkStream stream = (NetworkStream)x;
                    serverFunction(stream);
                }, client.GetStream());
                task.Start();
            }
            tcpListener.Stop();
        }
    }
}
