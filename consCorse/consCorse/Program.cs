using System.Reflection.Metadata.Ecma335;

namespace consCorse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course history=new Course("vikings","Prof Londin");
            Student first=new Student("Noam","316525641",27,"education",4);
            Student second=new Student("Aron","321321321",28,"education",4);
            Student third=new Student("Ziv","123321432",26,"history",3);
            third.addyear();
            history.addstudent(first);
            history.addstudent(second);
            history.addstudent(third);
            history.print();
        }
    }
    class Student
    {
        string name;
        string id;
        int age;
        string degreetype;
        int year;
        public Student(string name, string id,int age,string degreetype,int year)
        {
            this.name = name;
            this.id = id;
            this.age = age;
            this.degreetype = degreetype;
            this.year = year;
        }
        public void print()
        {
            Console.WriteLine(this.name+"-"+this.id+" is "+this.age+" years old, in his "+this.year+" year at "+this.degreetype+" degree");
        }
        public void addyear()
        {
            this.year++;
        }
    }
    class Course
    {
        string nameCourse;
        string nameProf;
        Student[] students;
        int studentnumber;
        public Course(string namec,string namep)
        {
            this.nameCourse = namec;
            this.nameProf = namep;
            students = new Student[30];  
        }
        public bool addstudent(Student student)
        {
            if (this.studentnumber == 30)
                return false;
            this.students[studentnumber] = student;
            this.studentnumber++;
            return true;            
        }
        public void print()
        {
            Console.WriteLine("the course " + this.nameCourse + " is teaches by " + this.nameProf);
            Console.WriteLine("the following " + this.studentnumber + " students are registered to this Coursr :");
            for (int i = 0; i < this.studentnumber; i++)
                this.students[i].print();
        }

    }
}
