namespace ObjectComputer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer Asus;
            Asus= new Computer();
            Asus.model = "Asus 1";
            Asus.memory = 8;
            Asus.powerSupply=new PowerSupply();
            Asus.powerSupply.model = "aa";
            Asus.powerSupply.power = 40;
            Asus.processor = new Processor();
            Asus.processor.model = "bb";
            Asus.processor.speed = 120;
            printComputer(Asus);
        }
        static void printComputer(Computer computer)
        {
            Console.WriteLine("the "+computer.model+" computer has "+computer.memory+" RAM");
            Console.Write(computer.model+" has the "+computer.processor.model+" processor. ");
            printProcessor(computer.processor);
            Console.Write(computer.model + " has the " + computer.powerSupply.model + " power suplly. ");
            printPowerSupply(computer.powerSupply);
        }
        static void printPowerSupply(PowerSupply powerSupply)
        {
            Console.WriteLine("the " + powerSupply.model + " Power Suplly operates at " + powerSupply.power + " wolts");
        }
        static void printProcessor(Processor processor)
        {
            Console.WriteLine("the "+processor.model+" processor runs at "+processor.speed+" MH");
        }

    }
    class Computer
    {
        public string model;
        public int memory;
        public PowerSupply powerSupply;
        public Processor processor;
    }
    class PowerSupply
    {
        public string model;
        public double power;
    }
    class Processor
    {
        public string model;
        public double speed;
    }
}
