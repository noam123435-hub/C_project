namespace Intrface_Child
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // Child qa code
            Child yeled=new Child("Tomi",10);
            Console.WriteLine(yeled);

            // TidyChild qa code
            ITidy yeledNaki = new TidyChild("Yosi", 13);
            Console.WriteLine(yeledNaki);
            yeledNaki.helpTidyTheLivingRoom();
            yeledNaki.helpTidyTheRoom();
            yeledNaki.washYourSelf();
            String name = new String("Tal");

        }
        interface ITidy
        {
            void helpTidyTheLivingRoom();
            void helpTidyTheRoom();
            void washYourSelf();
        }
        class Child
        {
            protected string name;
            int age;
            public Child(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public override string ToString()
            {
                return this.name + " is " + this.age + " years old";
            }
        }
        class TidyChild : Child, ITidy
        {
            public TidyChild(string name, int age) : base(name, age) { }
            public void helpTidyTheLivingRoom()
            {
                Console.WriteLine(this.name + " is picking up all the mess and pushes under the carpet"); 
            }
            public void helpTidyTheRoom()
            {
               Console.WriteLine(this.name+" is tidy the bed and the desk");
            }
            public void washYourSelf()
            {
                Console.WriteLine(this.name+" is washing his head without soap");
            }
        }
    }
}
