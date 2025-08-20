namespace chari;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("please enter a integer number and press ENTER");
        int number=int.Parse(Console.ReadLine());
        int n = 1;

        while (n*n<number)
        {
            n = n + 1;
        }
        if (n * n == number)
            Console.WriteLine("the shoresh of " + number + " is " + n);
        else
            Console.WriteLine("the number " + number + " hasn't shoresh");

            
    }
}
