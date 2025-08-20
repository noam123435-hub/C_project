namespace Args_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0.0;
            if (args.Length == 1)
            {
                string[] numbers = args[0].Split(',');
                for (int i = 0; i < numbers.Length; i++)
                    sum += double.Parse(numbers[i]);
                Console.WriteLine(sum);
            }
        }
    }
}
