using System.ComponentModel.Design;

namespace grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, student! plase enter your first grade");
            int message = int.Parse(Console.ReadLine());
            int best = 0;
            int worst = 100;
            int sum=0;
            int count=0;
            int average=0;

            while (message != 1)
            {
                if (message < 0 || message > 100)
                    Console.WriteLine("error plaese try again");
                else
                {
                    if (message < worst)
                    {
                        worst = message;
                    }
                    if (message > best)
                    {
                        best = message;
                    }
                    count = count + 1;
                    sum = sum + message;
                }

                Console.WriteLine("Hello, student! plase enter another grade");
                message = int.Parse(Console.ReadLine());
            }
            average = sum / count;
            Console.WriteLine("your average is " + average + ", your best grade is " + best + ", and your worst grade is " + worst);
        }
    }
             
}
