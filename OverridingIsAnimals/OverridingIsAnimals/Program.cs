namespace OverridingIsAnimals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[5];
            animals[0] = new Animal("Kofico","Monkey");
            animals[1] = new Cow("Edna","Cow");
            animals[2] = new Dog("Rexi","Dog");
            animals[3] = new Cat("Mitchi","Cat");
            animals[4] = new Leopard("Bagir","Leopard");
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine();
                animals[i].print();
                animals[i].move();
                animals[i].eat();
                if (animals[i] is Cow)
                    ((Cow)animals[i]).giveMilk();
                if (animals[i] is Dog)
                    ((Dog)animals[i]).saveTheHouse();
                if (animals[i] is Cat)
                    ((Cat)animals[i]).hunt();
        }
    }
    class Animal
    {
        string name;
        string type;
        public bool setName(string name)
        {
            this.name = name;
            return true;
        }
        public string getName()
        {
            return name;
        }
        public bool setType(string type)
        {
            this.type = type;
            return true;
        }
        public string getType()
        {
            return this.type;
        }
        public Animal(string name, string type)
        {
            this.setName (name);
            this.setType(type);
        }
        public Animal() { }
        public virtual void move()
        {
            Console.WriteLine("{0} the {1} move 5 moves",this.name,this.type);
        }
        public virtual void eat()
        {
            Console.WriteLine("{0} the {1} eats it's food",this.name,this.type);
        }
        public virtual void print()
        {
            Console.WriteLine("{0} is a {1}",this.name, this.type);
        }

    }
    class Cow:Animal
    {
        public Cow(string name,string type) : base(name, type) { }
        public Cow() { }
        public void giveMilk()
        {
            Console.WriteLine("{0} the cow give 4 Liters of milk", this.getName());
        }
        public override void move()
        {
            Console.WriteLine("{0} the cow moves at the barn",this.getName());
        }
        public override void eat()
        {
            Console.WriteLine("{0} the cow eats hay", this.getName());
        }
    }
    class Dog:Animal
    {
        public Dog(string name,string type) : base(name, type) { }
        public Dog() { }
        public void saveTheHouse()
        {
            Console.WriteLine("{0} is saving the house", this.getName());
        }
        public override void move()
        {
            Console.WriteLine("{0} is moves at the yard",this.getName());
        }
        public override void eat()
        {
            Console.WriteLine("{0} is eats bones for dinner",this.getName());
        }

    }
    class Cat:Animal
    {
        public Cat(string name,string type):base(name,type){}
        public Cat() { }
        public virtual void hunt()
        {
            Console.WriteLine("{0} is hunting mouse at the house", this.getName());
        }
        public override void move()
        {
            Console.WriteLine("{0} is move at the house", this.getName());
        }
        public override void eat()
        {
            Console.WriteLine("{0} is eats Lazania", this.getName());
        }

    }
        class Leopard : Cat
        {
            public Leopard(string name, string type) : base(name, type) { }
            public Leopard() { }
            public override void hunt()
            {
                Console.WriteLine("{0} is hunting monkey at the Jungel", this.getName());
            }
            public override void eat()
            {
                Console.WriteLine("{0} is eating Zebra at the Jungele",this.getName());
            }
        }
    }
}
