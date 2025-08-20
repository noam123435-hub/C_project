namespace first_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            int divider=2;
            bool rishoni = true;
            while (rishoni && divider<number)
            {
                if (number % divider == 0)
                    rishoni = false;
                divider=divider+1;
            }
            if (rishoni)
                Console.WriteLine(number + " is Rishoni");
            else
                Console.WriteLine(number + " isn't rishoni");
               
        }
    }
}
