namespace FuncBMI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, plese enter your weight in kg and press ENTER");
            double Weight=double.Parse(Console.ReadLine());
            Console.WriteLine("please enter your heightin meters and press ENTER");
            double Hieght=double.Parse(Console.ReadLine());
            Console.WriteLine("your BMI is " + bmi(Weight, Hieght));
        }
        static double bmi(double weight, double hieght)
        {
            return weight / (hieght * hieght);
        }
    }
}
