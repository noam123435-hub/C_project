namespace Double1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter an integral number and press ENTER");
            string text=Console.ReadLine();
            int count = 0;
            double average=0,Currentnumber=0;
            string Allnumber = "",number="";
            while(text!="enough")
            {
                Currentnumber=double.Parse(text);
                Allnumber += Currentnumber+"/";
                average += Currentnumber;
                count++;
               Console.WriteLine("please enter an integral number and press ENTER");
               text = Console.ReadLine();
            }
            average/=count;
            Console.WriteLine("the average is : "+average);
            Console.WriteLine();
            int sindex = 0;
            string num = "";
            for (int i = 0; i < count; i++)
            {
                num = "";
                while(Allnumber[sindex]!='/')
                {
                    num+=Allnumber[sindex];
                    sindex++;
                }
                Currentnumber = double.Parse(num);
                if (Currentnumber>average)
                    Console.WriteLine(Currentnumber);
                sindex++;
            }
        }
    }
}
