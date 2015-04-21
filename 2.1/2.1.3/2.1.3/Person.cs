using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _2._1._3
{
    class MyMath
    {
        public MyMath(int x)
        {
            Data = x;
        }

        private int Data { get; set; }

        private int Add(int x, int y)
        {
            return x + y;
        }

        public void TestMethod(int x, int y, int times)
        {
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result = Add(x, y);
            }
        }

        public void TestProperty(int times)
        {
            int result;

            for (int i = 0; i < times; i++)
            {
                result = Data;
            }
        }

    }
}
