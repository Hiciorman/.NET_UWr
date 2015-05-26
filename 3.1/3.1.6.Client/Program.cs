using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace _3._1._6.Client
{
    class Client
    {
        public static void Main()
        {
            byte[] data = new byte[1024];
            TcpClient server;

            try
            {
                server = new TcpClient("127.0.0.1", 9050);
            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect to server");
                return;
            }
            NetworkStream ns = server.GetStream();

            List<Data> testData = new List<Data>();

            testData.Add(new Data() {value = 1});
            testData.Add(new Data() { value = 2 });
            testData.Add(new Data() { value = 3 });
            testData.Add(new Data() { value = 4 });
            string serializedData = JsonConvert.SerializeObject(testData);
            ns.Write(Encoding.ASCII.GetBytes(serializedData), 0, serializedData.Length);
            ns.Flush();

            Console.WriteLine("Disconnecting from server...");
            Console.ReadLine();
            ns.Close();
            server.Close();
        }

    }
    public class Data
    {
        public int value { get; set; }
    }
}
