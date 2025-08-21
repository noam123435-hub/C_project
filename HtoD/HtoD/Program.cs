namespace HtoD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please enter a Hex number and press ENTER");
            string Hex=Console.ReadLine();
            int  Visualvalue=0,Dec = 0,PositionalValue = 1;
            for(int i=Hex.Length-1;i>=0;i--)
            {   
                switch(Hex[i])
                {
                    case 'a': case 'A':
                        Visualvalue = 10;
                        break;
                    case 'b': case 'B':
                        Visualvalue = 11;
                        break;
                    case 'c': case 'C':
                        Visualvalue = 12;
                        break;
                    case 'd': case 'D':
                        Visualvalue = 13;
                        break;
                    case 'e': case 'E':
                        Visualvalue = 14;
                        break;
                    case 'f': case 'F':
                        Visualvalue = 15;
                        break;
                    default:
                        Visualvalue = int.Parse(Hex[i]+"");
                        break;
                }
                Dec += (Visualvalue*PositionalValue);
                PositionalValue *= 16;
            }
            Console.WriteLine("the DEC number is : "+Dec);
        }
    }
}
