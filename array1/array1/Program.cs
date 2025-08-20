namespace array1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers;
            numbers = new double[10];
            double average = 0;
            bool FirsTime = true;
            for (int i = 0;i<10;i++)
            {
                Console.WriteLine((FirsTime?"Hello,":"")+"please enter a number and press ENTER");
                numbers[i] =double.Parse(Console.ReadLine());
                average += numbers[i];
                FirsTime = false;
            }
            average /= 10;
            Console.WriteLine("the average is : "+ average);
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                if (numbers[i] > average)
                    Console.WriteLine(numbers[i]);
            }
        }
    }
}
