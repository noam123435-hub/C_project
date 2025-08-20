namespace Continue
{
    internal class Program
    {
        static void Main(string[] args)
        {
          for(int i=1; i<=100;i++)
            {
                if (i == 23)
                    continue;
                Console.WriteLine(i);
            }
        }
    }
}
