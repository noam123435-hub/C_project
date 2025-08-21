namespace PPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the secret number and press ENTER");
            int secret=int.Parse(Console.ReadLine());
            int n = 1;
            Console.Clear();
            Console.WriteLine("Hello player, try to guess the secret number");
            int guess=int.Parse(Console.ReadLine());
            int currentdiff, lastdiff=0;
            while (guess != secret)
            {
                currentdiff=secret-guess;
                if (currentdiff < 0)
                    currentdiff = -currentdiff;
                if (n == 1 || lastdiff == currentdiff)
                    Console.WriteLine("wrong! try again");
                else
                    Console.WriteLine(lastdiff < currentdiff ? "Cold! try again" : "warm! try again");
                guess= int.Parse(Console.ReadLine());
                lastdiff = currentdiff;
                n = n + 1;
            }
            Console.WriteLine("You right, you guessed the secret number in " + n + " guesses");
            }
    }
}