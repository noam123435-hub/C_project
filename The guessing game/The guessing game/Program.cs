namespace The_guessing_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, friend! please choose a secret number");
            Console.WriteLine("the number must be 1-100, hit the number and press ENTER");
            int secret;
             secret=int.Parse(Console.ReadLine());


            Console.WriteLine("Hello Player! please try to guess the secret number");
            int guess= int.Parse(Console.ReadLine());
            int n;
            n = 1;
            int olddiffrence, newdifference;
            olddiffrence = 0;
            string message="";

            while (guess != secret)
            {
                newdifference = guess - secret;
                if (newdifference < 0)
                {
                    newdifference = - newdifference;
                }
                if (n == 1)
                {
                    Console.WriteLine("wrong");
                }
                else
                {
                    if (newdifference == olddiffrence)
                    {
                        message = "wrong";
                    }
                    else
                    {
                        if(newdifference>olddiffrence)
                        message = "cool";
                        if (newdifference < olddiffrence)
                            message = "warm";
                    }
                    
                }
                Console.WriteLine(message+" please try again");
                guess=int.Parse(Console.ReadLine());
                n = n + 1;
                olddiffrence = newdifference;
            }
            Console.WriteLine("correct! the number is " + secret + ". It took you " + n + " guesses");
        }

        


    }
}
