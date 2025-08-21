namespace triangle2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plese enter an integral number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            string stars = "*";
            for (int row = 0; row < number; row++)
            {
                Console.WriteLine(stars);
                stars += "*";
            }
        }
    }
}
