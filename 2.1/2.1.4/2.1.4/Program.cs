using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOznakowane(new Something());
            Console.ReadKey();
        }

        public static void ListOznakowane(object obj)
        {
            var methods = obj.GetType().GetMethods();
            foreach (var methodinfo in methods)
            {
                if (methodinfo.IsPublic && !methodinfo.IsStatic && methodinfo.ReturnType== typeof(int) && methodinfo.GetParameters().Length == 0 && methodinfo.GetCustomAttributes(typeof(Oznakowane), false).Length > 0)
                {
                    Console.WriteLine(methodinfo.Invoke(obj, null));
                }
            }
        }
    }
}
