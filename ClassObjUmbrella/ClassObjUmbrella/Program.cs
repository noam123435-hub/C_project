namespace ClassObjUmbrella
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Umbrella[] umbrellas = new Umbrella[3];
            umbrellas[0] = new Umbrella("MaxStock","black","321321321");
            umbrellas[1]=new Umbrella("MaxStock","white","432432456");
            umbrellas[2]=new Umbrella("MaxStock", "black", "321321321");
            for (int i = 0; i < 3; i++)
                Console.WriteLine(umbrellas[i]);
            Console.WriteLine((umbrellas[0].Equals(umbrellas[1]) ? "they are the same" :"they aren't the same"));
            Console.WriteLine((umbrellas[0].Equals(umbrellas[2]) ? "they are the same" : "they aren't the same"));
            Console.WriteLine((umbrellas[1].Equals(umbrellas[2]) ? "they are the same" : "they aren't the same"));
        }
        class Umbrella
        {
            string manufacturer;
            string color;
            string ownerID;
            public Umbrella(string manufacturer,string color, string ownerid)
            {
                this.manufacturer = manufacturer;
                this.color = color;
                this.ownerID = ownerid;
            }
            public override string ToString()
            {
                return "the " + this.color + " umbrella from " + this.manufacturer + " belongs to the person id " + this.ownerID;
            }
            public override bool Equals(object obj)
            {
                Umbrella other =(Umbrella)obj;
                return ((this.manufacturer == other.manufacturer) && (this.color == other.color)&&(this.ownerID==other.ownerID));
            }
        }
    }
}
