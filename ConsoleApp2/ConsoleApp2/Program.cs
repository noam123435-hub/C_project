namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the secret number");
            int secret=int.Parse(Console.ReadLine());
            Console.Clear();

            int currentguess = 0;
            int count = 1;
            int diffrence = 0;
            int prediffrence = 0;

            Console.WriteLine("Please try to guess the secret number");
            currentguess = int.Parse(Console.ReadLine());
            while (currentguess!=secret)
            {
                diffrence =secret-currentguess;
                if (diffrence < 0)
                {
                    diffrence = -diffrence;
                }
                if (prediffrence == 0 || prediffrence == diffrence)
                {
                    Console.WriteLine("wrong");
                    count = count + 1;
                }
                else
                {
                    if (diffrence > prediffrence)
                        Console.WriteLine("cold");
                    if (diffrence < prediffrence)
                        Console.WriteLine("warm");

                    count = count + 1;
                }
                prediffrence = diffrence;
                Console.WriteLine("Please try to guess the secret number");
                currentguess = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("you did it! it take you " + count + " guesses");
        }  
        
    }
}
