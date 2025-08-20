namespace Arraydictionary2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello please enter the amount of Definitions and press ENTER");
            int amount = int.Parse(Console.ReadLine());
            string[] Definitions;
            Definitions = new string[amount];
            string[] Translates;
            Translates = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine("please enter the Definition and press enter");
                Definitions[i] = Console.ReadLine();
                Console.WriteLine("please enter the Translate and press enter");
                Translates[i] = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("please enter the sentence you would like to translate Or 'enough' to finish and press ENTER");
            string input = Console.ReadLine();
            string CurrentWord;
            int index = 0;
            bool found = false;
            while (input!="enough")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    CurrentWord = "";
                    while (i<input.Length&&(input[i] == ' '))
                        i++;
                    while (i < input.Length && (input[i] != ' '))
                    {
                        CurrentWord += input[i];
                        i++;
                    }
                    found = false;
                    for (index = 0; index < amount && !found; index++)
                    {
                        if (CurrentWord == Definitions[index])
                            found = true;
                    }
                    if (found)
                        Console.Write(Translates[index - 1]+" ");
                    else
                        Console.Write(CurrentWord + " ");
                }
                    Console.WriteLine();
                    Console.WriteLine("please enter the sentence you would like to translate Or 'enough' to finish and press ENTER");
                    input = Console.ReadLine();
                
            }
        }
    }
}
