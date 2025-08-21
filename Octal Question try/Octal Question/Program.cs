namespace Octal_Question
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Console.WriteLine(i);
            i = i + 1;
            int notnumber = 77;
            int bignotnumber = 1777;
            while(i>0 && i<=7777)
            {
                while (i % 10 == 8 || i % 10 == 9)
                    i = i + 1;

                if (i == notnumber)
                {
                    Console.WriteLine(i);
                    i = 100;
                    notnumber = notnumber + 1000;
                }
                Console.WriteLine(i);
                i = i + 1;

                while (i >= 100)
                {

                    while (i % 10 == 8 || i % 10 == 9)
                        i = i + 1;

                    if (i == notnumber)
                    {
                        Console.WriteLine(i);

                        if (i == 777)
                        {
                            i = 1000;
                            notnumber = 1077;
                        }
                        else
                        {
                            i = i + 22;
                            notnumber = notnumber + 100;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine(i);
                        i = i + 1;
                    }
                    while (i > 1000)
                    {
                        while (i % 10 == 8 || i % 10 == 9)
                            i = i + 1;

                        if (i == notnumber)
                        {
                            Console.WriteLine(i);
     
                            if (i == bignotnumber)
                            {
                                notnumber = notnumber + 300;
                                bignotnumber = bignotnumber+1000;
                                i = notnumber - 7;
                            }
                            else
                            {
                                i = i + 22;
                                notnumber = notnumber + 100;
                            }
                        }
                        else
                        {
                            Console.WriteLine(i);
                            i = i + 1;

                        }
                    }
                }
            }
            Console.WriteLine("the count is over");
        }
    }
}
