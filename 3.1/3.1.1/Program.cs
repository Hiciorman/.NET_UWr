using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(4, 3);
            Complex y = new Complex(8, 2);
            Complex x = new Complex(10, 3);

            Console.WriteLine(String.Format("{0}", z));
            Console.WriteLine(String.Format("{0:d}", z));
            Console.WriteLine(String.Format("{0:w}", z));

            Console.WriteLine("\n{0}+{1}={2}", z, y, z + y);
            Console.WriteLine("{0}-{1}={2}", z, x, z - x);
            Console.WriteLine("{0}*{1}={2}", y, x, y * x);
            Console.WriteLine("{0}/{1}={2}", x, y, x / y);
            Console.ReadKey();
        }
    }
}
