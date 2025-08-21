namespace new_guess_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, secret player! please enter your secret number and press ENTER");
            int secret=int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("please guess the secret number");
            int guess=int.Parse(Console.ReadLine());
            int n = 1;
            string message = "";
            int preventdiffrence = 0, currentdiffrence;

            
            while(guess!=secret)
            {
                currentdiffrence = secret - guess;
                if (currentdiffrence < 0)
                    currentdiffrence = -currentdiffrence;
               
                if (n == 1 || preventdiffrence == currentdiffrence)
                    message = "wrong";
                else
                   message = currentdiffrence < preventdiffrence ? "warm" : "cool";
                Console.WriteLine(message + ", please try again");
                guess= int.Parse(Console.ReadLine());
                n = n + 1;
                preventdiffrence = currentdiffrence;
            }

            Console.WriteLine("correct! you guessed the secret number with " + n + " guesses");
        }
    }
}
