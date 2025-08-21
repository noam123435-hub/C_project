using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Sures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a integer number and press ENTER");
            int number = int.Parse(Console.ReadLine());
            int n = 0;
            bool shoresh = false;

            while (n * n <number)
            { 
                    n = n + 1;
                }
            // if (n * n == number)
            //    Console.WriteLine("the root of " + number + " is " + n);
            //   else
            //    Console.WriteLine(number + " has not integer root"); 
            String message = "";
            message = (n * n == number) ? "the root of " + number + " is " + n : number + " has not integer root";
            Console.WriteLine(message);
        }
           

             

        
    }
}
