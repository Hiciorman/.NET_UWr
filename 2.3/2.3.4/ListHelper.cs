using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._4
{
    class ListHelper
    {
        public static List<TOutput> ConvertAll<T, TOutput>(List<T> list, Converter<T, TOutput> converter);
        public static List<T> FindAll<T>(List<T> list, Predicate<T> match);
        public static void ForEach<T>(List<T> list, Action<T> action);
        public static int RemoveAll<T>(List<T> list, Predicate<T> match);
        public static void Sort<T>(List<T> list, Comparison<T> comparison);
    }
}
