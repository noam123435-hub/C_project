namespace DetToHex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a DEC number and press ENTER");
            int DEC=int.Parse(Console.ReadLine());
            string hexdigits = "0123456789ABCDEF", Hex = "";
            int remainder = 0;
            if(DEC==0)
                Hex= "0";
            while (DEC!=0)
            {
                remainder = DEC % 16;
                DEC /= 16;
                Hex = hexdigits[remainder] + Hex;
              
            }
            Console.WriteLine("the HEX number is : "+ Hex);
        }
    }
}
