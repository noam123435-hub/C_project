namespace string3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Please enter a Name and press ENTER");
            string name=Console.ReadLine();
            Console.WriteLine("Please enter the letter you want to check");
            char letter = Console.ReadLine()[0];
            int times = 0;
            for (int count = 0; count < name.Length; count++)
            {
                if (name[count] == letter)
                    times++;
            }
            Console.WriteLine("the letter " + letter + " showes " + times + " times");


        }
    }
}
