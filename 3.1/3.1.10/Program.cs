using System;
using System.IO;
using System.Reflection;

namespace _3._1._10
{
    class Program
    {

        static void Main(string[] args)
        {
            Reader reader = new Reader();
            Console.WriteLine(reader.read("File"));
            Console.ReadKey();
        }

        class Reader
        {
            public string read(string name)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = String.Format("_3._1._10.Resources.{0}.txt", name);

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}
