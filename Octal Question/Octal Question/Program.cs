namespace Octal_Question
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            int firstjump = 78;
            int secongjump = 778;

            while (number <= 7777)
            {
                while (number % 10 > 7)
                {
                    if (number == secongjump)
                    {
                        number = number + 222;
                        firstjump= number+78;
                        secongjump = secongjump + 1000;
                        Console.WriteLine(number);
                    }
                    if (number == firstjump)
                    {
                        number = number + 22;
                        firstjump = firstjump + 100;
                        Console.WriteLine(number);
                    }
                    number = number + 1;
                }
                Console.WriteLine(number);
                number = number + 1;
            }
        }
    }
}
