using System.Security.Cryptography;

namespace Matrix_Jagged
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] Kefel = new int[10, 10];
            for (int i = 0; i < Kefel.GetLength(0); i++)
                for (int j = 0; j < Kefel.GetLength(1); j++)
                    Kefel[i, j] = (i+1)*(j+1);
            print(Kefel);
            print(Kefel); 

            int[][] kef = new int[10][];
            for(int i=0; i < kef.Length; i++)
                kef[i]=new int[10];
            for (int i = 0;i<kef.Length;i++)
                for (int j = 0;j<kef[i].Length;j++)
                    kef[i][j]=(i+1)*(j+1);
            print(kef);
            print(kef);
        }
        static void print(int[][] Kefel)
        {
            for (int row = 0; row < Kefel.Length; row++)
            {
                for (int col = 0; col < Kefel[row].Length; col++)
                    Console.Write(Kefel[row][col] + ((Kefel[row][col]<10)?"  ":" "));
                Console.WriteLine();
            }
            Console.WriteLine();
            int[] last= Kefel[Kefel.Length-1];
            Kefel[Kefel.Length - 1] = Kefel[0];
            Kefel[0]=last;

        }
        static void print(int[,] kefel)
        {
            for (int row = 0; row < kefel.GetLength(0); row++)
            {
                for (int col = 0; col < kefel.GetLength(1); col++)
                    Console.Write(kefel[row, col] + ((kefel[row, col] < 10) ? "  " : " "));
                Console.WriteLine();
            }
            Console.WriteLine();
            int[,] last = new int[1, 10];
            for (int col = 0; col < last.GetLength(1); col++)
            {
                last[0, col] = kefel[9, col];
                kefel[9, col] = kefel[0, col];
                kefel[0, col] = last[0, col];
            }
        }
    }
}
