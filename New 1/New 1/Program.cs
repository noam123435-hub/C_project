namespace New_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Please enter your name and press ENTER");
            name = Console.ReadLine();
            Console.WriteLine("Hello "+ name);
            Console.WriteLine("Where are you from?");
            string locaition;
            locaition = Console.ReadLine();
            string age;
            Console.WriteLine("Interesting, and How old are You?");
            age = Console.ReadLine();
            Console.WriteLine("So Your name is " + name + ", You are " +age + "Years old"+  ", and from " + locaition);
            Console.Write(" Nice to meet you");
           

        }
    }
}
    