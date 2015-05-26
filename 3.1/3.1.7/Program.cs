using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Timers;

namespace _3._1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(2000);
            timer.Elapsed += new ElapsedEventHandler(SendMessages);
            timer.Enabled = true;
            timer.Interval = 1000;

            Timer timer2 = new Timer(3000);
            timer2.Elapsed += new ElapsedEventHandler(ReadMessages);
            timer.Enabled = true;

            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();
        }

        private static void ReadMessages(object sender, ElapsedEventArgs e)
        {
            ReadMessages();
        }

        private static void SendMessages(object sender, ElapsedEventArgs e)
        {
            SendMessages();
        }


        private static void SendMessages()
        {
            MessageQueue messages = new MessageQueue(@".\Private$\SomeTestName");
            messages.Label = "Testing Queue";

            for (int i = 0; i < 10; i++)
            {
                messages.Send("Message nr " + i);
            }
        }
        private static void ReadMessages()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\SomeTestName");
            System.Messaging.Message[] messages = messageQueue.GetAllMessages();
            foreach (Message message in messages)
            {
                Console.WriteLine(message.Label);
            }
        }
    }

}
