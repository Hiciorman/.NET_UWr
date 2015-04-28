using System;
using System.IO;
using System.Linq;

namespace _2._4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textLines = File.ReadAllLines(@"..\..\File.txt");

            var groupA = from line in textLines
                         orderby line
                         group line by line[0] into i
                         select i.Key;

            Console.WriteLine("Wyrażenie LINQ: ");
            foreach (var item in groupA)
            {
                Console.WriteLine(item);
            }

            var groupB = textLines
                .OrderBy(i => i)
                .GroupBy(i => i[0])
                .Select(i=> i.Key)
                .ToList();

            Console.WriteLine("\nCiąg wywołań LINQ: ");
            foreach (var item in groupB)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
