using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            //converter test
            var list1 = new List<double>();
            list1.Add(2.3);
            list1.Add(3.5);
            var convertedList1 = ListHelper.ConvertAll<double, int>(list1, new Converter<double, int>(Converter));

            //findall test
            var list2 = new List<int>();
            list2.Add(2);
            list2.Add(6);
            Predicate<int> predicate = CheckInt;
            var convertedList2 = ListHelper.FindAll<int>(list2, predicate);

            //foreach test
            var list3 = new List<int>();
            list3.Add(2);
            list3.Add(3);
            Action<int> action = ReadInt;
            ListHelper.ForEach<int>(list3, action);

            //deleteall test
            var list4 = new List<int>();
            list4.Add(2);
            list4.Add(6);
            Predicate<int> predicate2 = CheckInt;
            var convertedList4 = ListHelper.RemoveAll<int>(list4, predicate2);

            //sort test
            var list5 = new List<string>();
            list5.Add("123");
            list5.Add("1");
            list5.Add("1234");
            list5.Add("1");
            ListHelper.Sort<string>(list5, Comparator);

            Console.ReadLine();
        }

        public static int Converter(double f)
        {
            return (int)f;
        }
        
        public static bool CheckInt(int obj)
        {
            return obj > 5;
        }
        
        public static void ReadInt(int obj)
        {
            Console.WriteLine(obj);
        }

        public static int Comparator(string obj1, string obj2)
        {
            if (obj1 == obj2) 
                return 0;
            else if (string.Compare(obj1, obj2) < 0) 
                return 1;
            else
                return -1;
        }
    }
}
