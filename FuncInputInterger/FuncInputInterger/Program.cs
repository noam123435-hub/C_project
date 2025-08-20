using System.Net.Http.Headers;

namespace FuncInputInterger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter your age and press ENTER");
            int age = inputInterger("your age");
            Console.WriteLine("please enter your weight and press ENTER");
            int weight = inputInterger("your weight");
            Console.WriteLine("your age is "+age+" and your weight is "+weight);
            }
        static int inputInterger(string message)
        {
            string kelet = Console.ReadLine();
            bool valid = false;
            int number=0,result=0 ,times=1;
            int begin,end;
            while(!valid)
            {
                valid = true;
                begin = 0;
            while ((begin < kelet.Length) && (kelet[begin]==' '))
                begin++;
                end = kelet.Length - 1;
            while ((end >= 0) && (kelet[end] ==' ')) 
                end--;
            if(begin>end)
                valid = false;
                for (int i = end; i >= begin && valid; i--)
                {
                    switch (kelet[i])
                    {
                        case '0':
                            number = 0;
                            break;
                        case '1':
                            number = 1;
                            break;
                        case '2':
                            number = 2;
                            break;
                        case '3':
                            number = 3;
                            break;
                        case '4':
                            number = 4;
                            break;
                        case '5':
                            number = 5;
                            break;
                        case '6':
                            number = 6;
                            break;
                        case '7':
                            number = 7;
                            break;
                        case '8':
                            number = 8;
                            break;
                        case '9':
                            number = 9;
                            break;
                        default:
                            valid = false;
                            break;
                    }
                    if (valid)
                    {
                        result += (number * times);
                        times *= 10;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("invalid, please enter "+message+" and press ENTER");
                    kelet = Console.ReadLine();
                    times = 1;
                    result = 0;
                }
            }
            return result;
        }
    }
}
