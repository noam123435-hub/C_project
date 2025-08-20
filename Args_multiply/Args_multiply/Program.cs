namespace Args_multiply
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] before=new int[3] {10,20,30};
            int[] after=mularray(before,5);
            for (int i = 0; i < after.Length; i++)
                Console.WriteLine(after[i]);
        }
        static int[] mularray(int[] ints, int multiplyBy)
        {
            int[] result = new int[ints.Length];
            for (int i = 0;i<result.Length;i++)
                result[i]=ints[i]* multiplyBy;
            return result;
        }
    }
}
