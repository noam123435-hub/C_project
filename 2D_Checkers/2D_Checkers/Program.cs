namespace _2D_Checkers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            printBoard(createBoard(8,8));
        }
        static string[,] createBoard(int a, int b)
        {
            string[,] board=new string[a,b];
           for(int iRow = 0;iRow<3;iRow++)
            {
                for(int iCol = 0; iCol < board.GetLength(1);iCol++)
                {
                    if (iRow % 2 == 0)
                    {
                        if (iCol % 2 != 0)
                            board[iRow, iCol] = "WW";
                        else
                            board[iRow, iCol] = "EE";
                    }
                    else
                    {
                        if (iCol % 2 == 0)
                            board[iRow, iCol] = "WW";
                        else
                            board[iRow, iCol] = "EE";
                    }
                         
                }
            }
           for(int iRow = 3;iRow<5;iRow++)
            {
                for (int iCol = 0; iCol < board.GetLength(1); iCol++)
                    board[iRow, iCol] = "EE";
            }
           for (int iRow = 5; iRow < board.GetLength(0);iRow++)
            {
                for(int iCol=0; iCol < board.GetLength(1);iCol++)
                {
                    if (iRow % 2 != 0)
                    {
                        if (iCol % 2 == 0)
                            board[iRow, iCol] = "BB";
                        else
                            board[iRow, iCol] = "EE";
                    }
                    else 
                    {
                        if (iCol % 2 != 0)
                            board[iRow, iCol] = "BB";
                        else
                            board[iRow, iCol] = "EE";
                    }
                }
            }
            return board;
        }
        static void printBoard(string[,] board)
        {
            for(int row=0; row<board.GetLength(0); row++)
            {
                for(int col=0; col<board.GetLength(1); col++)
                    Console.Write(board[row,col]+" ");
                Console.WriteLine();
            }
        }
    }
}
