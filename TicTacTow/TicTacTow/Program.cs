using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace TicTacTow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // הזנת נתונים+ הדפסה ראשונית
            string[] Lines;
            Lines = new string[3];
            char[] spots;
            spots = new char[9];
            string FirsrRow = "  1 2 3";
            for (int i = 0; i < 9; i++)
                spots[i] = '-';
            Lines[0] = "1 ";
            for (int i = 0; i < 3; i++)
                Lines[0] += spots[i] + " ";
            Lines[1] = "2 ";
            for (int i = 3; i < 6; i++)
                Lines[1] += spots[i] + " ";
            Lines[2] = "3 ";

            for (int i = 6; i < 9; i++)
                Lines[2] += spots[i] + " ";
            Console.WriteLine(FirsrRow);
            for (int i = 0; i < 3; i++)
                Console.WriteLine(Lines[i]);
            //הזנת נתונים
            bool victory = false, Turndone = false;
            int CounTurn = 1, Count = 0, Jump;
            int row, column, playerchoise, ComputerChoise = 0;
            string[] possiblewin;
            possiblewin = new string[8];
            possiblewin[0] = "0/1/2";
            possiblewin[1] = "6/7/8";
            possiblewin[2] = "0/3/6";
            possiblewin[3] = "2/5/8";
            possiblewin[4] = "3/4/5";
            possiblewin[5] = "1/4/7";
            possiblewin[6] = "0/4/8";
            possiblewin[7] = "2/4/6";
            string[] LookUpRow;
            LookUpRow = new string[8];
            string Diagonal, Middle;
            bool FoundX = false, FoundO = false;
            while (CounTurn < 10 & !victory)
            {
                Console.WriteLine("please enter the row:");
                row = inputinterger(Console.ReadLine());
                Console.WriteLine("please enter the column:");
                column = inputinterger(Console.ReadLine());
                playerchoise = change(row, column);
                if (spots[playerchoise] == '-')
                {
                    spots[playerchoise] = 'X';
                    CounTurn++;
                    Turndone = false;
                }
                else
                    Console.WriteLine("the spot is taken");
                Lines[0] = "1 ";
                for (int i = 0; i < 3; i++)
                    Lines[0] += spots[i] + " ";
                Lines[1] = "2 ";
                for (int i = 3; i < 6; i++)
                    Lines[1] += spots[i] + " ";
                Lines[2] = "3 ";
                for (int i = 6; i < 9; i++)
                    Lines[2] += spots[i] + " ";
                LookUpRow[0] = spots[0] + "/" + spots[1] + "/" + spots[2] + "/";
                LookUpRow[1] = spots[6] + "/" + spots[7] + "/" + spots[8] + "/";
                LookUpRow[2] = spots[0] + "/" + spots[3] + "/" + spots[6] + "/";
                LookUpRow[3] = spots[2] + "/" + spots[5] + "/" + spots[8] + "/";
                LookUpRow[4] = spots[3] + "/" + spots[4] + "/" + spots[5] + "/";
                LookUpRow[5] = spots[1] + "/" + spots[4] + "/" + spots[7] + "/";
                LookUpRow[6] = spots[0] + "/" + spots[4] + "/" + spots[8] + "/";
                LookUpRow[7] = spots[2] + "/" + spots[4] + "/" + spots[6] + "/";
                for (int index = 0; index < 8 && !victory; index++)
                {
                    Count = 0;
                    for (int irow = 0; irow < LookUpRow[index].Length - 1; irow++)
                        if (LookUpRow[index][irow] == 'O')
                            Count++;
                    if (Count == 3)
                    {
                        victory = true;
                        continue;
                    }
                    Count = 0;
                    for (int irow = 0; irow < LookUpRow[index].Length - 1; irow++)
                        if (LookUpRow[index][irow] == 'X')
                            Count++;
                    if (Count == 3)
                    {
                        victory = true;
                        continue;
                    }
                }
                while (CounTurn < 10 && !Turndone && !victory)
                {
                    Turndone = false;
                    //בתור הראשון
                    if (CounTurn == 2)
                    {
                        for (int i = 0; i < spots.Length && !Turndone; i++)
                        {
                            if (spots[4] == 'X')
                            {
                                ComputerChoise = 0;
                                spots[ComputerChoise] = 'O';
                                Turndone = true;
                                CounTurn++;
                            }
                            else
                            {
                                ComputerChoise = 4;
                                spots[ComputerChoise] = 'O';
                                Turndone = true;
                                CounTurn++;
                            }
                        }
                    }
                    // אם המחשב יכול לנצח- ינצח
                    for (int index = 0; index < 8 && !Turndone; index++)
                    {
                        Count = 0;
                        for (int irow = 0; irow < LookUpRow[index].Length - 1; irow++)
                        {
                            if (LookUpRow[index][irow] == 'O')
                                Count++;
                            if (Count == 2)
                            {
                                Count = 0;
                                while (Count < possiblewin.Length && !Turndone)
                                {
                                    if (Count < possiblewin[index].Length && (possiblewin[index][Count] != '/'))
                                        ComputerChoise = int.Parse("" + possiblewin[index][Count]);
                                    if ((Count < possiblewin.Length) && (spots[ComputerChoise] == '-'))
                                    {
                                        spots[ComputerChoise] = 'O';
                                        Turndone = true;
                                        CounTurn++;
                                        continue;
                                    }
                                    else
                                        Count++;
                                }
                            }
                        }
                    }

                    // אם יכול למנוע ניצחון- מנע
                    for (int index = 0; index < 8 && !Turndone; index++)
                    {
                        Count = 0;
                        for (int irow = 0; irow < LookUpRow[index].Length - 1; irow++)
                        {
                            if (LookUpRow[index][irow] == 'X')
                                Count++;
                            if (Count == 2)
                            {
                                Count = 0;
                                while (Count < possiblewin.Length && !Turndone)
                                {
                                    if (Count < possiblewin[index].Length && (possiblewin[index][Count] != '/'))
                                        ComputerChoise = int.Parse("" + possiblewin[index][Count]);
                                    if ((Count < possiblewin.Length) && (spots[ComputerChoise] == '-'))
                                    {
                                        spots[ComputerChoise] = 'O';
                                        Turndone = true;
                                        CounTurn++;
                                        continue;
                                    }
                                    else
                                        Count++;
                                }
                            }
                        }
                    }
                    // כשהשחקן או המחשב לא יכולים לנצח- קידום ניצחון
                    //שני אמצעים
                    Middle = spots[1] + "/" + spots[3] + "/" + spots[5] + "/" + spots[7] + "/";
                    Count = 0;
                    for (int i = 0; (i < Middle.Length) && !Turndone; i++)
                    {
                        if ((Middle[i] == 'X'))
                            Count++;
                        if (Count > 1)
                        {
                            for (int index = 0; (index < possiblewin[index].Length) && !Turndone; index++)
                            {
                                for (int j = 0; (j < LookUpRow[index].Length) && !Turndone; j++)
                                {
                                    if ((LookUpRow[index][j] == 'X'))
                                    {
                                        FoundO = false;
                                        for (int look = 0; (look < LookUpRow[i].Length) && !FoundO; look++)
                                        {
                                            if (LookUpRow[index][look] == 'O')
                                                FoundO = true;
                                        }
                                        if (!FoundO)
                                        {
                                            for (int t = 0; (j < LookUpRow[i].Length) && !Turndone; t++)
                                            {
                                                if (LookUpRow[index][0] == '-')
                                                {
                                                    ComputerChoise = int.Parse("" + (possiblewin[index][0]));
                                                    spots[ComputerChoise] = 'O';
                                                    Turndone = true;
                                                    CounTurn++;
                                                    continue;
                                                }
                                                else if (LookUpRow[index][LookUpRow[i].Length - 2] == '-')
                                                {
                                                    ComputerChoise = int.Parse("" + (possiblewin[index][possiblewin[index].Length - 1]));
                                                    spots[ComputerChoise] = 'O';
                                                    Turndone = true;
                                                    CounTurn++;
                                                    continue;
                                                }
                                                else if (LookUpRow[index][t] == '-')
                                                {
                                                    ComputerChoise = int.Parse("" + (possiblewin[index][t]));
                                                    spots[ComputerChoise] = 'O';
                                                    Turndone = true;
                                                    CounTurn++;
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //שתי פינות
                    Diagonal = spots[0] + "/" + spots[2] + "/" + spots[6] + "/" + spots[8] + "/";
                    Count = 0;
                    for (int i = 0; (i < Diagonal.Length) && !Turndone; i++)
                    {
                        if ((Diagonal[i] == 'X'))
                            Count++;
                        if (Count > 1)
                        {
                            Jump = 1;
                            while ((Jump < spots.Length - 1) && !Turndone)
                            {
                                if ((Count > 1) && (Jump < spots.Length))
                                {

                                    if (spots[Jump] == '-')
                                    {
                                        ComputerChoise = Jump;
                                        spots[ComputerChoise] = 'O';
                                        Turndone = true;
                                        CounTurn++;
                                        continue;
                                    }
                                    else
                                        Jump += 2;
                                }
                            }
                        }
                    }
                    //פינה ואמצע
                    Count = 0;
                    Jump = 0;
                    for (int i = 0; (i < Diagonal.Length) && !Turndone; i++)
                    {
                        if ((Diagonal[i] == 'X'))
                            Count++;
                        if (Count > 0)
                        {

                            Count = 0;
                            for (int j = 0; (j < Middle.Length) && !Turndone; j++)
                            {
                                if ((Middle[j] == 'X'))
                                    Count++;
                                if (Count > 0)
                                {
                                    FoundX = false;
                                    for (int look = 0; (look < LookUpRow[i].Length) && (i < LookUpRow[i].Length) && !FoundX; look++)
                                    {
                                        if (LookUpRow[i][look] == 'X')
                                        {
                                            FoundX = true;
                                            i++;
                                        }
                                    }
                                    if (!FoundX)
                                    {
                                        Jump = 0;
                                        i = 0;
                                        while ((Jump < LookUpRow[Jump].Length) && !Turndone)
                                        {
                                            FoundX = false;
                                            for (int look = 0; (look < LookUpRow[i].Length) && (i < LookUpRow.Length) && !FoundX && !Turndone; look++)
                                            {
                                                if (LookUpRow[i][look] == 'X')
                                                {
                                                    FoundX = true;
                                                    i++;
                                                }
                                            }
                                            if ((LookUpRow[Jump][2] == '-') && !FoundX)
                                            {
                                                ComputerChoise = int.Parse("" + (possiblewin[Jump][2]));
                                                spots[ComputerChoise] = 'O';
                                                Turndone = true;
                                                CounTurn++;
                                                continue;
                                            }
                                            else
                                                Jump++;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    //שאר מקרים
                    for (int i = LookUpRow.Length - 1; (i >= 0) && !Turndone; i--)
                    {
                        Count = 0;
                        for (int irow = 0; (irow < LookUpRow[i].Length) && !Turndone; irow++)
                        {
                            if ((LookUpRow[i][irow] == 'O'))
                                Count++;
                            if (Count > 0)
                            {
                                FoundX = false;
                                for (int look = 0; (look < LookUpRow[i].Length) && !FoundX; look++)
                                {
                                    if (LookUpRow[i][look] == 'X')
                                        FoundX = true;
                                }
                                if (!FoundX)
                                {
                                    for (int j = 0; (j < LookUpRow[i].Length) && !Turndone; j++)
                                    {
                                        if (LookUpRow[i][0] == '-')
                                        {
                                            ComputerChoise = int.Parse("" + (possiblewin[i][0]));
                                            spots[ComputerChoise] = 'O';
                                            Turndone = true;
                                            CounTurn++;
                                            continue;
                                        }
                                        else if (LookUpRow[i][LookUpRow[i].Length - 2] == '-')
                                        {
                                            ComputerChoise = int.Parse("" + (possiblewin[i][possiblewin[i].Length - 1]));
                                            spots[ComputerChoise] = 'O';
                                            Turndone = true;
                                            CounTurn++;
                                            continue;
                                        }
                                        else if (LookUpRow[i][j] == '-')
                                        {
                                            ComputerChoise = int.Parse("" + (possiblewin[i][j]));
                                            spots[ComputerChoise] = 'O';
                                            Turndone = true;
                                            CounTurn++;
                                            continue;
                                        }
                                    }
                                }
                                else
                                    continue;
                            }
                        }
                    }
                    for (int index = 0; (index < spots.Length) && !Turndone; index++)
                    {
                        if (spots[index] == '-')
                        {
                            spots[index] = 'O';
                            Turndone = true;
                            CounTurn++;
                            continue;
                        }
                    }
                }

                //הדפסת הלוח עם בחירת השחקן והמחשב
                Lines[0] = "1 ";
                for (int i = 0; i < 3; i++)
                    Lines[0] += spots[i] + " ";
                Lines[1] = "2 ";
                for (int i = 3; i < 6; i++)
                    Lines[1] += spots[i] + " ";
                Lines[2] = "3 ";
                for (int i = 6; i < 9; i++)
                    Lines[2] += spots[i] + " ";
                Console.WriteLine(FirsrRow);
                for (int i = 0; i < 3; i++)
                    Console.WriteLine(Lines[i]);
                LookUpRow[0] = spots[0] + "/" + spots[1] + "/" + spots[2] + "/";
                LookUpRow[1] = spots[3] + "/" + spots[4] + "/" + spots[5] + "/";
                LookUpRow[2] = spots[6] + "/" + spots[7] + "/" + spots[8] + "/";
                LookUpRow[3] = spots[0] + "/" + spots[3] + "/" + spots[6] + "/";
                LookUpRow[4] = spots[1] + "/" + spots[4] + "/" + spots[7] + "/";
                LookUpRow[5] = spots[2] + "/" + spots[5] + "/" + spots[8] + "/";
                LookUpRow[6] = spots[0] + "/" + spots[4] + "/" + spots[8] + "/";
                LookUpRow[7] = spots[2] + "/" + spots[4] + "/" + spots[6] + "/";
                for (int index = 0; index < 8 && !victory; index++)
                {
                    Count = 0;
                    for (int irow = 0; irow < LookUpRow[index].Length - 1; irow++)
                        if (LookUpRow[index][irow] == 'O')
                            Count++;
                    if (Count == 3)
                        victory = true;
                    Count = 0;
                    for (int irow = 0; irow < LookUpRow[index].Length - 1; irow++)
                        if (LookUpRow[index][irow] == 'X')
                            Count++;
                    if (Count == 3)
                        victory = true;
                }
            }
            Console.WriteLine("Game over");
        }

        static int change(int r, int c)
        {
            int number = 0;
            string rc = +r + "/" + c;
            switch (rc)
            {
                case "1/1":
                    number = 0;
                    break;
                case "1/2":
                    number = 1;
                    break;
                case "1/3":
                    number = 2;
                    break;
                case "2/1":
                    number = 3;
                    break;
                case "2/2":
                    number = 4;
                    break;
                case "2/3":
                    number = 5;
                    break;
                case "3/1":
                    number = 6;
                    break;
                case "3/2":
                    number = 7;
                    break;
                case "3/3":
                    number = 8;
                    break;
            }
            return number;
        }

        static int inputinterger(string input)
        {
            bool valid = false;
            int begin, end;
            while (!valid)
            {
                valid = true;
                begin = 0;
                while ((begin < input.Length) && (input[begin] == ' '))
                    begin++;
                end = input.Length - 1;
                while ((end >= 0) && (input[end] == ' '))
                    end--;
                if ((end < begin) || ((end - begin) > 0))
                    valid = false;
                for (int i = begin; i <= end && valid; i++)
                {
                    switch (input[i])
                    {
                        case '1':
                        case '2':
                        case '3':
                            return int.Parse(input);
                            break;
                        default:
                            valid = false;
                            break;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("invalid, please try again");
                    input = Console.ReadLine();
                }
            }
            return int.Parse(input);
        }
    }
}
        
    

