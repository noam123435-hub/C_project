namespace else1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number;
            number = 1;
            while (number<=100)
            {
                if (number % 2 == 0)
                {
                    if (number % 6 == 0)
                    {
                        Console.WriteLine("boom");
                    }
                    else
                    {
                        Console.WriteLine(2);
                    }
                }
                else
                {
                    if (number % 3 == 0)
                    {
                        Console.WriteLine(3);
                    }
                    else
                    {
                        Console.WriteLine(number);
                    }
                }
                number = number + 1;
            }
        }
    }
}
