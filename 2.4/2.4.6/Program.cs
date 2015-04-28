using System;
using System.IO;
using System.Linq;

namespace _2._4._6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] logs = File.ReadAllLines(@"..\..\IISLogs.txt");

            //Method 1
            var x = from log in logs
                    group log by log.Split(' ')[1] into i
                    orderby i.Count() descending
                    select new { ip = i.Key, count = i.Count() };


            Console.WriteLine("{0,-16} {1,-16}", "IP Adress:", "Times:");
            foreach (var item in x)
            {
                Console.WriteLine("{0,-16} {1,-16}", item.ip, item.count);
            }

            //Method 2
            var y = logs
                .GroupBy(i => i.Split(' ')[1])
                .Select(group =>
                    new
                    {
                        ip = group.Key,
                        count = group.Count()
                    }).OrderByDescending(i => i.count);

            Console.WriteLine("{0,-16} {1,-16}", "IP Adress:", "Times:");
            foreach (var item in y)
            {
                Console.WriteLine("{0,-16} {1,-16}", item.ip, item.count);
            }
            Console.ReadKey();
        }
    }
}
