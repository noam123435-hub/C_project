namespace ObjectFamily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person Noam;
            Noam = new Person();
            Noam.Name = "Noam";
            Noam.Father=new Person();
            Noam.Father.Name = "Meir Z'L";
            Noam.Mother=new Person();
            Noam.Mother.Name = "Rachel";
            Noam.Father.Father=new Person();
            Noam.Father.Father.Name = "Eliezer Z'L";
        }
    }
    class Person
    {
        public string Name;
        public Person Father;
        public Person Mother;
    }
}
