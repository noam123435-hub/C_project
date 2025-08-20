namespace doublenumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Hello, Chen!");
            Console.WriteLine("Please enter a number and press ENTER");
            number=int.Parse(Console.ReadLine());
            int numberx;
            numberx = number * number;
            Console.WriteLine("If you multiply your number by itself you will get " + numberx);

        }
    }
}
