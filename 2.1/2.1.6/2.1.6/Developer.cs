using System;

namespace _2._1._6
{
    /// <summary>
    /// Klasa bazowa
    /// </summary>
    class Developer : Employee
    {
        public Developer(string name, string lastName,int experience, int age, double salary, int workTime) : base(name, lastName,experience, age, salary)
        {
            _workTime = workTime;
        }

        public delegate void developerShouldBePromoted();
        public event developerShouldBePromoted promoteDeveloper;

        private int _workTime;

        public int WorkTime
        {
            get { return _workTime; }
            set { _workTime = value; }
        }

        public bool canBePromoted()
        {
            if (this.GetType() == typeof (JuniorDeveloper))
            {
                if (this.Experience > 2)
                {
                    promoteDeveloper();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (this.GetType() == typeof(SeniorDeveloper))
            {
                if (this.Experience > 8)
                {
                    promoteDeveloper();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static void PromoteDeveloper()
        {
            Console.WriteLine("Think about promoting this developer");
        }
    }
}
