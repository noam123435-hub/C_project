namespace _2D_Checkers2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] checkersBoard = {{' ','W',' ','W',' ','W',' ','W'},
                                     {'w',' ','w',' ','w',' ','w',' '},
                                     {' ','w',' ','w',' ','w',' ','w'},
                                     {' ',' ',' ',' ',' ',' ',' ',' '},
                                     {' ',' ',' ',' ',' ',' ',' ',' '},
                                     {' ','b',' ','b',' ','b',' ','b'},
                                     {'b',' ','b',' ','b',' ','b',' '},
                                     {' ','B',' ','B',' ','B',' ','B'},};
            print(checkersBoard);
        }
        static void print(char[,] board)
        {
            for (int iRow = 0;iRow < board.GetLength(0);iRow++)
            {
                for(int iCol = 0;iCol < board.GetLength(1);iCol++)
                    switch(board[iRow,iCol])
                    {
                        case ' ':
                            Console.Write("EE ");
                            break;
                        case 'w':
                            Console.Write("WW ");
                            break;
                        case 'W':
                            Console.Write("QW ");
                            break;
                        case 'b':
                            Console.Write("BB ");
                            break;
                        case 'B':
                            Console.Write("QB ");
                            break;
                        default:
                            Console.Write("illigal board");
                            break;
                    }
                Console.WriteLine();
            }
        }
    }
}
