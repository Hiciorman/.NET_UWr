using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _2._4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textLines = File.ReadAllLines(@"..\..\File.txt");
            List<int> liczby = new List<int>();

            foreach (string line in textLines)
            {
                liczby.Add(int.Parse(line));
            }

            var x = from liczba in liczby
                    where liczba > 100
                    orderby liczba descending
                    select liczba;

            var y = liczby.Where(i => i > 100).OrderByDescending(i => i);

            Console.WriteLine("Wyrażenie LINQ: ");
            foreach (int number in x.ToList())
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nCiąg wywołań LINQ: ");
            foreach (int number in y.ToList())
            {
                Console.WriteLine(number);
            }
            Console.ReadKey();
        }
    }
}
