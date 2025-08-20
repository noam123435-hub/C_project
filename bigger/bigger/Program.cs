namespace bigger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a integer number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter another number and press ENTER");
            int secondnumber=int.Parse(Console.ReadLine());

            if (number < secondnumber)
                Console.WriteLine("the number "+secondnumber+" is bigger than "+number);
            else 
                Console.WriteLine("the number "+number+" is bigger than " + secondnumber );

        }
    }
}
