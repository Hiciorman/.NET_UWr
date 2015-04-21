using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2
{
    public class Grid
    {
        private int[,] table { get; set; }
        private int tableRowLength { get; set; }
        private int tableColLength { get; set; }
        public Grid(int x, int y)
        {
            table = new int[x,y];
            tableColLength = table.GetLength(0);
            tableRowLength = table.GetLength(1);
            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    table[i, j] = i*j;
                }
            }
        }

        public int[] this[int x]
        {
            get
            {
                //Powiniśmy jeszcze wyrzucić wyjątek ponieważ można się odwołać do nie istejącego indeksu
                //if(x >= 0 && x < tableColLength)
                int[] temporaryTable = new int[tableRowLength];
                //Funkcja kopiuje jeden wiersz tablicy, po bitach tzn. dla tablicy x[[1,2],[3,4]] gdy chcemy skopiować 1 wiersz:
                //długość wiersza tabeli * 4(wielkość int)* wiersz tabeli(w tym wypadku 1)
                System.Buffer.BlockCopy(table, tableRowLength * 4 * x, temporaryTable, 0, tableRowLength * 4);
                return temporaryTable;
            }
        }

        public int this[int x, int y]
        {
            get { return table[x, y]; }
            set { table[x, y] = value; }

        }
    }
}
