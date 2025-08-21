namespace string2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter yout name and press ENTER");
            string name=Console.ReadLine();
            string versname = "";
            for (int i = (name.Length) - 1; i >= 0; i--)
            {
                versname += name[i];
            }
            Console.WriteLine(versname);
           
        }
    }
}
