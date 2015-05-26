using System;
using System.Threading;

namespace _3._1._4
{
    class Barber
    {
        public static void CutHair()
        {
            while (!Program.queue.IsEmpty)
            {
                Client c;
                Thread.Sleep(1000);

                if (Program.queue.TryDequeue(out c))
                {
                    Console.WriteLine("Done hair cutting to {0}", c.Name);
                }
            }

            Console.WriteLine("Going to sleep...");
            GoToSleep();
        }

        private static void GoToSleep()
        {
            Program.customerEvent.WaitOne();
            Console.WriteLine("Waking up! Customer arrived..");

            CutHair();
        }
    }
}
