namespace HerSoldier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Soldier("030303","Turai").print();
            Console.WriteLine();
            new Soldier("2233532").print();
            Console.WriteLine();
            new Officer("030304503", "rav turai", 1800).printOfficer();
            Console.WriteLine();
            new Officer("43557563","Samal").printOfficer();
            Console.WriteLine();
            new BriComander("8498393","RAV ALUF",30000,"Ramatkal","Zeyini").printBriComander();
            Console.WriteLine();
            new BriComander("Ugda Komander", "Golan").printBriComander();
            Console.WriteLine();
            new BriComander("S.Ugda").printBriComander();
            
            
        }
    }
    class Soldier
    {
        string pNum;
        string rank;
        public void print()
        {
            Console.Write("The personal number of the {0} is {1}",this.rank,this.pNum);
        }
        public bool setPNum(string Pnum)
        {
            this.pNum = Pnum;
            return true;
        }
        public string getPNum()
        {
            return this.pNum;
        }
        public bool setRank(string rank)
        {
            this.rank = rank; 
            return true;
        }
        public string getRank()
        {
            return this.rank;
        }
        public Soldier(string pnum,string rank)
        {
            this.setPNum(pnum);
            this.setRank(rank);
        }
        public Soldier(string pnum) : this(pnum, "private") { }
      //  public Soldier() { }

    }
    class Officer:Soldier
    {
        double salary;
        public void printOfficer()
        {
            this.print();
            Console.Write(", and his salary is {0}", this.salary);
        }
        public bool setSalary(double salary)
        {
            if(salary < 0)
                return false;
            this.salary = salary;
            return true;
        }
        public double getSalary()
        {
            return this.salary;
        }
        public Officer(string pnum,string rank,double salary):base(pnum,rank)
        {
            this.setSalary(salary);
        }
        public Officer(string pnum,string rank) : this(pnum,rank ,5000) { }
       // public Officer() { }
    }
    class BriComander:Officer
    {
        string WantedRule;
        string supportingMG;
        public void printBriComander()
        {
            this.printOfficer();
            Console.Write(" and the MG {0} is supporting him to the rule of {1}",this.supportingMG,this.WantedRule);
        }
        public bool setWantedRule(string wantedrule)
        {
            this.WantedRule = wantedrule;
            return true;
        }
        public string getWantedRule()
        {
            return this.WantedRule;
        }
        public bool setSupportingMG(string supportingMG)
        {
            this.supportingMG = supportingMG;
            return true;
        }
        public string getSupportingMG()
        {
            return this.supportingMG;
        }
        public BriComander(string pnum, string rank, double salary,string wantedrule,string supportingmg):base(pnum,rank,salary)
        {
            this.setWantedRule(wantedrule);
            this.setSupportingMG(supportingmg);
        }
        public BriComander(string wantedrule,string supportingmg) : this("002","Colonel", 20000,wantedrule,supportingmg) { }
        public BriComander(string wantedrule) : this("050504","lColonel",15000,wantedrule,"nobody") { }
      //  public BriComander() { }
    }
}
