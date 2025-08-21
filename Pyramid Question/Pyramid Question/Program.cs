using System.Data;

namespace Pyramid_Question
{
    internal class Program
    {
        static void Main(string[] args )
        {
            Console.WriteLine("Hello! please enter a positive number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            char star = '*';
            string space = " ";
            int count = 1;
            int inspace = 0;
            int outspace = 0;

            if (number< 0)
            {
                Console.WriteLine("error! please enter a positive number and press ENTER");
                number = int.Parse(Console.ReadLine());
            }
            while (count <= number)
            {
                outspace = number - count;
                while (outspace>0)
                {
                    Console.Write(space);
                    outspace = outspace - 1;
                }
                    if (outspace == 0)
                    Console.Write(star);
                if (count == 1)
                {
                    Console.WriteLine();
                    count = count + 1;
                }
                else
                {
                    inspace = count * 2 - 3;
                    while (inspace > 0)
                    {
                        Console.Write(space);
                        inspace = inspace - 1;
                    }
                    if (inspace == 0)
                        Console.Write(star);
                    Console.WriteLine();
                    count = count + 1;
                }    
            }
           
        }
    }
}
