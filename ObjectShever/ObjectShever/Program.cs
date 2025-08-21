using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace ObjectShever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction First=new Fraction();
            First.init(4, 8);
            First.print();
            Console.WriteLine(First.toDouble());
            Fraction Second=new Fraction();
            Second.init(2, 5);
            Second.print();
            Fraction together=new Fraction();
            together=First.add(Second);
            together.print();
            Fraction multiply=new Fraction();
            multiply=First.multiply(Second);
            multiply.print();
            Fraction divide=new Fraction();
            divide=Fraction.divide(First, Second);
            divide.print();
          
        }
    }
    class Fraction
    {
        int numerator;
        int denominator;
     public void init(int num, int den)
        {
           this.numerator = num;
           this.denominator = den;
            this.reduction();
        }
        public void print()
        {
            Console.WriteLine(this.numerator + "/" + this.denominator);
        }
        public double toDouble()
        {
            double divided = this.numerator;
            double divider=this.denominator;
            return divided / divider;
        }
        public void reduction()
        {
            int divider=(this.numerator>this.denominator)?this.numerator:this.denominator;
            bool isReduced=false;
            for(;(divider>1)&&!isReduced;divider--)
            {
                if((this.numerator%divider==0)&&(this.denominator%divider==0))
                {
                    this.numerator/=divider;
                    this.denominator/=divider;
                    isReduced = true;
                }
            }
        }
        public Fraction add(Fraction other)
        {
            Fraction result = new Fraction();
            if (this.denominator == other.denominator)
            {
                result.denominator = this.numerator;
                result.numerator = this.denominator + other.numerator;
            }
            else
            {
                result.denominator = other.denominator * this.denominator;
                result.numerator = ((this.numerator) * (result.denominator / this.denominator)) + ((other.numerator) * (result.denominator / other.denominator));
            }
            result.reduction();
            return result;
        }
        public Fraction multiply(Fraction other)
        {
            Fraction result = new Fraction();
            result.numerator = this.numerator * other.numerator;
            result.denominator = this.denominator * other.denominator;
            result.reduction();
            return result;
        }
        public static Fraction divide(Fraction first,Fraction second)
        {
            Fraction result= new Fraction();
            result.numerator = first.numerator * second.denominator;
            result.denominator= first.denominator * second.numerator;
            result.reduction();
            return result;
        }
    }
}
