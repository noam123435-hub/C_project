namespace rishoni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter a number and press ENTER");
            int number = int.Parse(Console.ReadLine());
            int n =2;
            bool rishoni=true;
            
            while(rishoni && n<number)
            {
              if(number%n==0)
                  rishoni = false;

                n = n + 1;
            }
            Console.WriteLine(number + (rishoni?" is":" isn't") + " Rishoni");

        }
    }
}
