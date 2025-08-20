namespace fff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter number and press ENTER");
            int newnumber = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = newnumber;
            int n = 0;

            if (number > 0)
            {
                if (number > 100)
                {
                    n = (number % 10);
                    number = number / 10;
                    sum = sum + n;
                }
                if (number > 10)
                {
                    n= (number % 10);
                    number = number / 10;
                    sum = sum + n;
                }
                if (number < 10)
                    sum = sum + number;
            }
            Console.WriteLine("The opposite number is " + sum);
            if (newnumber==sum)
                Console.WriteLine("the number "+newnumber+" is Shemesh");
            


        }
    }
}
