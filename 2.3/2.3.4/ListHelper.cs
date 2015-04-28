using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._4
{
    public class ListHelper
    {
        public static List<TOutput> ConvertAll<T, TOutput>(List<T> list, Converter<T, TOutput> converter)
        {
            var newList = new List<TOutput>();
            foreach (var x in list)
            {
                var c = converter.Invoke(x);
                newList.Add(c);
            }
            return newList;
        }
        public static List<T> FindAll<T>(List<T> list, Predicate<T> match)
        {
            var newList = new List<T>();
            foreach (var x in list)
            {
                if (match.Invoke(x))
                {
                    newList.Add(x);
                }
            }
            return newList;
        }
        public static void ForEach<T>(List<T> list, Action<T> action)
        {
            foreach (var x in list)
            {
                action.Invoke(x);
            }
        }
        public static int RemoveAll<T>(List<T> list, Predicate<T> match)
        {
            int count = 0;
            foreach (var x in list)
            {
                if (match.Invoke(x)) count++;
            }
            return count;
        }
        public static void Sort<T>(List<T> list, Comparison<T> comparison)
        {
            var length = list.ToArray().Length;
            T[] array = list.ToArray();
            do
            {
                for (int i = 0; i < length - 1; i++)
                {
                    if (comparison.Invoke(array[i], array[i + 1]) > 0)
                    {
                        T temp;
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
                length--;
            } while (length > 1);

            list = array.ToList<T>();
            foreach (var x in list)
            {
                Console.WriteLine(x);
            }
        }
    }
}
