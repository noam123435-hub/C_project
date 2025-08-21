using System.Runtime.CompilerServices;

namespace ttt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number between 0-1000 and press ENTER");
            int number=int.Parse(Console.ReadLine());
            int n = number - number % 100;
           switch(n)
            {
                default:
                    Console.WriteLine("close");
                    break;
                case 700:
                    Console.WriteLine("almost close");
                    break;
                case 800:
                    Console.WriteLine("far");
                    break;
                case 900:
                case 1000:
                    Console.WriteLine("far away");
                    break;
            }
        }
    }
}
