using Microsoft.VisualBasic;

namespace ObjectStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student user;
            user = new Student();
            Console.WriteLine("Hello, student! please enter your name and press ENTER");
            user.Name = Console.ReadLine();
            Console.WriteLine("please enter your age and press ENTER");
            user.age = int.Parse(Console.ReadLine());
            Console.WriteLine("please enter your Grade's Average and press ENTER");
            user.GradeAverage = double.Parse(Console.ReadLine());
            Console.WriteLine("please enter your degree's Year and press ENTER");
            user.Year = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Hello "+user.Name+" You are "+user.age+" year old, your average is "+user.GradeAverage+" and it's your "+user.Year+" year at school");
        }
    }
    class Student
    {
        public string Name;
        public int age;
        public double GradeAverage;
        public int Year;
    }
}
