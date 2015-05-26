using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace _3._1._6.Server
{
    class Server
    {
        public static void Main()
        {
            int recv;
            byte[] data = new byte[1024];

            TcpListener newsock = new TcpListener(9050);
            newsock.Start();
            Console.WriteLine("Waiting for a client...");

            TcpClient client = newsock.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            data = new byte[1024];
            recv = ns.Read(data, 0, data.Length);
            List<Data> deserializedObject = JsonConvert.DeserializeObject<List<Data>>(System.Text.Encoding.UTF8.GetString(data));

            foreach (var item in deserializedObject)
            {
                Console.WriteLine(item.value);
                
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Szymon\Desktop\test.txt", true))
            {
                file.WriteLine(System.Text.Encoding.UTF8.GetString(data));
            }
            Console.ReadLine();

            ns.Close();
            client.Close();
            newsock.Stop();
        }
    }
    public class Data
    {
        public int value { get; set; }
    }
}