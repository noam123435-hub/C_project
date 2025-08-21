namespace zugi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, player! please enter the number and press ENTER");
            int number=int.Parse(Console.ReadLine());
            Console.WriteLine("the number "+number+(number%2==0?" is":" isn't")+" even number");


        }
    }
}
