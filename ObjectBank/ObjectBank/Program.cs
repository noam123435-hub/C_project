namespace ObjectBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount FirstAccount, SecondAccount, UnitedAccount;
            FirstAccount = BankAccount.makeAccount(1000,500,"Noam Lemel");
            BankAccount.print(FirstAccount);
            SecondAccount = BankAccount.makeAccount(-500, 200, "Chen Lemel");
            BankAccount.print(SecondAccount);
            UnitedAccount=BankAccount.margeAccount(FirstAccount, SecondAccount);
            BankAccount.print(UnitedAccount);
        }
    }
    class BankAccount
    {
        public double balance;
        public double frame;
        public string name;
        public static void print(BankAccount bank)
        {
            Console.WriteLine("In the account in the name of "+bank.name+" the financial balance is "+bank.balance+" NIS, and the amount of the approved framework is "+bank.frame+" NIS");
            Console.WriteLine();
        }
        public static BankAccount makeAccount(double balance, double frame,string name)
        {
            BankAccount bank;
            bank = new BankAccount();
            bank.balance = balance;
            bank.frame = frame;
            bank.name = name;
            return bank;
        }
        public static BankAccount margeAccount(BankAccount first, BankAccount second)
        {
            BankAccount united;
            united = new BankAccount();
            united.balance = first.balance+second.balance;
            united.name = first.name+" & "+second.name;
            united.frame=first.frame > second.frame?first.frame:second.frame;
            return united;
        }
    }
}
