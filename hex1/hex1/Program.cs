using System.Security.Cryptography.X509Certificates;

namespace hex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text;
            bool correct = false;
            bool firstime = true;
            int begin, end;
                while (correct != true)
                {
                    correct = true;
                    Console.WriteLine(((firstime)?"":"invalid number, ")+"please enter a hex number and press ENTER");
                    text = Console.ReadLine();
                    firstime = false;
                    begin = 0;
                     while ((begin<text.Length)&&(text[begin]==' '))
                        begin++;
                    end= text.Length-1;
                    while((end>=0)&&text[end] == ' ')
                        end--;
                    if(begin>end)
                      correct = false;
                for (int i = begin; i <=end&&correct; i++)
                {
                    switch (text[i])
                    {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                        case 'a':
                        case 'A':
                        case 'b':
                        case 'B':
                        case 'c':
                        case 'C':
                        case 'd':
                        case 'D':
                        case 'e':
                        case 'E':
                        case 'f':
                        case 'F':
                            correct = true;
                            break;
                        default:
                            correct = false;
                            break;
                    }
                }
            }
            Console.WriteLine("the text is correct");
        }
    }
}
