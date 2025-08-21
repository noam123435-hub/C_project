namespace if3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a  number and press ENTER");
            double number=double.Parse(Console.ReadLine());
            Console.WriteLine("Hello! please enter second and smaller number and press ENTER");
            double number2=double.Parse(Console.ReadLine());
            double sum=number+number2;
            double minus = number - number2;
            if (sum > 10.5)
            {
                if (minus < 5.3)
                {
                    Console.WriteLine(number + "+" + number2 + ">10.5 and " + number + "-" + number2 + "<5.3");

                }
            }


        }
    }
}
