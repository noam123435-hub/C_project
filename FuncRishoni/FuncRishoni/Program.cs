namespace FuncRishoni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter a integral number and press ENTER");
            int Number=int.Parse(Console.ReadLine());
            Console.WriteLine("the number "+Number+((isRishoni(Number)) ? " is " : " isn't ")+ "Rishoni");
        }
        static bool isRishoni(int num)
        {
            bool result = true;
            for(int divider=2;divider<num&&result;divider++)
            {
                if(num%divider==0)
                    result = false;
                //result=!(num%divider==0); אופציה נוספת

            }
            return result;
        }
    }
}
