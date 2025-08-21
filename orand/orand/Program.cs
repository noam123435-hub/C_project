namespace orand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a number and press ENTER");
            double n1, n2;
            string input;
            input = Console.ReadLine();
            n1 = double.Parse(input);
            Console.WriteLine("please enter a number and press ENTER");
            input = Console.ReadLine();
            n2 = double.Parse(input);

            double sum;
            double dif;
            sum=n1 + n2;
            dif = n1 - n2;

            if (sum > 10.5 && dif < 5.3)
                Console.WriteLine(n1 + "+" + n2 + ">10.5 and" + n1 + "-" + n2 + "<5.3");
            else
                Console.WriteLine(n1 + "+" + n2 + "<10.5 and" + n1 + "-" + n2 + ">5.3");

        }
    }
}
