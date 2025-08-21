namespace ObjectTv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tv noa, adi, inbar;
            noa=inbar=adi= new Tv();
            noa.offSwitch();
            noa.setChanel("Logi");
            noa.putVolume(5);
            inbar.print();
            inbar.setChanel("Hop");
            inbar.putVolume(3);
            noa.print();
            adi.offSwitch();
            adi.print();
        }
    }
    class Tv
    {
        string chanel;
        int volume;
        bool isOn;
       public void init(string chanel,int volume,bool isOn)
        {
        this.chanel = chanel;
        this.volume = volume;
        this.isOn = isOn;
        }
        public void print()
        {
            if (this.isOn)
                Console.WriteLine("the tv is on a " + this.chanel + " chanel, at " + this.volume + " volume");
            else
                Console.WriteLine("the tv is off");
        }
        public void offSwitch()
        {
            this.isOn=!this.isOn;
        }
        public void putVolume(int volume)
        {
            this.volume += volume;
            if (this.volume < 0)
                this.volume = 0;
        }
        public void setChanel(string chanel)
        {
            this.chanel = chanel;
        }
    }
}
