using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._2
{
    class Program
    {
        [DllImport("PrimeLibrary.dll", EntryPoint = "IsPrimeC")]
        public static extern bool IsPrimeC(int x);

        static void Main(string[] args)
        {
            int x = 3;
            Console.WriteLine("{0} is prime: {1}", x, IsPrimeC(x));
            Console.ReadKey();
        }
    }
}
