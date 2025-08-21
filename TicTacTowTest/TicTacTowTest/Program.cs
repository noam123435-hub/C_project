namespace TicTacTowTest
{
    internal class Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                int count = 0;
                bool playerTurn = true;
                bool victory = false;
                bool turnDone = false;

                char[] spots = new char[9];
                string[] rownum = new string[8];
                int[] xTimes = new int[8];
                int[] oTimes = new int[8];

                // Initialize the board
                for (int i = 0; i < spots.Length; i++)
                {
                    spots[i] = '-';
                }

                while (count < 9 && !victory)
                {
                    Console.Clear();
                    Console.WriteLine($"{spots[0]} | {spots[1]} | {spots[2]}");
                    Console.WriteLine("--+---+--");
                    Console.WriteLine($"{spots[3]} | {spots[4]} | {spots[5]}");
                    Console.WriteLine("--+---+--");
                    Console.WriteLine($"{spots[6]} | {spots[7]} | {spots[8]}");

                    // Reset counters
                    for (int i = 0; i < 8; i++)
                    {
                        xTimes[i] = 0;
                        oTimes[i] = 0;
                    }

                    rownum[0] = "0/1/2";
                    rownum[1] = "3/4/5";
                    rownum[2] = "6/7/8";
                    rownum[3] = "0/3/6";
                    rownum[4] = "1/4/7";
                    rownum[5] = "2/5/8";
                    rownum[6] = "0/4/8";
                    rownum[7] = "2/4/6";

                    // Count player and computer moves
                    for (int i = 0; i < 8; i++)
                    {
                        string[] positions = rownum[i].Split('/');
                        foreach (string p in positions)
                        {
                            int pos = int.Parse(p);
                            if (spots[pos] == 'X')
                                xTimes[i]++;
                            else if (spots[pos] == 'O')
                                oTimes[i]++;
                        }
                    }

                    // Check for victory
                    for (int i = 0; i < 8; i++)
                    {
                        if (xTimes[i] == 3 || oTimes[i] == 3)
                        {
                            victory = true;
                            break;
                        }
                    }

                    if (victory)
                        break;

                    turnDone = false;

                    if (playerTurn)
                    {
                        Console.Write("Enter a number (0-8): ");
                        int choise = int.Parse(Console.ReadLine());
                        if (spots[choise] == '-')
                        {
                            spots[choise] = 'X';
                            count++;
                            playerTurn = false;
                            turnDone = true;
                        }
                    }
                    else
                    {
                        // Try to win
                        for (int i = 0; i < 8 && !turnDone; i++)
                        {
                            if (oTimes[i] == 2 && xTimes[i] == 0)
                            {
                                string[] parts = rownum[i].Split('/');
                                foreach (string p in parts)
                                {
                                    int pos = int.Parse(p);
                                    if (spots[pos] == '-')
                                    {
                                        spots[pos] = 'O';
                                        count++;
                                        turnDone = true;
                                        break;
                                    }
                                }
                            }
                        }

                        // Try to block
                        for (int i = 0; i < 8 && !turnDone; i++)
                        {
                            if (xTimes[i] == 2 && oTimes[i] == 0)
                            {
                                string[] parts = rownum[i].Split('/');
                                foreach (string p in parts)
                                {
                                    int pos = int.Parse(p);
                                    if (spots[pos] == '-')
                                    {
                                        spots[pos] = 'O';
                                        count++;
                                        turnDone = true;
                                        break;
                                    }
                                }
                            }
                        }

                        // Take center
                        if (!turnDone && spots[4] == '-')
                        {
                            spots[4] = 'O';
                            count++;
                            turnDone = true;
                        }

                        // Take any open spot
                        for (int i = 0; i < 9 && !turnDone; i++)
                        {
                            if (spots[i] == '-')
                            {
                                spots[i] = 'O';
                                count++;
                                turnDone = true;
                                break;
                            }
                        }

                        playerTurn = true;
                    }
                }

                Console.Clear();
                Console.WriteLine(${spots[0]} | {spots[1]} | {spots[2]}");
                Console.WriteLine("--+---+--");
                Console.WriteLine($"{spots[3]} | {spots[4]} | {spots[5]}");
                Console.WriteLine("--+---+--");
                Console.WriteLine($"{spots[6]} | {spots[7]} | {spots[8]}");

                if (victory)
                {
                    Console.WriteLine(playerTurn ? "המחשב ניצח!" : "השחקן ניצח!");
                }
                else
                {
                    Console.WriteLine("תיקו!");
                }

                Console.ReadLine();
            }
        }
    }
}
