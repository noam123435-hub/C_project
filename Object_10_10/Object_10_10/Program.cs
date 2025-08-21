using System.Diagnostics;

namespace Object_10_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person;
            person = Person.makePerson();
            person.getPerson("Noam",27,"0506731327");
            person.print();
            person.getPerson("YAFFA",23,"054324");
            person.print();
        }
    }
    class Person
    {
        string name;
        int age;
        string phoneNumber;
        public static Person makePerson()
        {
            Person person;
            person = new Person();
            return person;
        }
        public void getPerson(string name, int age, string phonenumber)
        {
            if (name != "YAFFA")
                this.name = name;
            if (age>=0)
                this.age =age;
            if(phonenumber.Length>=9)
            this.phoneNumber = phonenumber;
        }
        public void print()
        {
            Console.WriteLine(this.name+" is "+this.age+" years old, and his phone number is "+this.phoneNumber);
        }
    }
}
