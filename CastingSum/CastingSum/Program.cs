namespace CastingSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number, average = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("please enter a integral number and press ENTER");
                number=int.Parse(Console.ReadLine());
                average += number;
            }
            Console.WriteLine("the average is : "+(double)average/10);
        }
    }
}
