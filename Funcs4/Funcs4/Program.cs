namespace Funcs4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the base and press enter");
            int b=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the maarich and press enter");
            int m=int.Parse(Console.ReadLine());
            int hezkavalue=hezka(b, m);
            Console.WriteLine(hezkavalue);
            
        }
        static int hezka(int basis, int maarich)
        {
            int hezka=1;
            for (int i = 0; i < maarich; i++)
            {
                hezka *= basis;
            }
            return hezka;
        }
    }
}
