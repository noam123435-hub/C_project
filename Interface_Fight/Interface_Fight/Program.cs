namespace Interface_Fight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            object[] fighters = new object[4];
            fighters[0] = new Person("Nisim","673867");
            fighters[1] = new Turtle("Sea Turtle", 250);
            fighters[2] = new Jedi("Loke Skywaker", "96489674", "blue");
            fighters[3] = new NinjaTurtle("Michelanjelo","Mutatin Turtle",20,"swords");
            for (int i = 0; i < fighters.Length; i++)
            {
                Console.WriteLine(fighters[i]);
                if (fighters[i] is Ifight) 
                {
                    ((Ifight)fighters[i]).fight();
                    Console.WriteLine("his wepon is "+((Ifight)fighters[i]).getArmsInfo());
                }
                Console.WriteLine();
            }
        }
    }
    interface Ifight
    {
        void fight();
        string getArmsInfo();
    }
    class Person
    {
        string name;
        string id;
        public Person(string name,string id)
        {
            this.name = name;
            this.id = id;
        }
        public override string ToString()
        {
            return this.name + " has id #" + this.id;
        }
    }
    class Turtle
    {
        string type;
        int age;
        public Turtle(string type, int age)
        {
            this.type = type;
            this.age = age;
        }
        public override string ToString()
        {
            return "the " + this.type + " is " + this.age + " years old";
        }
    }
    class Jedi : Person,Ifight
    {
        string swordColor;
        public Jedi(string name,string id,string swordColor):base(name,id)
        {
            this.swordColor = swordColor;
        }
        public override string ToString()
        {
            return base.ToString() + " is a Jedi and has a " + this.swordColor + " light sword";
        }
        public void fight()
        {
            Console.WriteLine("the Jedi is fighting with his {0} light sword",this.swordColor);
        }
        public string getArmsInfo()
        {
            return this.swordColor + " light sword";
        }
    }
    class NinjaTurtle : Turtle, Ifight
    {
        string name;
        string weapon;
        public NinjaTurtle(string name,string type,int age,string weapon) : base(type,age)
        {
            this.name = name;
            this.weapon = weapon;
        }

        public void fight()
        {
            Console.WriteLine(this + " at the bed guys");
        }

        public string getArmsInfo()
        {
            return this.weapon;
        }

        public override string ToString()
        {
            return this.name + " using his " + this.weapon + " to fight";
        }
    }
}
