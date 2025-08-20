namespace array4dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello please enter the amount of Definitions and press ENTER");
            int amount=int.Parse(Console.ReadLine());
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
            Console.WriteLine("please enter the definiftion you would like to find out Or enough to finish and press ENTER");
            string input=Console.ReadLine();
            string ans="";
            bool found=false;
            while (input != "enough")
            {
                for (int i = 0; i < amount &&!found ; i++)
                {
                    if (Definitions[i] == input)
                    {
                        found = true;
                        ans = Translates[i];
                    }
                    else
                        ans = "not in the dictionary";
                }
                Console.WriteLine(ans);
                Console.WriteLine();
                Console.WriteLine("please enter the definiftion you would like to find out Or enough to finish and press ENTER");
                input = Console.ReadLine();
                found = false;
            }

        }
    }
}
