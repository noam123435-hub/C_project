using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StringPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a text and press ENTER");
            string text=Console.ReadLine();
            Console.WriteLine("please enter a text to look up and press ENTER");
            string ToLookUp=Console.ReadLine();
            bool found=false;
            for(int i=0; i<text.Length-(ToLookUp.Length-1)&&!found;i++)
            {
                found = true;
                for(int index=0;index<ToLookUp.Length&&found;index++)
                {
                    if (ToLookUp[index] != text[i + index])
                        found = false;
                }
            }
            if (found)
                Console.WriteLine("found");
            else
                Console.WriteLine("not found");
        }
    }
}
