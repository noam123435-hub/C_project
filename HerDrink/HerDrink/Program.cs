using System.Runtime.InteropServices;

namespace HerDrink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Drink("Coca-Cola",100,true).print();
            new Drink("Fuse-Tea", 90).print();
            new Drink("Water").print();
          
        }
        class Drink
        {
            string name;
            double caloriesPer100Gram;
            bool isGazoz;
            public void print()
            {
                Console.WriteLine("{0} {1} drink and have {2} calories per 100 gram",this.name,this.isGazoz?"is mugaz":"is soft",this.caloriesPer100Gram);
            }
            public bool setName(string name)
            {
                this.name = name;
                return true;
            }
            public string getName()
            {
                return this.name;
            }
            public bool setCaloriesPer100Gram(double caloriesPer100Gram)
            {
                if (caloriesPer100Gram < 0)
                    return false;
                this.caloriesPer100Gram = caloriesPer100Gram;
                return true;
            }
            public double getCaloriesPer100Gram()
            {
                return this.caloriesPer100Gram;
            }
            public bool setIsGazoz(bool isGazoz)
            {
                this.isGazoz = isGazoz;
                return true;
            }
            public bool getIsGazoz()
            {
                return this.isGazoz;
            }
            public Drink(string name, double caloriesPer100Gram,bool isGazoz)
            {
                this.setName(name);
                this.setCaloriesPer100Gram(caloriesPer100Gram);
                this.setIsGazoz(isGazoz);
            }
            public Drink(string name,double caloriesPer100Gram) : this(name, caloriesPer100Gram, false) { }
            public Drink(string name) : this(name, 0, false) { }
            public Drink() { }

        }
    }
}
