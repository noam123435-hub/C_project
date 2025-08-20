namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter another number and press ENTER");
            int secondnumber=int.Parse(Console.ReadLine());

            if (number%secondnumber==0)
                Console.WriteLine("The number "+ secondnumber+" is a multiple of the number "+number);
            if (secondnumber % number == 0)
                Console.WriteLine("The number " + number + " is a multiple of the number " + secondnumber);
            if(number % secondnumber != 0 && secondnumber % number != 0)
                Console.WriteLine("These numbers are not multiples of each other");
        }
    }
}
