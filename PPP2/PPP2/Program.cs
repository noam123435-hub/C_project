using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

namespace PPP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the hight of the pyramide and press ENTER");
            int number = int.Parse(Console.ReadLine());
            int h = number;
            int outspace = h;
            int inspace = number - h;
            string space = " ";
            string star = "*";
            while (outspace > 0)
            {
                if (h == number)
                {
                    while (outspace > 0)
                    {
                        Console.Write(space);
                        outspace = outspace - 1;
                    }
                    Console.Write(star);
                }
                else
                {
                    while (outspace > 0)
                    {
                        Console.Write(space);
                        outspace = outspace - 1;
                    }   
                    Console.Write(star);
                    while (inspace > 0)
                    {
                        Console.Write(space);
                        inspace = inspace - 1;
                    }
                    Console.Write(star);
                }
                Console.WriteLine("");
                h = h - 1;
                outspace = h;
                inspace = (number - h)*2-1;
            }
        }
    }
}
