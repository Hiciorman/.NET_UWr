using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 10000000;
            ArrayList _arrayList = new ArrayList();
            List<int> _listInt = new List<int>();
            Hashtable _hashTable = new Hashtable();
            Dictionary<int, int> _dictionary = new Dictionary<int, int>();
            
            //ArrayList vs List<int> - add
            Console.WriteLine("Add");
            DateTime start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _arrayList.Add(i);
            }
            DateTime end = DateTime.Now;
            TimeSpan time = end - start;
            Console.WriteLine("ArrayList time: " + time);


            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _listInt.Add(i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("List<int> time: {0}\n", time);

            max = 100;
            //ArrayList vs List<int> - delete
            Console.WriteLine("Remove (Press to start)");
            Console.ReadKey();
            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _arrayList.Remove(i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("ArrayList time: " + time);

            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _listInt.Remove(i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("List<int> time: {0}\n", time);

            max = 1000000;
            //Hashtable vs Dictionary - add
            Console.WriteLine("Add (Press to start)");
            Console.ReadKey();
            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _hashTable.Add(i, i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("Hashtable time: " + time);


            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _dictionary.Add(i, i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("Dictionary<int><int> time: {0}\n", time);

            
            //Hashtable vs Dictionary - delete
            Console.WriteLine("Remove (Press to start)");
            Console.ReadKey();
            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _hashTable.Remove(i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("Hashtable time: " + time);


            start = DateTime.Now;
            for (int i = 0; i < max; i++)
            {
                _dictionary.Remove(i);
            }
            end = DateTime.Now;
            time = end - start;
            Console.WriteLine("Dictionary<int><int> time: " + time);
            Console.ReadKey();
        }
    }
}
