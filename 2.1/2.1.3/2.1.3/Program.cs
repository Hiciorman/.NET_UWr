using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace _2._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMath myMath = new MyMath(20);
            //10 milions
            const int testMax = 10000000;
            int result = 0;
            int test = 0;
            
            DateTime startTime = DateTime.Now;
            
            //Access to method with reflecion
            while (test++<testMax)
            {
                MethodInfo add = myMath.GetType().GetMethod("Add", BindingFlags.Instance | BindingFlags.NonPublic);
                result = (int)add.Invoke(myMath, new object[] { (int)5, (int)10 });   
            }

            DateTime endTime = DateTime.Now;
            TimeSpan time = endTime - startTime;
            Console.WriteLine("Reflection access to method time test: " + time);
            
            test = 0;
            startTime = DateTime.Now;

            //Acess to property with reflection
            while (test++<testMax)
            {
                MethodInfo data =
                    myMath.GetType().GetProperty("Data", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod();
            }

            endTime = DateTime.Now;
            time = endTime - startTime;
            Console.WriteLine("Reflection access to property time test: " + time);

            startTime = DateTime.Now;

            //Acess to method 
            myMath.TestMethod(5,10,testMax);

            endTime = DateTime.Now;
            time = endTime - startTime;
            Console.WriteLine("Standard access to method time test: " + time);

            startTime = DateTime.Now;

            //Acess to property
            myMath.TestProperty(testMax);

            endTime = DateTime.Now;
            time = endTime - startTime;
            Console.WriteLine("Standard access to method time test: " + time);

            Console.ReadKey();
        }
    }
}
