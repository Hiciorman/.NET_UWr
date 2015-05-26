using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Set collection = new Set();

            for (int i = 0; i < 10; i++)
            {
                collection.Enqueue(i);
                collection.Enqueue(i);
                collection.Enqueue(100-i); 
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            
        }
    }
}
