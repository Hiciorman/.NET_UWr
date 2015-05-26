using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._1._4
{
    class Program
    {
        public static AutoResetEvent customerEvent = new AutoResetEvent(false);
        public static ConcurrentQueue<Client> queue = new ConcurrentQueue<Client>();


        static void Main(string[] args)
        {
            Random rand = new Random();

            new Thread(Barber.CutHair) { IsBackground = true, Name = "Barber" }.Start();

            Thread.Sleep(100);

            Thread.CurrentThread.Name = "Main";

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(rand.Next(300, 2000));
                Client c = new Client() { Name = "Client " + i };
                queue.Enqueue(c);

                if (queue.Count == 1)
                {
                    Client.WakeUpBarber();
                }
                else
                {
                    Console.WriteLine(c.Name + " wait");
                }
            }
            Console.ReadKey();
        }

    }
}
