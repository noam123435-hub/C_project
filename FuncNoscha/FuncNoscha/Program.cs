namespace FuncNoscha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello please enter the value of the variable X and press ENTER");
            int X=int.Parse(Console.ReadLine());
            Console.WriteLine("Hello please enter the value of the variable Y and press ENTER");
            int Y = int.Parse(Console.ReadLine());
            Console.WriteLine("Hello please enter the value of the variable Z and press ENTER");
            int Z = int.Parse(Console.ReadLine());
            Console.WriteLine(minus(divide(plus(X,(hezka((plus(Y, n20())),n3()))), plus(Z, multiply(Z, X))),
                plus(divide(Y,Z),atzeret(plus(n5(), (divide(Y, Z)))))));
        }
        static int n20()
        {
            return 20;
        }
        static int n5()
        {
            return 5;
        }
        static int n3()
        {
            return 3;
        }
        static int plus(int a,int b)
        {
            return a + b;
        }
        static int hezka(int basis, int maarich)
        {
            int result = 1;
            for (; maarich>0; maarich--)
                result *= basis;
            return result;
        }
        static int divide(int a, int b)
        {
            return a / b;
        }
        static int multiply(int a,int b)
        {
            return a * b;
        }
        static int minus(int a, int b)
        {
            return a - b;
        }
            static int atzeret(int number)
        {
            int atzeret = 1;
            for(int i=2;i<=number;i++)
                atzeret*=i;
            return atzeret;
        }
    }
}
