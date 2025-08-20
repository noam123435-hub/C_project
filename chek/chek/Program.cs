namespace chek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("please enter a number and press ENTER");
            n =int.Parse(Console.ReadLine());
            int n2;
            n2 = 1;
            int n3 = 1;
            while (n3<=n)
            {
                n2= n2* n3;
                n3 = n3 + 1;
            }
            Console.WriteLine(n2);
            

        }
    }
}