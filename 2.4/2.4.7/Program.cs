using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4._7
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new { Field1 = "Tomasz", Field2 = 20 };
            var item2 = new { Field1 = "Jacek", Field2 = 21 };
            var item3 = new { Field1 = "Euzebiusz", Field2 = 17 };

            var list = Enumerable
                .Empty<object>()
                .Select(r => new
                {
                    Field1 = "",
                    Field2 = 0
                })
                .ToList();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);

            foreach (var item in list)
            {
                Console.WriteLine("{0,-14}{1,-14}", item.Field1, item.Field2);
            }

            Console.ReadKey();
        }
    }
}
