using System.Runtime.ExceptionServices;

namespace hex1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            bool valid=false;
            bool firstime = true;
            int begin, end;
            while(valid!=true)
            {
                valid = true;
                Console.WriteLine(((firstime)?"":"invalid number, ")+"please enter a valid hexadecimal number and press ENTER");
                 text = Console.ReadLine();
                firstime = false;
                begin= 0;
                while (begin < text.Length && (text[begin] == ' '))
                    begin++;
                end = text.Length-1;
                while (end >=0 && (text[end] == ' '))
                    end--;
                if(begin>end)
                    valid = false;
                for (int i = begin; i < end&&valid; i++)
                {
                    switch(text[i])
                    {
                        case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8': case '9':
                        case 'a': case 'b': case 'c': case 'd': case 'e': case 'f': case 'A': case 'B': case 'C':
                        case 'D': case 'E': case 'F':
                            valid = true;
                            break;
                            default:
                            valid = false;
                            break;
                    }
                }
            }
            Console.WriteLine("Application is done");
        }
    }
}
