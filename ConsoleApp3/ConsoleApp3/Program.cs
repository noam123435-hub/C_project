namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter the number of level for the pyramide");
            int height = int.Parse(Console.ReadLine());

            int currentRow = 1;

            // לולאה לכל השורות
            while (currentRow <= height)
            {
                // הדפסת רווחים חיצוניים
                int spaces = height - currentRow;
                while (spaces > 0)
                {
                    Console.Write(" ");
                    spaces--;
                }

                // בדיקה אם זו השורה הראשונה
                if (currentRow == 1)
                {
                    Console.Write("*");
                }
                else
                {
                    // הדפסת כוכב שמאלי
                    Console.Write("*");

                    // הדפסת רווחים פנימיים
                    int innerSpaces = 2 * currentRow - 3;
                    while (innerSpaces > 0)
                    {
                        Console.Write(" ");
                        innerSpaces--;
                    }

                    // הדפסת כוכב ימני
                    Console.Write("*");
                }

                    Console.WriteLine();
                currentRow++;
            }
        }
    }
}
