namespace new_guess_game2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Player! please enter your secret number");
            int secret=int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Hello player! try to guess the secret nummber");
            int guess=int.Parse(Console.ReadLine());
            int n = 1;
            string message = "";

            int priviestdiffrence = 0, currentdiffrence;
            while (guess != secret)
            {
                currentdiffrence = secret - guess;
                if (currentdiffrence < 0)
                currentdiffrence=-currentdiffrence;
                if (n == 1 || currentdiffrence == priviestdiffrence)
                    message = "wrong";
                else
                    message = currentdiffrence < priviestdiffrence ? "warm" : "cool";
                Console.WriteLine(message+", please try again");
                guess = int.Parse(Console.ReadLine());
                n = n + 1;
                priviestdiffrence=currentdiffrence;
            }
            Console.WriteLine("You did it! the right number is "+secret+"! it took you "+n+"guesses");
        }
    }
}
