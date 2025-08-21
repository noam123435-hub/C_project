using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Chess
{
    internal class GameLauncher
    {
        static void Main(string[] args)
        {
            new ChessGame().playGame();
        }
    }
    class ChessGame
    {
        ChessPiece[,] board = new ChessPiece[8, 8];
        int turnCount;
        string[] boardHistory;
        bool isWhiteTurn;
        int movesMadeWithoutPowmMovmentOrCaptureCount;
        public ChessGame()
        {
            board = createChessBoard(1);
            setMovesMadeWithoutPowmMovmentOrCaptureCount(0);
            setTurnCount(0);
            setIsWhiteTurn(getTurnCount());
            boardHistory = new string[getMovesMadeWithoutPowmMovmentOrCaptureCount()];
        }
        public ChessPiece[,] createChessBoard(int pieceNumber)
        {
            for (int row = 0; row < 8; row++)
                for (int col = 0; col < 8; col++, pieceNumber++)
                    switch (row)
                    {
                        case 0: case 7:
                            switch (col)
                            {
                                case 0: case 7: board[row, col] = new Rook(row > 0, row, col, pieceNumber); break;
                                case 1: case 6: board[row, col] = new Knight((row > 0), row, col, pieceNumber); break;
                                case 2: case 5: board[row, col] = new Bishop(row > 0, row, col, pieceNumber); break;
                                case 3: board[row, col] = new Queen(row > 0, row, col, pieceNumber); break;
                                case 4: board[row, col] = new King(row > 0, row, col, pieceNumber); break;
                            }
                            break;
                        case 1: case 6: board[row, col] = new Pawn(row > 1, row, col, pieceNumber); break;
                        default: pieceNumber--; break;
                    }
            return board;
        }
        public ChessPiece[,] getBoard() { return board; }
        public void print()
        {
            int lineCount = 8;
            for (int row = 0; row < (this.getBoard()).GetLength(0); row++)
            {
                Console.Write(lineCount + "  ");
                for (int col = 0; col < board.GetLength(1); col++)
                    switch (board[row, col])
                    {
                        case null: Console.Write("-  "); break;
                        default: Console.Write(board[row, col] + " "); break;
                    }
                lineCount--;
                Console.WriteLine();
            }
            string Columns = "   A  B  C  D  E  F  G  H";
            Console.WriteLine();
            Console.WriteLine(Columns);
            Console.WriteLine("==========================");
        }
        public void setIsWhiteTurn(int count)
        {
            isWhiteTurn = (count % 2 == 0);
        }
        public bool getIsWhiteTurn()
        {
            setIsWhiteTurn(getTurnCount());
            return isWhiteTurn;
        }
        public void setMovesMadeWithoutPowmMovmentOrCaptureCount(int count)
        {
            movesMadeWithoutPowmMovmentOrCaptureCount = count;
        }
        public int getMovesMadeWithoutPowmMovmentOrCaptureCount()
        {
            return movesMadeWithoutPowmMovmentOrCaptureCount;
        }
        public bool setTurnCount(int count)
        {
            if (count < 0)
                return false;
            turnCount = count;
            return true;
        }
        public int getTurnCount()
        {
            return turnCount;
        }
        public void playGame()
        {
            string input = "";
            bool draw = false, win = false, rightSpot = true;
            int currentRow = -1, currentCol = -1, nextRow = -1, nextCol = -1;
            ChessPiece selectedSpot = null, targetSpot = null;
            while (!(draw || win))
            {
                showStartTurnStatus(rightSpot);
                input = Console.ReadLine();
                input = input.ToUpper().Trim();
                if (input == "DRAW")
                    draw = askDraw();
                rightSpot = playTurn(input, selectedSpot, targetSpot);
                if (!rightSpot || draw)
                    continue;
                draw = isDraw(getBoard());
                win = isCheckmate(getBoard());
            }
            endGame(draw, win);
        }
        public bool playTurn(string input, ChessPiece selectedSpot, ChessPiece targetSpot)
        {
            int currentRow = -1, currentCol = -1, nextRow = -1, nextCol = -1;
            input = input.ToUpper().Trim();
            if (isCastlingInput(input))
                return true;
            if (input.Length != 4) return false;
            currentCol = getLertterToNumber(input[0]);
            currentRow = getNumberToNumber(input[1]);
            nextCol = getLertterToNumber(input[2]);
            nextRow = getNumberToNumber(input[3]);
            if (isValidInput(board, currentRow, currentCol, nextRow, nextCol))
                selectedSpot = board[currentRow, currentCol];
            else return false;
            if (executeMoveIfLegal(board, selectedSpot, targetSpot, nextRow, nextCol))
            {
                if (selectedSpot is King || selectedSpot is Rook || selectedSpot is Pawn)
                    updateIsMoved(board, currentRow, currentCol, nextRow, nextCol);
                return true;
            }
            return false;
        }
        public bool executeMoveIfLegal(ChessPiece[,] board, ChessPiece selectedSpot, ChessPiece targetSpot, int nextRow, int nextCol)
        {
            int currentRow = selectedSpot.getRow(), currentCol = selectedSpot.getCol();
            if (selectedSpot != null)
            {
                if (board[nextRow, nextCol] == null || board[nextRow, nextCol].getIsWhite() != selectedSpot.getIsWhite())
                    targetSpot = board[nextRow, nextCol];
                if (isValidMove(getBoard(), currentRow, currentCol, nextRow, nextCol))
                    return tryMove(getBoard(), selectedSpot, targetSpot, currentRow, currentCol, nextRow, nextCol, false);
                else
                    return false;
            }
            return false;
        }
        public void showStartTurnStatus(bool rightSpot)
        {
            setIsWhiteTurn(getTurnCount());
            print();
            Console.WriteLine((rightSpot ? "" : "Invalid move! ") + "{0} player, please enter your move and press ENTER", (getIsWhiteTurn()) ? "White" : "Black");
            Console.WriteLine("for ask draw enter 'DRAW', for kingside castling enter 'O-O', for Queenside castling press 'O-O-O'");

        }
        public void endGame(bool draw, bool win)
        {
            print();
            if (draw)
                Console.WriteLine("The game end with DRAW");
            else if (win)
                Console.WriteLine("The game ends with a Win for the {0} player", (getIsWhiteTurn()) ? "black" : "white");
        }
        public bool isCastlingInput(string input)
        {
            if (input == "O-O")
                return executeKingSideCastlingIfLegal();
            if (input == "O-O-O")
                return executeQueenSideCastlingIfLegal();
            return false;
        }
        public bool isValidInput(ChessPiece[,] board, int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (currentCol < 0 || currentRow < 0 || nextCol < 0 || nextRow < 0)
                return false;
            if (getBoard()[currentRow, currentCol] != null)
                if (getIsWhiteTurn() ? getBoard()[currentRow, currentCol].getIsWhite() == true : getBoard()[currentRow, currentCol].getIsWhite() == false)
                    return true;
            Console.WriteLine("The piece belong to the other player");
            return false;
        }
        public void undoMove(ChessPiece[,] board, ChessPiece selectedSpot, ChessPiece targetSpot, ChessPiece savedPawn, int currentRow, int currentCol, int nextRow, int nextCol, bool simulate)
        {
            bool hasMoved = setHasMove(selectedSpot);
            if (selectedSpot is Pawn && (nextRow == 0 || nextRow == 7))
                selectedSpot = savedPawn;
            board[currentRow, currentCol] = selectedSpot;
            selectedSpot.setRow(currentRow);
            selectedSpot.setCol(currentCol);
            board[nextRow, nextCol] = targetSpot;
            if (targetSpot != null)
            {
                targetSpot.setRow(nextRow);
                targetSpot.setCol(nextCol);
            }
            if (selectedSpot is King)
                ((King)selectedSpot).setIsMoved(hasMoved);
            if (selectedSpot is Rook)
                ((Rook)selectedSpot).setIsMoved(hasMoved);
            if (selectedSpot is Pawn)
                ((Pawn)selectedSpot).setIsMovedTwoStepsLastTurn(false);
        }
        public bool setHasMove(ChessPiece selectedSpot)
        {
            bool hasMoved = false;
            if (selectedSpot is King)
                hasMoved = ((King)selectedSpot).getIsMoved();
            if (selectedSpot is Rook)
                hasMoved = ((Rook)selectedSpot).getIsMoved();
            return hasMoved;
        }
        public bool checkInput(string input)
        {
            if (input.Length != 4)
            {
                Console.WriteLine("invalid input, please try again");
                input = Console.ReadLine();
                this.checkInput(input.ToUpper().Trim());
            }
            for (int i = 0; i < input.Length; i++)
                switch (input[i])
                {
                    case '1': case '2': case '3': case '4': case '5': case '6': case '7': case '8':
                    case 'A': case 'B': case 'C': case 'D': case 'E': case 'F': case 'G': case 'H':
                        break;
                    default:
                        Console.WriteLine("invalid input, please try again");
                        input = Console.ReadLine();
                        this.checkInput(input.ToUpper().Trim());
                        break;
                }
            return true;
        }
        public int getLertterToNumber(char input)
        {
            switch (input)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                case 'D': return 3;
                case 'E': return 4;
                case 'F': return 5;
                case 'G': return 6;
                case 'H': return 7;
                default: return -1;
            }

        }
        public int getNumberToNumber(char input)
        {
            switch (input)
            {
                case '8': return 0;
                case '7': return 1;
                case '6': return 2;
                case '5': return 3;
                case '4': return 4;
                case '3': return 5;
                case '2': return 6;
                case '1': return 7;
                default: return -1;
            }
        }
        public bool isValidMove(ChessPiece[,] board, int currentRow, int currentCol, int nextRow, int nextCol)
        {
            ChessPiece selectedSpot = board[currentRow, currentCol];
            if (selectedSpot.isPossibleMove(getBoard(), nextRow, nextCol))
                if (isRightPlace(getBoard(), currentRow, currentCol, nextRow, nextCol))
                    return true;
            return false;
        }
        public bool tryMove(ChessPiece[,] board, ChessPiece selectedSpot, ChessPiece targetSpot, int currentRow, int currentCol, int nextRow, int nextCol, bool simulate)
        {
            ChessPiece savedPawn = null;
            bool hasMoved = setHasMove(selectedSpot);
            if (selectedSpot is Pawn)
                savedPawn = selectedSpot;
            movePiece(board, selectedSpot, targetSpot, currentRow, currentCol, nextRow, nextCol, simulate);
            if (isChecK(getBoard()))
            {
                Console.WriteLine("Your move lead to Check!! try another move");
                undoMove(board, selectedSpot, targetSpot, savedPawn, currentRow, currentCol, nextRow, nextCol, simulate);
                if (selectedSpot is King)
                    ((King)selectedSpot).setIsMoved(hasMoved);
                if (selectedSpot is Rook)
                    ((Rook)selectedSpot).setIsMoved(hasMoved);
                return false;
            }
            endMove(selectedSpot, targetSpot);
            return true;
        }
        public void endMove(ChessPiece selectedSpot, ChessPiece targetSpot)
        {
            setTurnCount(getTurnCount() + 1);
            if (selectedSpot is Pawn || targetSpot != null)
                setMovesMadeWithoutPowmMovmentOrCaptureCount(0);
            else
                setMovesMadeWithoutPowmMovmentOrCaptureCount(getMovesMadeWithoutPowmMovmentOrCaptureCount() + 1);
        }
        public bool isChecK(ChessPiece[,] board)
        {
            ChessPiece king = null, enemy = null;
            bool isCheck = false, kingFound = false, isWhiteTurn = (getTurnCount() % 2 == 0);
            for (int kingRow = 0; kingRow < board.GetLength(0) && !isCheck && !kingFound; kingRow++)
                for (int kingCol = 0; kingCol < board.GetLength(1) && !isCheck && !kingFound; kingCol++)
                {
                    king = board[kingRow, kingCol];
                    if (king != null)
                        if ((king is King) && ((isWhiteTurn) ? king.getIsWhite() == true : king.getIsWhite() == false))
                        {
                            kingFound = true;
                            for (int enemyRow = 0; enemyRow < board.GetLength(0) && !isCheck; enemyRow++)
                                for (int enemyCol = 0; enemyCol < board.GetLength(1) && !isCheck; enemyCol++)
                                    if (isEnemyCaptureKing(enemy, enemyRow, enemyCol, kingRow, kingCol, isWhiteTurn))
                                        return true;
                        }
                }
            return false;
        }
        public bool isEnemyCaptureKing(ChessPiece enemy, int enemyRow, int enemyCol, int kingRow, int kingCol, bool isWhiteTurn)
        {
            enemy = board[enemyRow, enemyCol];
            if (enemy != null)
            {
                if ((isWhiteTurn) ? enemy.getIsWhite() == false : enemy.getIsWhite() == true)
                    if (enemy.isPossibleMove(board, kingRow, kingCol))
                        return true;
            }
            return false;
        }
        public bool isStalemate(ChessPiece[,] board)
        {
            if (isChecK(board))
                return false;
            if (isAnyPossibleMove(board, true))
                return false;
            Console.WriteLine("Stalemate");
            return true;
        }
        public bool isCheckmate(ChessPiece[,] board)
        {
            if (!isChecK(board))
                return false;
            if (isAnyPossibleMove(board, true))
                return false;
            return true;
        }
        public bool isAnyPossibleMove(ChessPiece[,] board, bool simulate)
        {
            ChessPiece piece = null, enemy = null, savedPawn = null;
            bool isPossible = false, isWhiteTurn = getIsWhiteTurn();
            for (int pieceRow = 0; pieceRow < board.GetLength(0) && !isPossible; pieceRow++)
                for (int pieceCol = 0; pieceCol < board.GetLength(1) && !isPossible; pieceCol++)
                {
                    piece = board[pieceRow, pieceCol];
                    if (piece != null)
                        if (isWhiteTurn ? piece.getIsWhite() == true : piece.getIsWhite() == false)
                            for (int enemyRow = 0; enemyRow < board.GetLength(0) && !isPossible; enemyRow++)
                                for (int enemyCol = 0; enemyCol < board.GetLength(1) && !isPossible; enemyCol++)
                                {
                                    enemy = board[enemyRow, enemyCol];
                                    if (piece.isPossibleMove(board, enemyRow, enemyCol) && (isRightPlace(board, pieceRow, pieceCol, enemyRow, enemyCol)))
                                        isPossible = tryPossibleMove(board, piece, enemy, enemyRow, enemyCol, simulate);
                                    else
                                        isPossible = tryPossibleCastling(board, piece);
                                }
                }
            return isPossible;
        }
        public bool tryPossibleMove(ChessPiece[,] board, ChessPiece piece, ChessPiece enemy, int enemyRow, int enemyCol, bool simulate)
        {
            ChessPiece savedPawn = null;
            bool isPossible = false;
            int pieceRow = piece.getRow(), pieceCol = piece.getCol(), savedeRow = -1;
            if (piece is Pawn)
                savedPawn = piece;
            if (enemy == null && (board[pieceRow, enemyCol] is Pawn && piece is Pawn) && pieceCol != enemyCol)
            {
                savedeRow = enemyRow;
                enemyRow = pieceRow;
                enemy = board[enemyRow, enemyCol];
            }
            movePiece(board, piece, enemy, pieceRow, pieceCol, enemyRow, enemyCol, simulate);
            isPossible = isChecK(board) ? false : true;
            undoMove(board, piece, enemy, savedPawn, pieceRow, pieceCol, enemyRow, enemyCol, simulate);
            if (enemy == null && (board[pieceRow, enemyCol] is Pawn && piece is Pawn) && pieceCol != enemyCol)
                enemyRow = savedeRow;
            return isPossible;
        }
        public bool tryPossibleCastling(ChessPiece[,] board, ChessPiece piece)
        {
            if (piece is King && piece.getIsWhite() == false)
                return executeKingSideCastlingIfLegal();
            else if (piece is King && ((King)piece).getIsMoved() == false)
                return executeQueenSideCastlingIfLegal();
            return false;
        }
        public bool isKingSideCastlingPossible(ChessPiece[,] board)
        {
            bool isWhiteTurn = getTurnCount() % 2 == 0, isPossible = false;
            ChessPiece king, rook, place5, place6;
            king = board[(isWhiteTurn ? 7 : 0), 4];
            place5 = board[(isWhiteTurn ? 7 : 0), 5];
            place6 = board[(isWhiteTurn ? 7 : 0), 6];
            rook = board[(isWhiteTurn ? 7 : 0), 7];
            if (king != null || rook != null)
            {
                if (!isChecK(board))
                    isPossible = isKingSidePathClear(board, king, rook,place5,place6, isWhiteTurn);
                else
                    isPossible = false;
            }
            else
                isPossible = false;
            return isPossible;
        }
        public bool isKingSidePathClear(ChessPiece[,] board, ChessPiece king, ChessPiece rook, ChessPiece place5, ChessPiece place6, bool isWhiteTurn)
        {
            bool isClear = true;
            for (int kingCol = 5; kingCol < 7&&isClear; kingCol++)
            {
                if (board[(isWhiteTurn ? 7 : 0), kingCol] == null)
                {
                    board[(isWhiteTurn ? 7 : 0), kingCol] = king;
                    isClear = isChecK(board) ? false : true;
                }
                else
                    isClear = false;
                
            }
            undoKingSideChecking(board, king, place5, place6, isWhiteTurn);
            return isClear;
        }
        public void undoKingSideChecking(ChessPiece[,] board, ChessPiece king, ChessPiece place5, ChessPiece place6, bool isWhiteTurn)
        {
            board[(isWhiteTurn ? 7 : 0), 4] = king;
            board[(isWhiteTurn ? 7 : 0), 5] = place5;
            board[(isWhiteTurn ? 7 : 0), 6] = place6;
        }
        public bool executeKingSideCastlingIfLegal()
        {
            bool isWhiteTurn = getIsWhiteTurn();
            ChessPiece king = getBoard()[(isWhiteTurn ? 7 : 0), 4], rook = getBoard()[(isWhiteTurn ? 7 : 0), 7];
            if (king is King && rook is Rook)
                if ((!((King)king).getIsMoved()) && (!(((Rook)rook).getIsMoved())))
                    if (isKingSideCastlingPossible(getBoard()))
                    {
                        doKingSideCastling(board, king, rook, isWhiteTurn);
                        if (isChecK(getBoard()))
                        {
                            undoKingSideCastling(board, king, rook, isWhiteTurn);
                            return false;
                        }
                        endCastlingTurn(king, rook);
                        return true;
                    }
            return false;
        }
        public void doKingSideCastling(ChessPiece[,] board, ChessPiece king, ChessPiece rook, bool isWhiteTurn)
        {
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 6] = king;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 4] = null;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 5] = rook;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 7] = null;
        }
        public void undoKingSideCastling(ChessPiece[,] board, ChessPiece king, ChessPiece rook, bool isWhiteTurn)
        {
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 4] = king;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 6] = null;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 7] = rook;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 5] = null;
        }
        public void undoQueenSideChecking(ChessPiece[,] board, ChessPiece king, ChessPiece[] places, bool isWhiteTurn)
        {
            board[(isWhiteTurn ? 7 : 0), 4] = king;
            for(int i = 1; i < places.Length; i++)
                board[(isWhiteTurn ? 7 : 0), i] = places[i];
        }
        public bool isQueenSideCastlingPossible(ChessPiece[,] board)
        {
            bool isWhiteTurn = getTurnCount() % 2 == 0, isPossible = true;
            ChessPiece king, rook;
            ChessPiece[] places = new ChessPiece[4];
            king = board[(isWhiteTurn ? 7 : 0), 4];
            for (int place = 1; place < 4; place++)
                places[place] = board[(isWhiteTurn ? 7 : 0), place];
            rook = board[(isWhiteTurn ? 7 : 0), 0];
            if (king != null && rook != null)
            {
                if (!isChecK(board))
                    isPossible = isQueenSidePathClear(board, king, rook, places, isWhiteTurn);
                else
                    isPossible = false;
            }
            else
                isPossible = false;
            return isPossible;
        }
        public bool executeQueenSideCastlingIfLegal()
        {
            bool isWhiteTurn = getIsWhiteTurn();
            ChessPiece king = getBoard()[(isWhiteTurn ? 7 : 0), 4], rook = getBoard()[(isWhiteTurn ? 7 : 0), 7];
            if (king is King && rook is Rook)
                if (!((King)king).getIsMoved() && !(((Rook)rook).getIsMoved()))
                    if (isQueenSideCastlingPossible(getBoard()))
                    {
                        doQueenSideCastling(board, king, rook, isWhiteTurn);
                        if (isChecK(getBoard()))
                        {
                            undoQueenSideCastling(board, king, rook, isWhiteTurn);
                            return false;
                        }
                        endCastlingTurn(king, rook);
                        return true;
                    }
            return false;
        }
        public void endCastlingTurn(ChessPiece king, ChessPiece rook)
        {
            setTurnCount(getTurnCount() + 1);
            ((King)king).setIsMoved(true);
            ((Rook)rook).setIsMoved(true);
        }
        public bool isQueenSidePathClear(ChessPiece[,] board, ChessPiece king, ChessPiece rook,ChessPiece[]places ,bool isWhiteTurn)
        {
            bool isClear = true;
            for (int kingCol = 3; kingCol > 0 && isClear; kingCol--)
            {
                if (board[(isWhiteTurn ? 7 : 0), kingCol] == null)
                {
                    board[(isWhiteTurn ? 7 : 0), kingCol] = king;
                    isClear = isChecK(board) ? false : true;
                }
                else
                    isClear = false;
            }
            undoQueenSideChecking(board, king, places, isWhiteTurn);
            return isClear;
        }
        public void doQueenSideCastling(ChessPiece[,] board, ChessPiece king, ChessPiece rook, bool isWhiteTurn)
        {
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 1] = king;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 4] = null;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 2] = rook;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 0] = null;
        }
        public void undoQueenSideCastling(ChessPiece[,] board, ChessPiece king, ChessPiece rook, bool isWhiteTurn)
        {
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 4] = king;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 1] = null;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 0] = rook;
            getBoard()[(getIsWhiteTurn() ? 7 : 0), 2] = null;
        }
        public void movePiece(ChessPiece[,] board, ChessPiece selectedSpot, ChessPiece targetSpot, int currentRow, int currentCol, int nextRow, int nextCol, bool simulate)
        {
            if (board[currentRow, currentCol] is Pawn && board[nextRow, nextCol] == null && (nextCol - currentCol == 1 || nextCol - currentCol == -1))
                board[currentRow, nextCol] = null;
            board[nextRow, nextCol] = board[currentRow, currentCol];
            board[currentRow, currentCol] = null;
            if (board[nextRow, nextCol] != null)
            {
                board[nextRow, nextCol].setRow(nextRow);
                board[nextRow, nextCol].setCol(nextCol);
            }
            if (board[nextRow, nextCol] is Pawn && (nextRow == 0 || nextRow == 7))
                board[nextRow, nextCol] = promotion(board[nextRow, nextCol], getTurnCount(), simulate);
        }
        public void updateIsMoved(ChessPiece[,] board, int currentRow, int currentCol, int nextRow, int nextCol)
        {
            foreach (ChessPiece piece in board)
                if (piece is Pawn)
                    ((Pawn)piece).setIsMovedTwoStepsLastTurn(false);
            if (board[nextRow, nextCol] is Pawn && (nextRow - currentRow == 2 || nextRow - currentRow == -2))
                ((Pawn)board[nextRow, nextCol]).setIsMovedTwoStepsLastTurn(true);
            if (board[nextRow, nextCol] is King)
                ((King)board[nextRow, nextCol]).setIsMoved(true);
            if (board[nextRow, nextCol] is Rook)
                ((Rook)board[nextRow, nextCol]).setIsMoved(true);
        }
        public bool isRightPlace(ChessPiece[,] board, int currentRow, int currentCol, int nextRow, int nextCol)
        {
            if (board[nextRow, nextCol] == null)
                return true;
            else if (board[nextRow, nextCol].getIsWhite() == board[currentRow, currentCol].getIsWhite())
                return false;
            return true;
        }
        public bool isDraw(ChessPiece[,] board)
        {
            if (getMovesMadeWithoutPowmMovmentOrCaptureCount() == 100)
            {
                Console.WriteLine("50 Moves rule");
                return true;
            }
            if (isStalemate(board))
                return true;
            if (isThreefoldRepetition(board))
                return true;
            if (isDeadPosition(board))
                return true;
            return false;
        }
        public bool isDeadPosition(ChessPiece[,] board)
        {
            int kingCount = 0, bishopCuont = 0, knightCount = 0, allPices = 0;
            foreach (ChessPiece piece in board)
            {
                if (piece is King)
                    kingCount++;
                if (piece is Bishop)
                    bishopCuont++;
                if (piece is Knight)
                    knightCount++;
                if (piece != null)
                    allPices++;
            }
            if (allPices < 4 && kingCount == 2)
                if ((bishopCuont == 0 && knightCount == 0) || (bishopCuont == 0 && knightCount == 1) || (bishopCuont == 1 && knightCount == 0))
                {
                    Console.WriteLine("Dead Position");
                    return true;
                }
            return false;
        }
        public bool askDraw()
        {
            Console.WriteLine("the {0} player ask for draw, enter 'Y' or 'N' and press ENTER", getIsWhiteTurn() ? "white" : "black");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
                return true;
            return false;
        }
        public string enPersantLocation(ChessPiece[,] board)
        {
            ChessPiece piece;
            int enemyRow = 0, enemyCol = 0;
            for (int pieceRow = 0; pieceRow < board.GetLength(0); pieceRow++)
                for (int pieceCol = 0; pieceCol < board.GetLength(1); pieceCol++)
                {
                    piece = board[pieceRow, pieceCol];
                    if (piece is Pawn && ((Pawn)piece).getIsMovedTwoStepsLastTurn() == true)
                    {
                        if (piece.getIsWhite() == true)
                            enemyRow = pieceRow - 1;
                        else
                            enemyRow = pieceRow + 1;
                        enemyCol = pieceCol;
                        return "(" + enPassantRightsString(board, piece, pieceRow, pieceCol, enemyRow, enemyCol) + ")";
                    }
                }
            return "-";
        }
        public string enPassantRightsString(ChessPiece[,] board, ChessPiece piece, int pieceRow, int pieceCol, int enemyRow, int enemyCol)
        {
            if (pieceCol - 1 >= 0)
            {
                if (board[pieceRow, pieceCol - 1] is Pawn && board[pieceRow, pieceCol - 1].getIsWhite() != piece.getIsWhite())
                    return "" + enemyRow + "," + enemyCol;
            }
            if (pieceCol + 1 < 8)
            {
                if (board[pieceRow, pieceCol + 1] is Pawn && board[pieceRow, pieceCol + 1].getIsWhite() != piece.getIsWhite())
                    return "" + enemyRow + "," + enemyCol;
            }
            return "-";
        }
        public string saveBoard(ChessPiece[,] board)
        {
            string savedBoard = "";
            for (int row = 0; row < board.GetLength(0); row++)
                for (int col = 0; col < board.GetLength(1); col++)
                    switch (board[row, col])
                    {
                        case null:
                            savedBoard += "-";
                            break;
                        case ChessPiece:
                            savedBoard += board[row, col].getPieceNumber();
                            break;
                    }
            savedBoard += getIsWhiteTurn() ? "black" : "white";
            savedBoard += enPersantLocation(board);
            savedBoard += castlingRights(board);
            return savedBoard;
        }
        public string castlingRights(ChessPiece[,] board)
        {
            string castlingRights = "";
            if (((board[0, 4] is King) && (board[0, 7] is Rook)) && (((King)board[0, 4]).getIsMoved() == false) && ((Rook)board[0, 7]).getIsMoved() == false)
                castlingRights += "black/kingside+";
            else
                castlingRights += "-";
            if (((board[7, 4] is King) && (board[7, 7] is Rook)) && (((King)board[7, 4]).getIsMoved() == false) && ((Rook)board[7, 7]).getIsMoved() == false)
                castlingRights += "white/kingside+";
            else
                castlingRights += "-";
            if (((board[0, 4] is King) && (board[0, 0] is Rook)) && (((King)board[0, 4]).getIsMoved() == false) && ((Rook)board[0, 0]).getIsMoved() == false)
                castlingRights += "black/Queenside+";
            else
                castlingRights += "-";
            if (((board[7, 4] is King) && (board[7, 0] is Rook)) && (((King)board[7, 4]).getIsMoved() == false) && ((Rook)board[7, 0]).getIsMoved() == false)
                castlingRights += "white/Queenside";
            else
                castlingRights += "-";
            return castlingRights;
        }
        public bool isThreefoldRepetition(ChessPiece[,] board)
        {
            int repetCount = 0;
            string currentBoard = saveBoard(board);
            if (boardHistory != null)
                for (int i = 0; i < boardHistory.Length; i++)
                    if (currentBoard == boardHistory[i])
                        repetCount++;
            string[] updatedHistoryBoard = new string[boardHistory.Length + 1];
            if (boardHistory != null)
                for (int i = 0; i < boardHistory.Length; i++)
                    updatedHistoryBoard[i] = boardHistory[i];
            updatedHistoryBoard[boardHistory.Length] = currentBoard;
            boardHistory = updatedHistoryBoard;
            if (repetCount >= 2)
            {
                Console.WriteLine("Threefold Repetition");
                return true;
            }
            return false;
        }
        public ChessPiece promotion(ChessPiece pawn, int turn, bool simulate)
        {
            bool isWhiteTurn = turn % 2 == 0;
            ChessPiece promotPawn = null;
            if (simulate)
                return promotPawn = new Queen(isWhiteTurn, pawn.getRow(), pawn.getCol(), pawn.getPieceNumber());
            Console.WriteLine("plese enter the new piece's type, and press Enter");
            Console.WriteLine("for Queen enter 'Q',for Knight 'N', for Bishop 'B', for Rook 'R'");
            string input = Console.ReadLine();
           return promot(pawn,promotPawn, input,turn,false);
        }
        public ChessPiece promot(ChessPiece pawn,ChessPiece promotPawn, string input, int turn, bool simulate)
        {
            switch (input.ToUpper().Trim())
            {
                case "Q":
                    promotPawn = new Queen(isWhiteTurn, pawn.getRow(), pawn.getCol(), pawn.getPieceNumber());
                    return promotPawn;
                case "N":
                    promotPawn = new Knight(isWhiteTurn, pawn.getRow(), pawn.getCol(), pawn.getPieceNumber());
                    return promotPawn;
                case "B":
                    promotPawn = new Bishop(isWhiteTurn, pawn.getRow(), pawn.getCol(), pawn.getPieceNumber());
                    return promotPawn;
                case "R":
                    promotPawn = new Rook(isWhiteTurn, pawn.getRow(), pawn.getCol(), pawn.getPieceNumber());
                    return promotPawn;
                default:
                    Console.WriteLine("Wrong input, try again");
                    promotPawn = promotion(pawn, turn, simulate);
                    return promotPawn;
            }
        }
    }
    class ChessPiece
    {
        bool isWhite;
        int row;
        int colunm;
        int pieceNumber;
        public void setIsWhite(bool isWhite)
        {
            this.isWhite = isWhite;
        }
        public bool getIsWhite()
        {
            return this.isWhite;
        }
        public void setCol(int col)
        { this.colunm = col; }
        public int getCol()
        { return this.colunm; }
        public void setRow(int row)
        { this.row = row; }
        public int getRow()
        { return this.row; }
        public void setPieceNumber(int number)
        {
            this.pieceNumber = number;
        }
        public int getPieceNumber()
        {
            return this.pieceNumber;
        }
        public ChessPiece(bool isWhite, int row, int column,int number)
        {
            this.setIsWhite(isWhite);
            this.setRow(row);
            this.setCol(column);
            this.setPieceNumber(number);
        }
        public override string ToString()
        {
            return isWhite ? "w" : "b";
        }
        public virtual bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            return false;
        }
    }
    class Pawn : ChessPiece
    {
        bool isMovedTwoStepsLastTurn;
        public void setIsMovedTwoStepsLastTurn(bool isMoved)
        {
            this.isMovedTwoStepsLastTurn = isMoved;
        }
        public bool getIsMovedTwoStepsLastTurn()
        {
            return isMovedTwoStepsLastTurn;
        }
        public Pawn(bool iswhite, int row, int column, int number) : base(iswhite, row, column, number)
        {
            this.setIsMovedTwoStepsLastTurn(false);
        }
        public override string ToString()
        {
            return "P"+base.ToString();
        }
        public override bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            ChessPiece targetSpot = board[nextRow, nextCol];
            if ((((nextRow == currentRow && nextCol == currentCol) || (nextRow == currentRow && nextCol != currentCol))))
                return false;
            if (((this.getIsWhite() == true) && (nextRow - currentRow < -2) )||((getIsWhite() == true) &&(nextRow - currentRow > 0)) || ((this.getIsWhite() == false) && ((nextRow - currentRow > 2)) ||((this.getIsWhite() == false)&&(nextRow - currentRow <0))))
                return false;
            if (isPathEmpty(board, nextRow, nextCol))
                return true;
            else if (isCaptureLegal(board, targetSpot, nextRow, nextCol))
                return true;
            return false;
        }
        public bool isPathEmpty(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (nextCol == currentCol && board[currentRow, currentCol] != null && (board[nextRow, nextCol] == null))
            {
                if (isTwoMovesLegal(board,nextRow,nextCol))
                    return true;
                else if (isOneMoveLegal(board, nextRow, nextCol))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool isCaptureLegal(ChessPiece[,] board,ChessPiece targetSpot, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (((this.getIsWhite() == true && nextRow - currentRow == -1) || (this.getIsWhite() == false && nextRow - currentRow == 1)) && ((nextCol - currentCol == 1 || nextCol - currentCol == -1)))
            {
                if (board[nextRow, nextCol] != null)
                {
                    if (board[currentRow, currentCol].getIsWhite() != board[nextRow, nextCol].getIsWhite())
                        return true;
                }
                else if (((board[currentRow, nextCol] is Pawn) && (((Pawn)board[currentRow, nextCol]).getIsMovedTwoStepsLastTurn() == true) && (board[currentRow, currentCol].getIsWhite() != board[currentRow, nextCol].getIsWhite())))
                {
                    if (board[nextRow, nextCol] == null && (nextRow == 2 || nextRow == 5))
                    {
                        targetSpot = (board[currentRow, nextCol]);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool isOneMoveLegal(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (((this.getIsWhite() == true) && nextRow - currentRow == -1) || ((this.getIsWhite() == false) && nextRow - currentRow == 1))
            {
                if ((board[currentRow, currentCol].getIsWhite() == false) && (nextRow > currentRow))
                {
                    for (currentRow++; (currentRow <= nextRow); currentRow++)
                        if (!(board[currentRow, currentCol] == null))
                            return false;
                }
                else if ((board[currentRow, currentCol].getIsWhite() == true) && (nextRow < currentRow))
                    for (currentRow--; (currentRow >= nextRow); currentRow--)
                        if (!(board[currentRow, currentCol] == null))
                            return false;
            }
            else
                return false;
            return true;
        }
        public bool isTwoMovesLegal(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if ((nextRow - currentRow == 2) || ((nextRow - currentRow == -2)))
            {
                if (((board[currentRow, nextCol].getIsWhite() == false) && board[(currentRow + 1), nextCol] == null || ((board[currentRow, nextCol].getIsWhite() == true) && board[(currentRow - 1), nextCol] == null)))
                {
                    if (((currentRow == 1 && nextRow - currentRow == 2) || (currentRow == 6 && nextRow - currentRow == -2)))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }
    }
    class Rook : ChessPiece
    {
        public bool isMoved=false;
        public Rook(bool iswhite, int row, int column,int number) : base(iswhite, row, column,number) 
        {
            this.setIsMoved(false);
        }
        public void setIsMoved(bool isMoved)
        {
            this.isMoved = isMoved;
        }
        public bool getIsMoved()
        {
            return isMoved;
        }
        public override string ToString()
        {
            return "R" + base.ToString();
        }
        public override bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if ((nextRow == currentRow && nextCol == currentCol) || (nextRow != currentRow && nextCol != currentCol))
                return false;
            return isPathEmpty(board, nextRow, nextCol);
  
        }
        public bool isPathEmpty(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (nextCol == currentCol)
            {
                if (isVerticalPathEmpty(board, nextRow, nextCol))
                    return true;
            }
            else
            {
                if (isHorizontalPathEmpty(board, nextRow, nextCol))
                    return true;
            }
            return false ;
        }
        public bool isHorizontalPathEmpty(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (nextCol > currentCol)
            {
                for (currentCol++; (currentCol < nextCol); currentCol++)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }
            else if (nextCol<currentCol)
            {
                for (currentCol--; (currentCol > nextCol); currentCol--)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }
            else
                return false;
            return true;
        }
        public bool isVerticalPathEmpty(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (nextRow > currentRow)
            {
                for (currentRow++; (currentRow < nextRow); currentRow++)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }
            else if (nextRow < currentRow)
            {
                for (currentRow--; (currentRow > nextRow); currentRow--)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }
            else
                return false;
            return true;
        }
    }
    class Bishop : ChessPiece
    {
        public override string ToString()
        {
            return "B" + base.ToString();
        }
        public Bishop(bool iswhite, int row, int column, int number) : base(iswhite, row, column, number) { }
        public override bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (((nextCol == currentCol) && (nextRow == currentRow)) || !(((nextRow - currentRow) == (nextCol - currentCol)) || ((nextRow - currentRow) == (-(nextCol - currentCol)))))
                return false;
            return isPathEmpty(board, nextRow, nextCol);
        }
        public bool isPathEmpty(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if ((nextRow - currentRow == nextCol - currentCol) || (nextRow - currentRow == currentCol - nextCol))
            {
                if (isUpPathLegal(board, nextRow, nextCol))
                    return true;
                else if (isDownPathLegal(board, nextRow, nextCol))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public bool isUpPathLegal(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            // up and right
            if ((nextRow - currentRow < 0) && (nextCol - currentCol > 0))
            {
                for (currentRow--, currentCol++; (currentRow > 0 && currentCol < 8) && (currentRow > nextRow); currentRow--, currentCol++)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }//up and left
            else if (nextRow - currentRow < 0 && nextCol - currentCol < 0)
            {
                for (currentRow--, currentCol--; (currentRow > 0 && currentCol > 0) && (currentRow > nextRow); currentRow--, currentCol--)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }
            else
                return false;
            return true;
        }
        public bool isDownPathLegal(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            // down and right
            if ((nextRow - currentRow > 0) && (nextCol - currentCol > 0))
            {
                for (currentRow++, currentCol++; (currentRow < 8 && currentCol < 8) && (currentRow < nextRow); currentRow++, currentCol++)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            } // down and left
            else if ((nextRow - currentRow > 0) && (nextCol - currentCol < 0))
            {
                for (currentRow++, currentCol--; (currentRow < 8 && currentCol > 0) && (currentRow < nextRow); currentRow++, currentCol--)
                    if (!(board[currentRow, currentCol] == null))
                        return false;
            }
            else
                return false;
            return true;
        }
    }
    class Knight : ChessPiece
    {
        public Knight(bool iswhite, int row, int column, int number) : base(iswhite, row, column, number) { }
        public override string ToString()
        {
            return "N" + base.ToString();
        }
        public override bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if (nextRow == currentRow && nextCol == currentCol)
                return false;
            if (((nextCol - currentCol == 1) || (nextCol - currentCol == -1)) && ((nextRow - currentRow == 2) || (nextRow - currentRow == -2)))
                return true;
            if (((nextRow - currentRow == 1) || (nextRow - currentRow == -1)) && ((nextCol - currentCol == 2) || (nextCol - currentCol == -2)))
                return true;
            else return false;
        }
    }
    class Queen : ChessPiece
    {
        Rook queenAsRook;
        Bishop queenAsBishop;
        public Queen(bool iswhite, int row, int column, int number) : base(iswhite, row, column, number)
        {
            setQeenAsRook();
            setQeenAsBishop();
        }
        public override string ToString()
        {
            return "Q" + base.ToString();
        }
        public void setQeenAsRook()
        {
            this.queenAsRook=new Rook(getIsWhite(), getRow(), getCol(),getPieceNumber());
        }
        public Rook getQueenAsRook()
        {
            return queenAsRook;
        }
        public void setQeenAsBishop()
        {
            this.queenAsBishop = new Bishop(getIsWhite(), getRow(), getCol(), getPieceNumber());
        }
        public Bishop getQueenAsBishop()
        {
            return queenAsBishop;
        }
        public override bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            setQeenAsRook();
            setQeenAsBishop();
          return queenAsRook.isPossibleMove(board, nextRow, nextCol)||queenAsBishop.isPossibleMove(board,nextRow,nextCol);
        }
    }
    class King : ChessPiece
    {
        bool isMoved=false;
        Queen kingAsQueen;
        public void setIsMoved(bool isMoved)
        {
            this.isMoved = isMoved;
        }
        public bool getIsMoved()
        {
            return isMoved;
        }
        public void setKingAsQueen()
        {
            this.kingAsQueen = new Queen(getIsWhite(), getRow(), getCol(),getPieceNumber());
        }
        public Queen getQueenAsRook()
        {
            return kingAsQueen;
        }
        public King(bool iswhite, int row, int column, int number) : base(iswhite, row, column, number)
        {
            this.setIsMoved(false);
            this.setKingAsQueen();
        }
        public override string ToString()
        {
            return "K" + base.ToString();
        }
        public override bool isPossibleMove(ChessPiece[,] board, int nextRow, int nextCol)
        {
            int currentRow = this.getRow(), currentCol = this.getCol();
            if ((nextRow == currentRow && nextCol == currentCol) || (nextRow - currentRow > 1) || (nextRow - currentRow < -1) || (nextCol - currentCol > 1) || (nextCol - currentCol < -1))
                return false;
            setKingAsQueen();
            return kingAsQueen.isPossibleMove(board, nextRow, nextCol);
        }
    }
}