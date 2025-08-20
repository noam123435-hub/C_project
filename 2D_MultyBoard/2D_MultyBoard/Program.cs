using System.Runtime.InteropServices;

namespace _2D_MultyBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            printBoard(createBoard(10, 10));
        }
        static int[,] createBoard(int r, int c)
        {

            int[,] result = new int[r, c];
            for (int iRow = 0; iRow < result.GetLength(0); iRow++)
            {
                for (int iCol = 0; iCol < result.GetLength(1); iCol++)
                    result[iRow, iCol] = (iRow + 1) * (iCol + 1);
            }
            return result;
        }
        static void printBoard(int[,] board)
        {
            for(int iRow = 0;iRow < board.GetLength(0);iRow++)
            {
                for(int iCol = 0;iCol < board.GetLength(1);iCol++)
                    Console.Write(board[iRow, iCol] + ((board[iRow,iCol]<10)?"  ":" "));
                Console.WriteLine();
            }
        }
    }
}
