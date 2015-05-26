using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._1
{
    public class Complex : IFormattable
    {
        private double real;
        private double imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
        }
        
        public static Complex operator *(Complex c1, Complex c2)
        {
            double real = (c1.real * c2.real) - (c1.imaginary * c2.imaginary);
            double complex = (c1.imaginary * c2.real) + (c1.real * c2.imaginary);
            return new Complex(real, complex);
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            double real = (c1.real * c2.real + c1.imaginary * c2.imaginary) /
                (c2.real * c2.real + c2.imaginary * c2.imaginary);
            double complex = (c1.imaginary * c2.real - c1.real * c2.imaginary) /
                (c2.real * c2.real + c2.imaginary * c2.imaginary);
            return new Complex(real, complex);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "w":
                    return String.Format("[{0},{1}]", real, imaginary);
                case "d":
                default:
                    return String.Format("{0}+{1}i", real, imaginary);
            }
        }
    }
}
