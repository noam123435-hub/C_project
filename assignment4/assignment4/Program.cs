namespace assignment4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello! please enter the number of second and press ENTER");
            int i = int.Parse(Console.ReadLine());

            while(i>0)
            {
                Console.Clear();
                Console.WriteLine(i);
                await Task.Delay(1000);
                i = i - 1;
            }
            Console.Clear();
            Console.WriteLine("the countdown is over");
           
        }
    }
}
