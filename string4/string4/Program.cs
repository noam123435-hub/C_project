namespace string4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a text and press ENTER");
            string text=Console.ReadLine();
            string upsidedown = "";
            for(int index=(text.Length)-1;index>=0;index--)
            {
                upsidedown += text[index];
            }
            Console.WriteLine("The text "+(text==upsidedown?"is":"isn't")+" polindrom");
        }
    }
}
