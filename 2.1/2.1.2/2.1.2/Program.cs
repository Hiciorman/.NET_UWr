using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2
{
    class Program
    {
        private static void Main(string[] args)
        {
            int x = 5;
            int y = 4;
            Grid grid = new Grid(x, y);

            int[] row = grid[3];
            grid[0, 0] = 9;
            int element = grid[0, 0];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Grid wiersz {0}: ", i);
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.Write("Wartość row: ");
            foreach (int r in row)
            {
                Console.Write(r + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Wartość elementu({0},{1}): {2}", x, y, element);
            Console.ReadKey();
        }
    }
}
