using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            //TODO
            foreach (var item in list.Select(i => 1))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
