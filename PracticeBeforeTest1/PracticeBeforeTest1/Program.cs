using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace PracticeBeforeTest1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the word in Hebrew and press ENTER");
            string text= Console.ReadLine();
            string allH = "", allE = "";
            int amount = 0;
            while (text != "enough")
            {
                allH += text+"/";
                Console.WriteLine("please enter the word in english and press ENTER");
                allE+= Console.ReadLine()+"/";
                amount++;
                Console.WriteLine("please enter the word in Hebrew and press ENTER");
                text = Console.ReadLine();
            }
            string[] Hebrew;
            Hebrew = new string[amount];
            int index=0;
            for (int i = 0; i < allH.Length; i++)
            {
                while (allH[i] != '/')
                {
                    Hebrew[index] += allH[i];
                    i++;
                }
                index++;
            }
            string[] English;
            English = new string[amount];
            index = 0;
            for (int i = 0; i < allE.Length; i++)
            {
                while (allE[i] != '/')
                {
                    English[index] += allE[i];
                    i++;
                }
                index++;
            }
            Console.WriteLine("pleae enter a sentence to translate or enough and press ENTER");
            string sentence= Console.ReadLine();
            index = 0;
            string currentword = "";
            bool found=false;
            while(sentence!="enough")
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    currentword = "";
                    while (i<sentence.Length&&(sentence[i] != ' '))
                    {
                        currentword += sentence[i];
                        i++;
                    }
                    index++;
                    found = false;
                    for (int j = 0; j < amount && !found; j++)
                     {
                        if (currentword == Hebrew[j])
                        {
                            Console.Write(English[j]+" ");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.Write(currentword + " ");
                }
                    Console.WriteLine();
                    Console.WriteLine("pleae enter a sentence to translate or enough and press ENTER");
                    sentence = Console.ReadLine();
                
            }
        }
    }
}
