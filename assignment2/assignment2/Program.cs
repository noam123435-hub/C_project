namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter your year of birth and press ENTER");
            int birth=int.Parse(Console.ReadLine());
            int year = 2025;
            int age=year-birth;
            Console.WriteLine("your age is " + age + " years old");

        }
    }
}
