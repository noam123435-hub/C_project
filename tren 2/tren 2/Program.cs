namespace tren_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter an number and press ENTER");
            int n1, t, biggest;
            t = 0;
            biggest=int.Parse(Console.ReadLine());
            while (t < 9)
            {
                Console.WriteLine("please enter an number and press ENTER");
                n1 =int.Parse(Console.ReadLine());
                biggest=biggest>n1 ? biggest : n1;
                t = t + 1;
            }
            Console.WriteLine(biggest);
        }
    }
}
