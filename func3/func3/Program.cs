namespace func3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            printName("Noam", 10);
            printName("Lemel",5);
        }
        static void printName(string Name, int time)
        {
            for (int i=0; i < time; i++)
                Console.WriteLine(Name);

        }
    }
}
