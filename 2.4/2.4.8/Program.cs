using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1,1,2,3,5,8,13,21,34
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            
            //Method with linq ?
            Console.WriteLine("Linq method:");

            Func<int, int> factorial = null;
            foreach (var item in list.Select(factorial = i => i > 2 ? factorial(i - 1) + factorial(i - 2) : 1))
            {
                Console.WriteLine(item);
            }

            //Method with static point
            Console.WriteLine("\nMethod with static point:");

            Func<int, int> collection = Y<int, int>(f => n => n > 2 ? f(n - 1) + f(n - 2) : 1);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(collection(i));
            }
            Console.ReadKey();
        }

        public delegate Func<A, R> Recursive<A, R>(Recursive<A, R> r);

        static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Recursive<A, R> rec = r => a => f(r(r))(a);
            return rec(rec);
        }
    }
}
