namespace HerAnimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal lion = new Animal();
            lion.setName("Lion");
            lion.setIsMale(true);
            lion.setFavoriteFood("Zebra's meat");
            lion.setVitality(25);
            lion.print();
            Snail snail = new Snail();
            snail.setName("snail");
            snail.setIsMale(true);
            snail.setVitality(5);
            snail.setDevelopstage(1);
            snail.setFavoriteFood("leaf");
            snail.printSnail();
            snail.vaccine();
            snail.upgradeDevelopstage();
            snail.upgradeDevelopstage();
            snail.printSnail();



        }
        class Animal
        {
            string name;
            bool isMale;
            protected double vitality;
            string favoriteFood;
            public bool setName(string name)
            {
                this.name = name;
                return true;
            }
            public string getName()
            {
                return this.name;
            }
            public bool setIsMale(bool isMale)
            {
                this.isMale = isMale;
                return true;
            }
            public bool getIsMale()
            {
                return this.isMale;
            }
            public bool setVitality(double vitality)
            {
                if(vitality < 0)
                    return false;
                this.vitality = vitality;
                return true;
            }
            public double getVitality()
            {
                return this.vitality;
            }
            public bool setFavoriteFood(string favoriteFood)
            {
                this.favoriteFood = favoriteFood;
                return true;
            }
            public string getFavoriteFood()
            {
                return this.favoriteFood;
            }
            public void print()
            {
                Console.WriteLine("The {0} {1} has a life expentancy of {2} years and his favorite food is {3}",isMale ? "male" : "female", name,vitality,favoriteFood);
            }
        }
        class Snail:Animal
        {
            int developstage;
            public bool setDevelopstage(int developstage)
            {
                if ((developstage < 1)||(developstage>4))
                    return false;
                this.developstage = developstage;
                if (developstage<3)
                    this.setIsMale(true);
                else
                    this.setIsMale(false);
                return true;
            }
            public int getDevelopstage()
            {
                return this.developstage;
            }
            public void printSnail()
            {
                print();
                Console.WriteLine("and at develpoment stage {0}",developstage);
            }
            public void upgradeDevelopstage()
            {
                if (developstage<4)
                this.setDevelopstage(++developstage);
            }
            public bool vaccine()
            {
                this.vitality*=2;
                return true;
            }
        }
    }
}
