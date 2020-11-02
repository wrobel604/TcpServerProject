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
        protected Func<byte[], int, byte[]> outputGenerateFunction;
        public Func<byte[], int, byte[]> OutputGenerateFunction
        {
            set => outputGenerateFunction = value;
        }

        /// <summary>
        /// Konstruktor klasy tworzącej serwer TCP
        /// </summary>
        /// <param name="host">Adres na którym serwer będzie nasłuchiwał</param>
        /// <param name="port">Port na którym serwer będzie nasłuchiwał</param>
        public TcpServer(string host, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(host), port);
            outputGenerateFunction = (x, y) => x.Take(y).ToArray();
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
            int count;
            byte[] data = new byte[1024];
            while((count=stream.Read(data, 0, data.Length)) > 0)
            {
                byte[] answer = outputGenerateFunction(data, count);
                if (answer == null || answer.Length == 0) { break; }
                stream.Write(answer, 0, answer.Length);
            }
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
                    int count;
                    byte[] data = new byte[1024];
                    while ((count = stream.Read(data, 0, data.Length)) > 0)
                    {
                        byte[] answer = outputGenerateFunction(data, count);
                        if (answer == null || answer.Length == 0) { break; }
                        stream.Write(answer, 0, answer.Length);
                    }
                }, client.GetStream());
                task.Start();
            }
            tcpListener.Stop();
        }
    }
}
