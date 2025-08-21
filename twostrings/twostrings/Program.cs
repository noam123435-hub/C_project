using System.Globalization;

namespace twostrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! please enter a text and press ENTER");
            string FirstText = Console.ReadLine();
            Console.WriteLine("please enter another text and press ENTER");
            string SecondText = Console.ReadLine();
            bool yesh = false;
            for (int i = 0; i < FirstText.Length - (SecondText.Length - 1) && !yesh; i++)
            {
                yesh=true;
                for(int n = 0; n < SecondText.Length&&yesh; n++)
                    {
                    if (SecondText[n] != FirstText[i+n])
                        yesh=false;
                    }
            }
            if (yesh)
              Console.WriteLine("found");
            else
                Console.WriteLine("isn't found");
        }
    }
}
