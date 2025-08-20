namespace assignment3
{
     internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, please enter the number of seconds required for the countdown");
            int second=int.Parse(Console.ReadLine());

            while(second>=0)
            {
                Console.Clear();
                Console.Write(second);
                await Task.Delay(1000);
                second=second-1;
            }
            Console.Clear();
            Console.WriteLine("the countdown is over");
        }
    }
}
