using System.Reflection.Metadata.Ecma335;

namespace Interface_Ifly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ifly[] afim = new Ifly[3];
            afim[0] = new Bird("white","Nakar",100);
            afim[1] = new Airplane("Boing", 400);
            afim[2] = new Suicide("Smulik",67);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(afim[i]);
                afim[i].fly();
                Console.WriteLine(afim[i]+" is flying on " + afim[i].getEnergySource()+" and has max fly distance of "+afim[i].getMaxDistance()+" km");
                Console.WriteLine();
            }
        }
    }
    interface Ifly
    {
        double getMaxDistance();
        void fly();
        string getEnergySource();

    }
    class Bird : Ifly
    {
        string color;
        string type;
        double maxflyingdistance;
        public Bird(string color, string type,double maxflyingdistance)
        {
            this.color = color;
            this.type = type;
            this.maxflyingdistance= maxflyingdistance;
        }
        public void fly()
        {
           Console.WriteLine("the bird is flying by her wings");
        }
        public string getEnergySource()
        {
            return  "garinim and tolaim";   
        }

        public double getMaxDistance()
        {
            return this.maxflyingdistance;
        }
        public override string ToString()
        {
            return "the "+this.type+" bird is "+this.color;
        }
    }
    class Airplane : Ifly
    {
        string model;
        double weight;
        public Airplane(string model,double weight)
        {
            this.model = model;
            this.weight = weight;
        }
        public override string ToString()
        {
            return "the " + this.model + " airplane is weight " + this.weight + " Ton";
        }
        public void fly()
        {
            Console.WriteLine ("the airplane is flying high in the sky");
        }

        public string getEnergySource()
        {
            return  "fuel";
        }

        public double getMaxDistance()
        {
            return 1000;
        }
    }
    class Suicide : Ifly
    {
        string name;
        int age;
        public Suicide(string name,int age)
        {
            this.name = name;
            this.age = age;
        }
        public override string ToString()
        {
            return this.name + " committed suicide at the age of" + this.age;
        }
        public void fly()
        {
            Console.WriteLine("{0} is jumping off the roof",this.name);
        }

        public string getEnergySource()
        {
            return "Potential energy";
        }

        public double getMaxDistance()
        {
            return 800;
        }
    }
}
