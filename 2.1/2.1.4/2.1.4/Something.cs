using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._4
{
    public class Oznakowane : Attribute
    {
        
    }
    public class Something
    {
        [Oznakowane]
        public int S()
        {
            return 44;
        }

        public int O()
        {
            return 2;
        }

        [Oznakowane]
        public char E()
        {
            return 'E';
        }

        [Oznakowane]
        public static int T()
        {
            return 4;
        }
        [Oznakowane]
        private int H()
        {
            return 1;
        }
        [Oznakowane]
        public int I(int x)
        {
            return x;
        }
    }
}
