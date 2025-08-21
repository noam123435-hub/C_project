using System;

namespace tren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter a number and press ENTER");
            int n1=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number band press ENTER");
            int n2=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n3=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n4 = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n5 = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n6 = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n7 = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n8 = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n9 = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter a number and press ENTER");
            int n10 = int.Parse(Console.ReadLine());
            int biggest=n1;
            biggest = biggest >= n2 ? biggest : n2;
            biggest = biggest >= n3 ? biggest : n3;
            biggest = biggest >= n4 ? biggest : n4;
            biggest = biggest >= n5 ? biggest : n5;
            biggest = biggest >= n6 ? biggest : n6;
            biggest = biggest > n7 ? biggest : n7;
            biggest = biggest > n8 ? biggest : n8;
            biggest = biggest > n9 ? biggest : n9;
            biggest = biggest > n10 ? biggest : n10;
            Console.WriteLine(biggest);


        }
    }
}
