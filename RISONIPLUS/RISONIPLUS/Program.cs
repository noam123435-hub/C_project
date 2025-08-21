namespace RISONIPLUS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int divider;
            bool rishoni=true;
            int number = 2;
            while (number<=100)
            {
                divider = 2;
                rishoni = true;
                while(rishoni&&number>divider)
                { 
                    if(number%divider==0)
                    rishoni = false;
                    divider++;
                }
                if(rishoni)
                Console.WriteLine(number);
                number++;
            }
        }
    }
}
