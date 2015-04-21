using System;

namespace _2._1._6
{
    class Program
    {
        static void Main(string[] args)
        {
            JuniorDeveloper krzysztof = new JuniorDeveloper("Krzysztof", "Kozak",0,20,1600,20);
            JuniorDeveloper szymon = new JuniorDeveloper("Szymon", "Gwóźdź",0, 20, 1600,20);
            SeniorDeveloper pawel = new SeniorDeveloper("Paweł", "Stankiewicz",10,30,10000,40);

            Developer[] employees = {pawel, szymon, krzysztof};

            DevelopersTeam developersTeam = new DevelopersTeam(employees);

            for (int i = 0; i < employees.Length; i++)
            {
                developersTeam[i].promoteDeveloper += Developer.PromoteDeveloper;
            }

            for (int i = 0; i < employees.Length; i++)
            {          
                Console.WriteLine(developersTeam[i].Name + " " + developersTeam[i].LastName + " " + "Promotion: " + " " + developersTeam[i].canBePromoted());
            }

            Console.ReadKey();
        }
    }
}
