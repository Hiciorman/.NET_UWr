using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2._4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = "..\\..\\Test";

            //Method 1
            string[] filePaths = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

            IEnumerable<long> lengths = from path in filePaths
                                        let file = new FileInfo(path)
                                        select file.Length;

            long filesLength = lengths.Aggregate((a, b) => a + b);

            Console.WriteLine("Files length: " + filesLength);

            //Method 2
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(directoryPath);
            IEnumerable<FileInfo> filePaths2 = dir.GetFiles("*.*", SearchOption.AllDirectories);

            long filesLength2 = filePaths2.Select(a => a.Length).Aggregate((a, b) => a + b);

            Console.WriteLine("\nFiles length: " + filesLength2);
            Console.ReadKey();
        }
    }
}
