namespace Array2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ,please enter the amount of numbers you want to enter");
            int amount=int.Parse(Console.ReadLine());
            int[] numbers;
            numbers = new int[amount];
            int BiggestRemainder = 0, CurrentRemainder = 0;
            for (int i = 0;i < amount; i++)
            {
                Console.WriteLine("please enter a integral number and press ENTER");
                numbers[i] = int.Parse(Console.ReadLine());
                CurrentRemainder = numbers[i] % 5;
                BiggestRemainder= BiggestRemainder>CurrentRemainder?BiggestRemainder:CurrentRemainder;
            }
            Console.WriteLine("the biggest remainder is : " + BiggestRemainder);
            Console.WriteLine();
            for(int i = 0;i<amount; i++)
            {
               if (numbers[i] % 5 == BiggestRemainder)
                    Console.WriteLine(numbers[i]);
            }
        }
    }
}
