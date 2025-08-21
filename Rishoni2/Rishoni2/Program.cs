namespace Rishoni2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a intehger number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            bool rishoni = true;
            int divider = 2;

            while(divider<number)
            {
                if (number % divider == 0)
                {
                    rishoni = false;
                    Console.WriteLine("the number divide by " + divider);
                }
                divider = divider + 1;
            }
            if (rishoni == true)
                Console.WriteLine("the number " + number + " is Rishoni");
            else
                Console.WriteLine("so the number " + number + " isn't Rishoni");
        }
    }
}
