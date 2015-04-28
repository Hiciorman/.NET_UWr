using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " a  ,-b A";
            bool isPalindrome = s.IsPalindrome();
            Console.WriteLine(isPalindrome);
            Console.ReadKey();
        }
    }

    public static class StringExtension
    {
        public static bool IsPalindrome(this String text)
        {
            string s  = Regex.Replace(text.ToLower(), @"[^\w]", string.Empty);
            return Enumerable
                .SequenceEqual(s.ToCharArray(), s.ToCharArray().Reverse());
        }
    }
}
