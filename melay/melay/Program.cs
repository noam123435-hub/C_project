namespace melay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("wellcome to your Shop! please enter the name of the product");
            string product=Console.ReadLine();
            Console.WriteLine("please enter the amount");
            int amount=int.Parse(Console.ReadLine());
            Console.WriteLine("please enter the price");
            int price = int.Parse(Console.ReadLine());
            string message = "";

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("for add 1 product enter add");
            Console.WriteLine("for reduce 1 product enter reduce");
            Console.WriteLine("for update the price enter update");
            Console.WriteLine("for showing the details of the product enter show");
            Console.WriteLine("for exit the program enter exit");

            while (message!= "exit")
            {
                Console.WriteLine("What do you want to do?");
                message = Console.ReadLine();

                if (message=="add")
                {
                    amount = amount + 1;
                    Console.WriteLine("you have "+amount+" "+product);
                }
                if(message=="reduce")
                {
                    amount = amount- 1;
                    Console.WriteLine("you have " + amount + " " + product);
                }
                if (message == "update")
                {
                    Console.WriteLine("please enter the new price");
                    price=int.Parse(Console.ReadLine());
                    Console.WriteLine("the new price is "+price+" nis");
                }
                if (message == "show")
                {
                    Console.WriteLine("You have " + amount + " " + product);
                    Console.WriteLine("the price is " + price + " nis");
                }
                

            }

        }
    }
}
