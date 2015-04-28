using System;
using System.IO;
using System.Linq;

namespace _2._4._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textLinesFileA = File.ReadAllLines(@"..\..\FileA.txt");
            string[] textLinesFileB = File.ReadAllLines(@"..\..\FileB.txt");

            //Method 1
            var person = from line in textLinesFileA
                         select new
                         {
                             name = line.Split(',')[0],
                             surname = line.Split(',')[1],
                             pesel = line.Split(',')[2]
                         };

            var bankAccount = from line in textLinesFileB
                              select new
                              {
                                  pesel = line.Split(',')[0],
                                  bankAccountNumber = line.Split(',')[1]
                              };

            var dataBase = from data in person
                           join account in bankAccount on data.pesel equals account.pesel
                           select new
                           {
                               name = data.name,
                               surname = data.surname,
                               pesel = data.pesel,
                               bankAccountNumber = account.bankAccountNumber
                           };

            Console.WriteLine("{0,-10} {1,-10} {2,-12} {3,-12}", "Name:", "Surname:", "PESEL:", "Account number:");
            foreach (var item in dataBase)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-12} {3,-12}", item.name, item.surname, item.pesel, item.bankAccountNumber);
            }

            //Method 2

            var person2 = textLinesFileA
                .Select(i =>
                    new
                    {
                        name = i.Split(',')[0],
                        surname = i.Split(',')[1],
                        pesel = i.Split(',')[2]
                    });

            var bankAccount2 = textLinesFileB
                .Select(i =>
                    new
                    {
                        pesel = i.Split(',')[0],
                        bankAccountNumber = i.Split(',')[1]
                    });

            var dataBase2 = person2
                .Join(bankAccount2, x => x.pesel, y => y.pesel, (x, y) =>
                    new
                    {
                        name = x.name,
                        surname = x.surname,
                        pesel = x.pesel,
                        bankAccountNumber = y.bankAccountNumber
                    });

            Console.WriteLine("\n{0,-10} {1,-10} {2,-12} {3,-12}", "Name:", "Surname:", "PESEL:", "Account number:");
            foreach (var item in dataBase2)
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-12} {3,-12}", item.name, item.surname, item.pesel, item.bankAccountNumber);
            }

            Console.ReadKey();
        }
    }
}
