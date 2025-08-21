namespace ObjectBirthday
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person user;
            user = new Person();
            Console.WriteLine("Hello. please enter your Name and press ENTER");
            user.name = Console.ReadLine();
            Console.WriteLine(user.name + " please enter your age and press ENTER");
            user.age = int.Parse(Console.ReadLine());
            birthday(user);
            printDetails(user);


        }
        static void birthday(Person person)
        {
            person.age++;
        }
        static void printDetails(Person person)
        {
            Console.WriteLine(person.name+"'s age is : "+person.age);
        }
    }
    class Person
    {
        public string name;
        public int age;
    }
}
