namespace Average_question
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a number and press ENTER (press -1 to exit)");
            double number = double.Parse(Console.ReadLine());
            int count = 0;
            double sum = 0;
            double lowest = number;
            double highest = number;

            while(number!=-1)
            {
                if(highest<=number)
                    highest = number;
                if(lowest>=number)
                    lowest = number;

                sum = sum + number;
                Console.WriteLine("please enter another number and press ENTER (press -1 to exit)");
                number = int.Parse(Console.ReadLine());
                count = count + 1;
               
            }
            if (number == -1)
            {
                double average = sum / count;
                Console.WriteLine("the average is " + average);
                Console.WriteLine("the highest number is " + highest + ", and the lowest number is " + lowest);
            }
            
            
        }
    }
}
