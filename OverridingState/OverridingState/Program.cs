namespace OverridingState
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State[] states=new State[4];
            states[0] = new State("Asad","Dictatorship",185000);
            states[1] = new State("Masud", "Dictatorship", 1600000);
            states[2] = new SuperPower("Benjamin Netaniau", "Democracy", 220000, 100000, 55000.5);
            states[3] = new SuperPower("Trump", "Democrocy", 9800000, 1000000, 82000);
            for (int i = 0; i < states.Length; i++)
                states[i].print();
        }
    }
    class State
    {
        string leader;
        string typeOfRule;
        double territory;
        public virtual void print()
        {
            Console.WriteLine("The size of the state is {0} SKM and is leading by {1} in a {2} govermant",this.territory,this.leader,this.typeOfRule);
        }
        public bool setLeader(string leader)
        {
            this.leader = leader;
            return true;
        }
        public string getLeader()
        { 
            return this.leader; 
        }
        public bool setTypeOfRule(string typeOfRule)
        {
            this .typeOfRule = typeOfRule;
            return true;
        }
        public string getTypeOfRule()
        {
            return this .typeOfRule;
        }
        public bool setTerritory(double territory)
        {
            if(territory < 0)
                return false;
            this.territory = territory;
            return true;
        }
        public double getTerritory()
        {
            return this.territory;
        }
        public State(string leader,string typeOfRule,double territory)
        {
            this.setLeader(leader);
            this.setTypeOfRule(typeOfRule);
            this.setTerritory(territory);
        }
        public State() { }
    }
    class SuperPower:State
    {
        int amountOfSoldiers;
        double GDPvalue;
        public override void print()
        {
            base.print();
            Console.WriteLine("and it has {0} soldiers, and the state's GDP is {1} per capita",this.amountOfSoldiers,this.GDPvalue);
        }
        public bool setAmountOfSoldiers(int amountOfSoldiers)
        {
            if (amountOfSoldiers < 0)
                return false ;
            this.amountOfSoldiers = amountOfSoldiers ;
            return true;
        }
        public int getAmountOfSoldiers()
        {
            return this.amountOfSoldiers;
        }
        public bool setGDPvalue(double gDPvalue)
        {
            if(gDPvalue < 0)
                return false ;
            this.GDPvalue = gDPvalue ;
            return true;
        }
        public double getGDPvalue()
        {
            return this.GDPvalue;
        }
        public SuperPower(string leader, string typeOfRule,double territory,int amountofsoldiers, double gdpvalue):base(leader,typeOfRule,territory)
        {
            this.setAmountOfSoldiers(amountofsoldiers);
            this.setGDPvalue(gdpvalue);
        }
        public SuperPower() { }
    }
}
