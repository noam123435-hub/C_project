namespace Funcs1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            print();
        }
        static void print()
        {
            Console.WriteLine("Hello, please enter your name and press ENTER");
            string Name = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine((i+1)+" "+Name);
            }
        }
    }
}
