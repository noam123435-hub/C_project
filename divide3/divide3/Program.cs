namespace divide3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a integer number and press ENTER");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("the number " + number + (number % 3 == 0 ? " is" : " isn't") + " divide by 3");
        }
    }
}
