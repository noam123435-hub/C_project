namespace WithAndWithoutBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            do
            {
                Console.WriteLine("please enter an integral number and press ENTER");
                number = int.Parse(Console.ReadLine());
            } while (number != 20);
        }
    }
}
