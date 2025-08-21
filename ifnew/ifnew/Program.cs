namespace ifnew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter your name and press ENTER");
            string yourname;
            yourname = Console.ReadLine();
            string myname ="noam";
            if (yourname == myname)
            {
                Console.WriteLine("we have the same name");

            }
            if (yourname != myname)
            {
                Console.WriteLine("we havn't the same name");

            }
        }
    }

}
