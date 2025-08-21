namespace octal2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            string numbervisual;
            for(int ialafim=0;ialafim<8;ialafim++)
            for (int imeot = 0;imeot<8;imeot++)
            {
                for (int iasarot = 0; iasarot <8;iasarot++)
                {
                    for (int iyehidim = 0; iyehidim < 8; iyehidim++)
                    {
                        Console.WriteLine(int.Parse("" + ialafim + imeot + iasarot + iyehidim));
                    }
                }
            }

        }
    }
}
