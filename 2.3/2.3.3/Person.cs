using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._3
{
    public class Person
    {
        int age;
        public int Age
        {
            get { return this.age; }
        }

        int weight;
        public int Weight
        {
            get { return this.weight; }
        }

        int height;
        public int Height
        {
            get
            { return this.height; }
        }

        public Person(int age, int weight, int height)
        {
            this.age = age;
            this.weight = weight;
            this.height = height;
        }

        public static int CompareByAge(Person person1, Person person2)
        {
            return person1.Age.CompareTo(person2.Age);
        }
        public static int CompareByWeight(Person person1, Person person2)
        {
            return person1.Weight.CompareTo(person2.Weight);
        }
        public static int CompareByHeight(Person person1, Person person2)
        {
            return person1.Height.CompareTo(person2.Height);
        }
    }
}
