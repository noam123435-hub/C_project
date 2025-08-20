namespace consCity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            City first = new City("Pardes hana", 200000, 100);
            first.print();
            first.addtaxes(20);
            first.print();
            City second = new City("Karkur", 150000, 150);
            second.print();
            City together = new City();
            together=City.together(first, second);
            together.print(); 
        }
    }
    class City
    {
        string name;
        int population;
        double tax;        
        public City(string name, int population,double tax)
        {
            this.name = name;
            this.population = population;
            this.tax = tax;
        }
        public City(string name, int population)
        {
            this.name = name;
            this.population = population;
        }
        public City(string name)
        {
            this.name = name;
        }
        public City() { }
        public void print()
        {
            Console.WriteLine("The City of " + this.name + " has " + this.population + " residents and collect municipal taxes of " + this.tax + " nis per square meter");
        }
        public void addtaxes(int tax)
        {
            this.tax += tax;
        }
        public static City together(City first, City second)
        {
            City together = new City(first.name+"-"+second.name,first.population+second.population,(first.tax>second.tax)?first.tax:second.tax);
            return together;
        }
    }
}
