using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Adam = new Person(18, 80, 185);
            Person Margaret = new Person(16, 45, 165);
            Person Jay = new Person(24, 90, 182);

            List<Person> people = new List<Person>(new Person[]{ Adam,Margaret,Jay});

            DisplayList(people);

            //Comparison
            people.Sort(delegate(Person p1, Person p2){
                return p1.Age.CompareTo(p2.Age);
            });
            people.Sort(Person.CompareByAge);
            DisplayList(people);

            //Predicate
            Predicate<Person> findAll = FindPerson;
            DisplayList(people.FindAll(findAll));

            Predicate<Person> removeAll = DeletePeople;
            people.RemoveAll(removeAll);
            DisplayList(people);

            //Action
            Action<Person> forEach = ForEach;
            people.ForEach(forEach);

            //Converter 
            Converter<Person, string> convertAll = ConvertAll;
            List<string> stringList =  people.ConvertAll<string>(convertAll);

            foreach (var item in stringList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static string ConvertAll(Person input)
        {
            if(input.Age > 18){
                return "Adult";
            }
            else
            {
                return "Youngster";
            }
        }

        private static void ForEach(Person obj)
        {
            if (obj.Height>184)
            {
                Console.WriteLine("{0} WOW!", obj.Height);
            }
        }

        private static bool DeletePeople(Person obj)
        {
            return obj.Weight < 70;
        }

        private static bool FindPerson(Person obj)
        {
            return obj.Height > 180;
        }
        private static void DisplayList(List<Person> people)
        {
            Console.WriteLine("{0,-10} {1,-10} {2,10}", "Age", "Weight", "Height");
            foreach (var person in people)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,10:N0}", person.Age, person.Weight, person.Height);
            }
            Console.WriteLine();
        }
    }
}
