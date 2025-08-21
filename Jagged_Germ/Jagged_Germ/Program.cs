namespace Jagged_Germ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] germs = {[1000,1500,2040],[3000,3400,4959],[5670,3045,2300,4567],[3436,4235,5410,4567]};
            for (int row = 0; row < germs.Length; row++)
            {
                for (int col = 0; col < germs[row].Length; col++)
                    Console.Write(germs[row][col]+" ");
                Console.WriteLine();
            }
                
        }
    }
}
