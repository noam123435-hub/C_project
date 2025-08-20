namespace Func8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter the text to upper and press ENTER");
            string Text=Console.ReadLine();
            Console.WriteLine(toUpperText(Text));
        }
        static string toUpperText(string text)
        {
            string UpperText = "";
            for(int i=0;i<text.Length;i++)
            UpperText += toUpperChar(text[i]);
            return UpperText;
        }
        static char toUpperChar(char tav)
        {
            string LowerCase = "abcdefghijklmnopqrstuvwxyz";
            string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < LowerCase.Length; i++)
            {
                if (LowerCase[i] == tav)
                    return Uppercase[i];
            }
            return tav;
        }
    }
}
