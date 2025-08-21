namespace machrozet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a number, and press ENTER");
            int number=int.Parse(Console.ReadLine());
            Console.Clear();

            if (number < 100 && number > 0)
                Console.WriteLine("the number " + number + " bigger than 0 and smaller than 100");
            else
            {
                if (number > 100)
                    Console.WriteLine("the number " + number + " bigger than 100");
                else
                    Console.WriteLine("the number " + number + " smaller than 0");
            }
        }
    }
}
