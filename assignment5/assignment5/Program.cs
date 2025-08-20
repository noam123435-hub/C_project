namespace assignment5
{
    maun class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter number and press ENTER");
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int n = 0;

            while (number > 0)
            {

                if (number > 1000)
                {
                    n = (number % 1000)*1000;
                    number = number / 10;
                }
               if(number >100)
                {
                    n = (number % 100) * 100;
                    number = number / 10;
                }
                if (number > 10)
                {
                    n = (number % 10) * 10;
                    number = number / 10;
                }
                if(number<0)
                {
                    n = number;
                    number = number / 10;
                }
                sum = sum + n;
            }
            Console.WriteLine("The sum of your number's digits is " + sum);
        }
    }
}
