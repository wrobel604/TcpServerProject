using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Linq;

namespace TcpServerLibrary
{
    public class StreamManager
    {
        public NetworkStream networkStream;
        byte[] data;
        public string Data
        {
            get { int size = networkStream.Read(data, 0, data.Length); return Encoding.ASCII.GetString(data.Take(size).ToArray()); }
            set { networkStream.Write(Encoding.ASCII.GetBytes(value), 0, value.Length); }
        }

        public StreamManager(NetworkStream ns, int buffer_size = 1024)
        {
            if (ns == null) { throw new ArgumentNullException("NetworkStream is null"); }
            data = new byte[buffer_size];
            networkStream = ns;
        }
    }
}
