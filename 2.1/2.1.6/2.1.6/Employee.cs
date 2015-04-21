
namespace _2._1._6
{
    class Employee
    {
        /// <summary>
        /// Konstruktor klasy Employee
        /// </summary>
        /// <param name="name">Imię</param>
        /// <param name="lastName">Nazwisko</param>
        /// <param name="experience">Doświadczenie zawodowe</param>
        /// <param name="age">Wiek pracownika</param>
        /// <param name="salary">Pensja</param>
        public Employee(string name, string lastName, int experience, int age, double salary)
        {
            _name = name;
            _lastName = lastName;
            _experience = experience;
            _age = age;
            _salary = salary;
        }

        /// <summary>
        /// Imię pracownika
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Nazwisko pracownika
        /// </summary>
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        /// <summary>
        /// Staż pracy pracownika
        /// </summary>
        private int _experience;

        public int Experience
        {
            get { return _experience; }
            set { _experience = value; }
        }
        /// <summary>
        /// Wiek pracownika
        /// </summary>
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        /// <summary>
        /// Wynagrodzenie pracownika
        /// </summary>
        private double _salary;

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
    }
}
