namespace Arrays3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] students;
            students = new string[10];
            int[] grade;
            grade=new int[10];
            int avg = 0;
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("please enter the name of the student ans press ENTER");
                students[i]=Console.ReadLine();
                Console.WriteLine("please enter the grade of "+students[i]);
                grade[i]=int.Parse(Console.ReadLine());
                avg += grade[i];
            }
            avg /= 10;
            Console.WriteLine("the average is : "+avg);
            Console.WriteLine("the sudents who scored below the average are :");
            for (int i = 0;i < students.Length;i++)
            {
                if (grade[i]<avg)
                    Console.WriteLine(students[i]);
            }
        }
    }
}
