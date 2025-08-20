namespace diet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age;
            Console.WriteLine("Hello, chen!");
            Console.WriteLine("please enter your age and press ENTER");
            age=int.Parse(Console.ReadLine());
            int weight;
            Console.WriteLine("great, please enter your weight and press ENTER");
            weight=int.Parse(Console.ReadLine());
            int diet;
            diet = weight - 5;
            Console.WriteLine("if you will do a diet and lose 5 kg, you will weigh " + diet + " kg");
            Console.WriteLine("good luck");
        }
    }
}
