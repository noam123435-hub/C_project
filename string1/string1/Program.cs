namespace string1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter your name and press ENTER");
            string name=Console.ReadLine();
            for(int i=0;i<name.Length;i++)
                Console.WriteLine(name[i]);
        }
    }
}
