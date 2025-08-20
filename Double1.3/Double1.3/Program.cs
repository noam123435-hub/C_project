namespace Double1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter a number and press ENTER");
            string text = Console.ReadLine();
            int count = 0;
            string all = "";
            double number = 0,Average=0;
            while(text!="enough")
            {
                number=double.Parse(text);
                all += number+"/";
                Average += number;
                count++;
                Console.WriteLine("Hello, please enter a number and press ENTER");
                text = Console.ReadLine();
            }
            Average/=count;
            Console.WriteLine("the average is : " + Average);
            Console.WriteLine();
            int sindex=0;
            string currentnumber = "";
            for(int i = 0;i<count;i++)
            {
                currentnumber = "";
                while(all[sindex] != '/')
                {
                    currentnumber += all[sindex];
                    sindex++;
                }
                number=double.Parse(currentnumber);
                if(number>Average)
                    Console.WriteLine(number);
                sindex++;
            }
        }
    }
}
