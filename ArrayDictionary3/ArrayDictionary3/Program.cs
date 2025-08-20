namespace ArrayDictionary3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amount = 0;
            bool enough = false;
            string allH = "", allE = "", word;
            //צבירת המילים ל2 מחרוזות
            while (!enough)
            {
                Console.WriteLine("please enter the hebrew word Or 'enough' and press ENTER");
                word = Console.ReadLine();
                if (word == "enough")
                    enough = true;
                else
                {
                    allH += word + " ";
                    Console.WriteLine("please enter the english word for "+word);
                    allE += Console.ReadLine() + " ";
                }
                amount++;
            }
            //פירוק המחרוזת בעברית למערך העברית
            int index = 0;
            string[] Hebrew;
            Hebrew = new string[amount];
            for (int i = 0; (index < amount) && (i < allH.Length); i++)
            {
                word = "";
                while ((allH[i] == ' ') && (i < allH.Length))
                    i++;
                while ((i < allH.Length) && (allH[i] != ' '))
                {
                    word += allH[i];
                    i++;
                }
                Hebrew[index] = word;
                index++;
            }
            //פירוק המחזרות באנגלית למערך באנגלית
            index = 0;
            string[] English;
            English = new string[amount];
            for (int i = 0; (index < amount) &&(i < allE.Length); i++)
            {
                word = "";
                while ((allE[i] == ' ') && (i < allE.Length))
                    i++;
                while ((i < allE.Length) && (allE[i] != ' '))
                {
                    word += allE[i];
                    i++;
                }
                English[index] = word;
                index++;
            }
            // תרגום משפט מעברית לאנגלית
            Console.WriteLine();
            Console.WriteLine("please enter a sentence Or 'enough' and press ENTER");
            string input = Console.ReadLine();
            string sentence = "";
            bool found;
            while (input != "enough")
            {
                sentence = "";
                for (int i = 0; i < input.Length; i++)
                {
                    word = "";
                    while ((input[i] == ' ') && (i < input.Length))
                        i++;
                    while ((i < input.Length) && (input[i] != ' '))
                    {
                        word += input[i];
                        i++;
                    }
                    found = false;
                    for (index = 0; index < Hebrew.Length && !found; index++)
                    {
                        if (Hebrew[index] == word)
                            found = true;
                    }
                    if (found)
                        sentence += English[(index - 1)];
                    else
                        sentence += word;
                    sentence += " ";
                }
                Console.WriteLine(sentence);
                Console.WriteLine();
                Console.WriteLine("please enter a sentence Or 'enough' and press ENTER");
                input = Console.ReadLine();
            }
        }
    }
}
