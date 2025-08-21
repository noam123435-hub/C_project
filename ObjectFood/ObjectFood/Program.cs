using System.Runtime.InteropServices;

namespace ObjectFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Food[] meals;
            meals = new Food[10];
            double average = 0;
            Console.WriteLine("Hello!");
            for(int i=0;i<meals.Length;i++)
            {
                meals[i] = new Food();
                input(meals[i]);
                average += meals[i].Calories;
            }
            average /= 10;
            Console.WriteLine();
            Console.WriteLine("The Calories Average is : "+average);
            for(int i=0; i<meals.Length; i++)
            {
                if (meals[i].Calories>average)
                    print(meals[i]);
            }
        }
        static void input(Food food)
        {
            Console.WriteLine("Please enter the name of the food and prees ENTER");
            food.Name = Console.ReadLine();
            Console.WriteLine("please enter the number of Calories per 100 grams of " + food.Name + " and press ENTER");
            food.Calories=double.Parse(Console.ReadLine());
            Console.WriteLine("If " + food.Name + " is tasty please enter 'y' if not please enter 'n' and press ENTER");
            string input=Console.ReadLine();
            food.IsTasty = (input[0] == 'y');
        }
        static void print(Food food)
        {
            Console.WriteLine("100 grams of "+food.Name+" has "+food.Calories+" Calories, and "+((food.IsTasty)?"is delicious":"it's doesn't taste good"));
        }
    }
    class Food
    {
        public string Name;
        public double Calories;
        public bool IsTasty;
    }
}
