namespace practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line="";
            for (int linenumber = 1, n; linenumber <= 10; linenumber++)
            {
                for (int count =0; count < 10; count++)
                {
                    n = (count + 1) * linenumber;
                    Console.Write(n + ((n < 10)? "  " : " "));
                }
                Console.WriteLine();
            }
            
        }
    }
}
