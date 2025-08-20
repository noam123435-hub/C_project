namespace CastingString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, pleae enter a sentence and press Enter");
            string input=Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
                Console.WriteLine((int)input[i]);
        }
    }
}
