namespace CastTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Table[] tables=new Table[3];
            tables[0] = new Table(1.2,"white");
            tables[1] = new Desk(1.2, "black", 5.0, 4.1, 4);
            tables[2] = new CoffeTable(0.7,"brown",5);
            for(int i=0; i < tables.Length; i++)
            {

                if (tables[i] is Desk)
                    ((Desk)tables[i]).printDesk();
                else if (tables[i] is CoffeTable)
                    ((CoffeTable)tables[i]).printCoffeTable();
                else
                    tables[i].print();
                Console.WriteLine();
            }

        }
        class Table
        {
            double hight;
            string color;
            public void print()
            {
                Console.Write("The {0} table is {1} meter hight",this.color,this.hight);
            }
            public bool setHight(double hight)
            {
                if (hight < 0)
                    return false;
                this.hight = hight;
                return true;
            }
            public double getHight()
            {
                return hight;
            }
            public bool setColor(string color)
            {
                this.color = color;
                return true;
            }
            public string getColor()
            {
                return color;
            }
            public Table(double hight,string color)
            {
                this.setHight(hight);
                this.setColor(color);
            }
            public Table() { }
        }
        class Desk : Table
        {
            double lenght;
            double width;
            int numberOfDrawes;
            public void printDesk()
            {
                this.print();
                Console.Write(", {0} sm length, {1} meter widght, and have {2} drawes", this.lenght, this.width, this.numberOfDrawes);
            }
            public bool setLenght(double lenght)
            {
                if (lenght < 0)
                    return false;
                this.lenght = lenght;
                return true;
            }
            public double getLenght()
            {
                return lenght;
            }
            public bool setWidth(double width)
            {
                if (width < 0)
                    return false;
                this.width = width;
                return true;
            }
            public double getWidth()
            {
                return width;
            }
            public bool setNumberOfDrawes(int numberOfDrawes)
            {
                if (numberOfDrawes < 0)
                    return false;
                this.numberOfDrawes = numberOfDrawes;
                return true;
            }
            public int getNumberOfDrawes()
            {
                return numberOfDrawes;
            }
            public Desk(double hight,string color, double length,double width, int numberOfDrawes):base(hight,color)
            {
                this.setLenght(length);
                this.setWidth (width);
                this.setNumberOfDrawes(numberOfDrawes);
            }
            public Desk() { }
        }
        class CoffeTable : Table
        {
            double radius;
            public void printCoffeTable()
            {
                this.print();
                Console.Write(", and his radius is {0} cm", this.radius);
            }
            public bool setRadius(double radius)
            {
                if (radius < 0)
                    return false;
                this.radius = radius;
                return true;
            }
            public double getRadius()
            { 
                return radius;
            }
            public CoffeTable(double hight, string color,double radius):base(hight,color)
            {
                this.setRadius(radius);
            }
        }
    }
}
