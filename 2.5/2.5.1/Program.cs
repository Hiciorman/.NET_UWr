using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int max = 10000000;
            int temp;
            object temp2;
            DateTime start = DateTime.Now;
            Tests x = new Tests();

            for (int i = 0; i < max; i++)
            {
                temp = x.Foo(i, i);
            }

            DateTime end = DateTime.Now;
            TimeSpan time = end - start;

            Console.WriteLine("Normal: " + time);

            start = DateTime.Now;

            for (int i = 0; i < max; i++)
            {
                temp2 = x.FooA(i, i);
            }

            end = DateTime.Now;
            time = end - start;

            Console.WriteLine("\nDynamic: " + time);
            Console.ReadKey();
        }
    }

    public class Tests
    {
        public int Foo(int x, int y)
        {
            return x * y;
        }

        public dynamic FooA(dynamic x, dynamic y)
        {
            return x * y;
        }
    }
}
