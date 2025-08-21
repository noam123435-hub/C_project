namespace HerPolotic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Politician Golan=new Politician();
            Golan.name = "Yair Golan";
            Golan.age = 60;
            Golan.party = "Meretch";
            Console.WriteLine("{0} is {1} years old and {2} politician",Golan.name,Golan.age,Golan.party);
            MemberOfKneset Sofer = new MemberOfKneset();
            Sofer.name = "Ofir Sofer";
            Sofer.age = 50;
            Sofer.party = "Tzionut Datit";
            Sofer.isGoverment = true;
            Console.Write("{0} is {1} years old and {2} politician and ",Sofer.name,Sofer.age,Sofer.party);
            Console.WriteLine((((Sofer.isGoverment) ? "is" : "isn't") + " at the govermant"));
            PrimeMinister Netaniu=new PrimeMinister();
            Netaniu.name = "Binyamin Netaniu";
            Netaniu.age = 75;
            Netaniu.party = "Likud";
            Netaniu.isGoverment= true;
            Netaniu.numberOfVeadot = 0;
            Console.Write("{0} is {1} years old and {2} politician and ", Netaniu.name, Netaniu.age, Netaniu.party);
            Console.Write((((Netaniu.isGoverment) ? "is" : "isn't") + " at the govermant, and at "+Netaniu.numberOfVeadot+ " Veadot"));
        }
    }
    class Politician
    {
        public string name;
        public int age;
        public string party;
    }
    class MemberOfKneset : Politician
    {
        public bool isGoverment;
    }
    class PrimeMinister:MemberOfKneset
    {
        public int numberOfVeadot;
    }
}
