namespace String_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Replace
            Console.WriteLine("please enter some text and press ENTER");
            string input=Console.ReadLine();
            string[] badWords = new string[5];
            badWords[0] = "evil";
            badWords[1] = "gross";
            badWords[2] = "fat";
            badWords[3] = "stupid";
            badWords[4] = "ugly";
            string result = input;
            for (int i = 0; i < badWords.Length; i++)
                result = result.Replace(badWords[i], "");
            Console.WriteLine(result); */


            /* Indexof + Insert
            Console.WriteLine("please enter some text and press ENTER");
            string input=Console.ReadLine();
            string result= input.Trim();
            int spaceIndex = 0, previousSpace = -1;
            spaceIndex=result.IndexOf(' ',spaceIndex);
            while ((spaceIndex=result.IndexOf(' ',spaceIndex))!=- 1) // כלומר כאשר הגעתי לסוף ולא מצאתי רווח, הלולאה מסתיימת
            {
                if (spaceIndex - previousSpace > 1)
                {
                    result = result.Insert(spaceIndex, " shakran");
                    spaceIndex += 9;
                }
                previousSpace = spaceIndex;
            }
            result += " sakran";
            Console.WriteLine(result); */

            

            /* Split
            Console.WriteLine("please enter a text and press ENTER");
            string input = Console.ReadLine();
            input = input.Trim();
            string result = "";
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i]!="")
                  result += words[i] + " shakran ";
            }
            Console.WriteLine(result);  */
            
           /* Trim + EndsWith
           Console.WriteLine(input.Trim().EndsWith(".")?"ligal sentence":"illigal sentence"); */

        }
    }
}
