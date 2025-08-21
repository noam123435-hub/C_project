using System.Diagnostics.Metrics;
using System.Numerics;

namespace if2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Chen! please enter a number");
            int number=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a second number");
            int number2=int.Parse(Console.ReadLine());
            int plus = number + number2;
            if (plus >= 100)
            {
                Console.WriteLine("biger than 100");
            }
            if (plus < 100)
            {
                Console.WriteLine("smaller than 100");
            }
        }
    }
}
