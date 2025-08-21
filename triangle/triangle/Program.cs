namespace triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a integral number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            int linenumber = 1;
            int star = 1;
            string line = "*";
            while (linenumber <=number)
            {
                Console.WriteLine(line);
                line += "*";
                linenumber++;
            }
        }
    }
}
