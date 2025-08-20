using System.Xml.Schema;

namespace Double1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter a number and press ENTER");
            string text = Console.ReadLine();
            string all = "";
            int count = 0;
            double number, average=0;
            while (text != "enough")
            {
                number = double.Parse(text);
                all += number+"/";
                average += number;
                count++;
                Console.WriteLine("please enter another number and press ENTER");
                text = Console.ReadLine();
            }
            average /= count;
            Console.WriteLine("the average is "+average);
            Console.WriteLine();
            int sindex = 0;
            string CurrrentNumber;
            for(int i=0;i<count;i++)
            {
                CurrrentNumber = "";
                while (all[sindex]!='/')
                {
                    CurrrentNumber += all[sindex];
                    sindex++;
                }
                number= double.Parse(CurrrentNumber);
                if (number > average)
                    Console.WriteLine(number);
                sindex++;
            }
        }
    }
}
