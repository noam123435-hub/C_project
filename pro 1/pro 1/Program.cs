using System.Numerics;

namespace pro_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Please enter number and press ENTER");
            number = int.Parse(Console.ReadLine());
            int age;
            Console.WriteLine("great, please enter your age");
            age=int.Parse(Console.ReadLine());
            int x;
            x= number * age;
            Console.WriteLine("your age double the number you chose is "+ x);






        }
    }
}
