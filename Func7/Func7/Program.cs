namespace Func7
{
    internal class Program
    {
        static void Main(string[] args)
        {
         Console.WriteLine(number10()+(number5()*number3()));
        }
        static int number10()
        {
            return 10;
        }
        static int number5()
        {
            return 5;
        }
        static int number3()
        {
            return 3;
        }
    }
}
