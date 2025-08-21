namespace Hezka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter second nunber and press ENTER");
            int secondnumber=int.Parse(Console.ReadLine());
            int n =0;
            int kefel=1;

            while(n<secondnumber)
            {
                kefel = kefel * number;
                n = n + 1;
            }
            Console.WriteLine(kefel);

        }
    }
}
