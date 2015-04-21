using System;

namespace _2._1._5
{
    /// <summary>
    /// Klasa zawiera algorytm do sprawdzania czy liczba x 
    /// jest podzielna przez sumę swoich składników oraz przez każdy składnik z osobna
    /// </summary>
    public class Algorytm
    {
        private const int Max = 100000;

        /// <summary>
        /// Metoda sprawdza czy podana liczba spełnia warunki
        /// </summary>
        /// <param name="x">Liczba do sprawdzenia</param>
        /// <returns>True jeśli x spełnia warunki</returns>
        private static bool Sprawdz(int x)
        {
            var temp = x;
            var sum = 0;
            while (temp != 0)
            {
                sum += temp % 10;
                if (temp % 10 != 0 && x % (temp % 10) != 0)
                {
                    return false;
                }
                temp /= 10;
            }
            return sum == 0 || x % sum == 0;
        }

        /// <summary>
        /// Metoda wypisuje liczby które spełniają warunki
        /// </summary>
        public static void Wypisz()
        {
            for (var i = 1; i < Max; i++)
            {
                if (Sprawdz(i))
                {
                    Console.Write("{0} ", i);
                }
            }
        }

    }
}
