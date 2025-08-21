namespace Funcs2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            lup();
        }
        static void print()
        {
            Console.WriteLine("Noam");
        }
        static void lup()
        {
            for (int i = 0; i < 20; i++)
                print();
        }
    }
}
