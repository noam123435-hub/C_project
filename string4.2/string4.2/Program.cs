namespace string4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a text and press ENTER");
            string text=Console.ReadLine();
            bool palindrom = true;
            for(int start=0,end=text.Length-1;start<end&&palindrom;start++,end--)
            {
                if (text[start] != text[end])
                    palindrom = false;
            }

            Console.WriteLine(palindrom ? "palindrom" : "not palindrom");
        }
    }
}
