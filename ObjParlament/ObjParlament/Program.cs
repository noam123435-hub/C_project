namespace ObjParlament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //person qa code
            Person person1=new Person("Bibi","2323434");
            Console.WriteLine(person1);
            Person person2 = new Person("Binyamin","2323434");
            Person person3 = new Person("Bibi", "382929292");
            Console.WriteLine("Person1 and Person2 "+(person1.Equals(person2)?"are":"aren't")+" the same");
            Console.WriteLine("Person3 and Person2 " + (person3.Equals(person2) ? "are" : "aren't") + " the same");

            // membersofparlament qa code
            Parliament kneset=new Parliament("Israel",120);
            kneset.addNewMember(person1,"Likud");
            kneset.addNewMember(person2, "Likud");
            kneset.addNewMember(person3, "Kachol Lavan");
            for(int i=0;i<kneset.currentMembers;i++)
                Console.WriteLine(kneset.members[i]);
            if ((kneset.members[0].Equals(kneset.members[1])))
                Console.WriteLine("Person1 and Person2 are the same");
            else
                Console.WriteLine("Person1 and Person2 aren't the same");
            if ((kneset.members[2].Equals(kneset.members[1])))
                Console.WriteLine("Person3 and Person2 are the same");
            else
                Console.WriteLine("Person3 and Person2 aren't the same");

            //parliament qa code
            Console.WriteLine(kneset.ToString());
            Person person4, person5,person6;
            person4 = new Person("yoni", "3453254");
            person5 = new Person("Shimi", "37383838");
            person6 = new Person("gom","8448493939");
            Parliament Newkneset = new Parliament("Israel", 120);
            Newkneset.addNewMember(person1, "Likud");
            Newkneset.addNewMember(person2, "Likud");
            Newkneset.addNewMember(person3, "Kachol Lavan");
            Console.WriteLine(Newkneset.ToString());
            Parliament parliament = new Parliament("Israel", 80);
            parliament.addNewMember(person4, "Likud");
            parliament.addNewMember(person5, "Likud");
            parliament.addNewMember(person6, "Kachol Lavan");
            Console.WriteLine(parliament.ToString());
            if (kneset.Equals(Newkneset))
                Console.WriteLine("Kneset and newknekset are the same");
            else
                Console.WriteLine("Kneset and newknekset aren't the same");
            if(kneset.Equals(parliament))
                Console.WriteLine("Kneset and parliament are the same");
            else
                Console.WriteLine("Kneset and parliament aren't the same");


        }
    }
    class Person
    {
        string name;
        string id;
        public bool setName(string name)
        {
            this.name = name;
            return true;
        }
        public string getName()
        { 
            return this.name;
        }
        public bool setID(string id)
        {
            this.id = id;
            return true;
        }
        public string getID()
        {
            return this.id;
        }
        public Person(string name,string id)
        {
            this.setName(name);
            this.setID(id);
        }
        public override string ToString()
        {
            return this.name + "'s id is #" + this.id;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Person))
                return false;
            Person other = (Person)obj;
            return this.id == other.id;
        }
    }
    class MemberOfParliament:Person
    {
        string partyName;
        public bool setPartyName(string partyname)
        {
            this.partyName = partyname;
            return true;
        }
        public string getPartyName()
        {
            return this.partyName;
        }
        public MemberOfParliament(string name,string id,string partyname):base(name,id)
        {
            this.setPartyName(partyname);
        }
        public override string ToString()
        {
            return base.ToString() + " and he is a member of parliament form " + this.partyName + " party";
        }
        public override bool Equals(object obj)
        {
            if(!(obj is MemberOfParliament))
                return false;
            MemberOfParliament other= (MemberOfParliament)obj;
            return base.Equals(other)&&(this.partyName==other.partyName);
        }
    }
    class Parliament
    {
        string contry;
        public int numberOfMembers;
        public MemberOfParliament[] members;
        public int currentMembers = 0;
        
        public Parliament(string contry,int numberofmembers)
        {
            this.contry = contry;
            this.numberOfMembers = numberofmembers;
            members= new MemberOfParliament[numberOfMembers];
        }
        public bool addNewMember(Person person,string partyname)
        {
            if (!(this.currentMembers < numberOfMembers))
                return false;
            members[currentMembers] = new MemberOfParliament(person.getName(), person.getID(), partyname);
            person=members[currentMembers];
            currentMembers++;
            return true;
        }
        public override string ToString()
        {
            string result="the " + this.contry + "'s Parliament have the following " + this.currentMembers + " member out of " + this.numberOfMembers + " : \n";
            for (int i = 0; i < this.members.Length; i++)
                if(this.members[i] != null) 
                result += members[i] + "\n";
            return result;
        }
        public override bool Equals(object obj)
        {
           if (!(obj is Parliament))
                return false;
           Parliament other = (Parliament)obj;
            if (!((this.contry == other.contry)&&(this.currentMembers==other.currentMembers)&&(this.numberOfMembers==other.numberOfMembers)))
                return false;
            for (int i = 0; i < this.currentMembers; i++)
                if (!(this.members[i].Equals(other.members[i])))
                    return false;
            return true;
        }
    }
}
