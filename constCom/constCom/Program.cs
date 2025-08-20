namespace constCom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer Asus=new Computer("ASUS","A54",26);
            Asus.addscreen(new Screen(15,720));
            Asus.addscreen(new Screen(14,720));
            Asus.addDisc(new Disc(8, 45, 'C'));
            Asus.addDisc(new Disc(6, 40, 'D'));
            Asus.addDisc(new Disc(4, 52, 'F'));
            Asus.print();

        }
    }
    class Disc
    {
        int Ram;
        int K;
        char vizual;
        public Disc(int Ram, int K, char vizual)
        {
            this.Ram = Ram;
            this.K = K;
            this.vizual = vizual;
        }
        public void print()
        {
            Console.WriteLine("the disc {0} is run at {1} RAM and have {2} k",vizual,Ram,K);
        }
    }
    class Screen
    {
        double intch;
        int resolution;
        public Screen(double intch, int resolution)
        {
            this.intch = intch;
            this.resolution = resolution;
        }
        public void print()
        {
            Console.WriteLine("the screen is {0} intch with a resolution of {1} Pixel", this.intch,this.resolution);
        }
    }
    class Computer
    {
        string company;
        string model;
        int memory;
        Disc[] discs;
        int discsNumber;
        Screen[] screens;
        int screensNumber;
        public Computer(string company,string model,int memory)
        {
            this.company = company;
            this.model = model;
            this.memory = memory;
            this.discs=new Disc[5];
            this.screens = new Screen[4];
        }
        public bool addscreen(Screen screen)
        {
            if (screensNumber== screens.Length)
                return false;
            screens[screensNumber] = screen;
            screensNumber++;
            return true;
        }
        public bool addDisc(Disc disc)
        {
            if (discsNumber== discs.Length)
                return false;
            discs[discsNumber] = disc;
            discsNumber++;
            return true;
        }
        public void print()
        {
            Console.WriteLine("the {0} {1} have {2} Ram",this.company,this.model,this.memory);
            Console.WriteLine("the folowing {0} screens are connected to the Computer:",this.screensNumber);
            for( int i = 0;i < this.screensNumber;i++ )
                this.screens[i].print();
            Console.WriteLine("the folowing {0} discs are connected to the computer",this.discsNumber);
            for (int i = 0; i < this.discsNumber;i++ )
                this.discs[i].print();
        }
    }
}
