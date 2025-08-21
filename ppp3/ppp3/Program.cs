namespace ppp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while(n<=7777)
            {
                if (n % 1000 == 778)
                    n = n + 222;
                else
                {
                    if (n % 100 == 78)
                        n = n + 22;
                    else  if (n % 10 == 8)
                              n = n + 2;
                }

                Console.WriteLine(n);
                n = n + 1;
            }
        }
    }
}
