namespace Hersmartphone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CellPhone cellphone=new CellPhone();
            SmartPhone smartphone=new SmartPhone();
            cellphone.setManifacture("Nokia");
            cellphone.setModel("910");
            cellphone.setPrice(500);
            smartphone.setManifacture("Sumsung");
            smartphone.setModel("Galaxy 8");
            smartphone.setPrice(2000);
            smartphone.setOperatingSystem("Android");
            smartphone.setVersion(12.3);
            cellphone.print();
            smartphone.printSmartPhone();
            smartphone.Update("Android",-1.0);
            smartphone.printSmartPhone();
            smartphone.Update("ios", 2.3);
            smartphone.printSmartPhone();
            Console.WriteLine();

            CellPhone[] newphones = new CellPhone[5];
            newphones[0]=new CellPhone();
            newphones[1]=new CellPhone();
            newphones[2]=new CellPhone();
            SmartPhone sm1=new SmartPhone();
            SmartPhone sm2=new SmartPhone();
            newphones[0].setManifacture("Nokia");
            newphones[0].setModel("820");
            newphones[0].setPrice(500);
            newphones[1].setManifacture("Nokia");
            newphones[1].setModel("920");
            newphones[1].setPrice(600);
            newphones[2].setManifacture("Nokia");
            newphones[2].setModel("750");
            newphones[2].setPrice(550);
            sm1.setManifacture("Sumsung");
            sm1.setModel("Galaxy 12s");
            sm1.setPrice(1200);
            sm1.setOperatingSystem("Android");
            sm1.setVersion(12.7);
            sm2.setManifacture("iPhone");
            sm2.setModel("12s");
            sm2.setPrice(4000);
            sm1.setOperatingSystem("iOS");
            sm1.setVersion(14);
            newphones[3] = sm1;
            newphones[4] = sm2;
            for (int i = 0; i < newphones.Length; i++)
                newphones[i].print();
        }
    }
    class SmartPhone:CellPhone
    {
        string operatingSystem;
        double version;
        public void printSmartPhone()
        {
            print();
            Console.WriteLine("and the operating system is {0} {1}",this.operatingSystem,this.version);
        }
        public bool setOperatingSystem(string operatingSystem)
        {
            this.operatingSystem = operatingSystem;
            return true;
        }
        public string getOperatingSystem()
        {
            return this.operatingSystem;
        }
        public bool setVersion(double version)
        {
            if(version<=0)
                return false;
            this.version = version;
            return true;
        }
        public double getVersion()
        {
            return this.version;
        }
        public bool Update(string operatingsystem,double version)
        {
            string oldOs=this.operatingSystem;
            bool success=this.setOperatingSystem(operatingsystem);
            if(!success)
                return false;
            success=this.setVersion(version);
            if (!success)
            {
                this.setOperatingSystem(oldOs);
                return false;
            }
            return true;
        }

    }
    class CellPhone
    {
        string manifacture;
        string model;
        protected double price;
        public void print()
        {
            Console.WriteLine("The price of {0} {1} is {2}",this.manifacture,this.model,this.price);
        }
        public bool setManifacture(string manifacture)
        {
            this.manifacture = manifacture;
            return true;
        }
        public string getManifacture()
        {
            return this.manifacture;
        }
        public bool setModel(string model)
        {
            this.model = model;
            return true;
        }
        public string getModel()
        {
            return this.model;
        }
        public bool setPrice(double price)
        {
            if(price < 0)
                return false;
            this.price = price;
            return true;
        }
        public double getPrice()
        {
            return this.price;
        }
    }
}
