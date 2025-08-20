namespace ConstTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree t1, t2, t3;
            Tree.setNumbesOfTrees(1200);
            Console.WriteLine("the numer of trees in the world : {0}",Tree.getNumberOfTrees());
            t1=new Tree("Ekaliptus",4.5,2);
            t1.print();
            t2 = new Tree("Alon", 6.5, 5);
            t2.print();
            t3 = new Tree("Erez",15,60);
            t3.print();
            t1.setAge(5);
            t1.setHight(9.5);
            t1.print();
            Console.WriteLine("the number of trees in the world : {0}",Tree.getNumberOfTrees());
            
        }
    }
    class Tree
    {
        static int numberoftrees;
        public static int getNumberOfTrees()
        {
            return numberoftrees;
        }
        public static bool setNumbesOfTrees(int n)
        {
            if(n < 0)
                return false;
            Tree.numberoftrees = n;
            return true;
        }
        string type;
        public bool setType(string type)
        {
            this.type = type;
            return true;
        }
        public string getType()
        {
            return type;
        }
        double hight;
        public bool setHight(double hight)
        {
            if(hight<0)
                return false;
              this.hight = hight;
            return true;
        }
        public double getHight()
        {
            return hight;
        }
        int age;
        public bool setAge(int age)
        {
            if (age<0)
                return false;
            this.age = age;
            return true;
        }
        public int getAge()
        {
            return age;
        }
        public Tree(string type,double hight,int age)
        {
            this.setType(type);
            this.setHight(hight);
            this.setAge(age);
            Tree.numberoftrees++;
        }
        public void print()
        {
            Console.WriteLine("this {0} tree is {1} years old, it's hight is {2} meters",type,age,hight);
        }
    }
}
