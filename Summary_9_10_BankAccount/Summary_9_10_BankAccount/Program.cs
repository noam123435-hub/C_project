namespace Summary_9_10_BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //פתיחת חשבון בנק ראשון
            BankAccount ac1;
            BankAccount.setAccountAvailable(100);
            Console.WriteLine("Hello, please enter a name for your new Bank Account and press ENTER");
            ac1 = new BankAccount(Console.ReadLine());
            Console.WriteLine("{0}, please enter the amount of the amount you want to despsit and press ENTER",ac1.getName());
            ac1.setBalance(double.Parse(Console.ReadLine()));
            Console.WriteLine("{0}, please enter the amount of your approved misgeret and press ENTER", ac1.getName());
            ac1.setApprovedLoan(double.Parse(Console.ReadLine()));
            Console.WriteLine("{0}, please enter the amount of the amount of your used misgeret and press ENTER", ac1.getName());
            ac1.setUsedLoan(double.Parse(Console.ReadLine()));
            ac1.detailsprint();
            string input = "";
            while (input != "ENOUGH")
            {
                ac1.printActions();
                input = Console.ReadLine();
                switch (input)
                {
                    case "CHANGE_MAX_MISGERET":
                    Console.WriteLine("please enter the amount of the maximum misgeret and press ENTER");
                    BankAccount.setMaxLoan(double.Parse(Console.ReadLine()));
                        goto case "MAX_MISGERET";
                    case "MAX_MISGERET":
                        Console.WriteLine("The maximum misgeret is : {0}",(BankAccount.getMaxLoan()));
                        break;
                    case "ACCOUNT_TOTAL":
                        Console.WriteLine("there are {0} bank accounts", BankAccount.getAccountAvailable());
                        break;
                    case "DEPOSIT":
                        Console.WriteLine("please enter the amount of money you want to deposit and press ENTER");
                        ac1.deposit(double.Parse(Console.ReadLine()));
                        break;
                    case "WITHDRAW":
                        Console.WriteLine("please enter the amount of money you want to withdraw and press ENTER");
                        Console.WriteLine("You drawed {0} NIS from your account",ac1.withdraw(double.Parse(Console.ReadLine())));
                        break;
                    case "INCREASE_MISGERET":
                        Console.WriteLine("please enter the amount of the misgeret you want to ask and press ENTER");
                        Console.WriteLine("Yor new misgeret is {0} NIS",ac1.setApprovedLoan(double.Parse(Console.ReadLine())));
                        break;
                    case "REDUCE_LOAN":
                        Console.WriteLine("please enter the amount of money you want to pay for your loan and press ENTER");
                        Console.WriteLine("You tarnsfered {0} NIS from your account",ac1.reduceLoan(double.Parse(Console.ReadLine())));
                        break;
                    case "PRINT":
                        ac1.detailsprint();
                        break;
                    case "ENOUGH":
                        break;
                    default:
                        Console.WriteLine("the system can't use your input, please try again");
                        break;
                }
            }
            Console.WriteLine("Have a good day");
        }
    }
    class BankAccount
    {
        string name;
        public bool setName(string name)
        {
            this.name = name;
            return true;
        }
        public string getName()
        {
            return this.name;
        }
        double balance;
        public bool setBalance(double balance)
        {
            if (balance < 0)
                return false;
            this.balance = balance;
            return true;
        }
        public double getBalnce()
        {
            return this.balance;
        }
        double usedloan;
        public bool setUsedLoan(double loan)
        {
            if ((loan < 0) || (loan > this.approvedloan))
                return false;
            this.usedloan = loan;
            return true;
        }
        public double getUsedLoan()
        {
            return this.usedloan;
        }
        double approvedloan;
        public bool setApprovedLoan(double loan)
        {
            if ((loan < 0)||(loan>BankAccount.maxloan))
                return false;
            this.approvedloan = loan;
            return true;
        }
        public double getApprovedLoan()
        {
            return this.approvedloan;
        }
        static double maxloan=20000;
        public static bool setMaxLoan(double max)
        {
            if (max < 0)
                return false;
            BankAccount.maxloan = max;
            return true;
        }
        public static double getMaxLoan()
        {
            return BankAccount.maxloan;
        }
        static int accountavailable;
        public static bool setAccountAvailable(int account)
        {
            if (account < 0)
                return false;
            BankAccount.accountavailable = account;
            return true;
        }
        public static double getAccountAvailable()
        {
            return BankAccount.accountavailable;
        }
        public BankAccount(string name)
        {
            this.setName(name);
            BankAccount.accountavailable++;
        }
        public void detailsprint()
        {
            Console.WriteLine("in {0}'s account, the balance is {1} NIS, the approved misgeret is {2} Nis, of which {3} NIS is used", name, balance, approvedloan, usedloan);
        }
        public double withdraw(double amount)
        {
            double monetaccepted = (this.balance<amount)?this.balance:amount;
            this.setBalance(this.balance-monetaccepted);
            double stillwanttodraw = amount - monetaccepted;
            double possibleloan=this.approvedloan-this.usedloan;
            double continuedraw=(stillwanttodraw<possibleloan)?stillwanttodraw:possibleloan;
            this.usedloan += continuedraw;
            return monetaccepted + continuedraw;
        }
        public void deposit(double deposit)
        {
            this.setBalance(this.balance + deposit);
        }
        public double reduceLoan(double reduceLoan)
        {
            double maxtransfer=this.balance<this.usedloan?this.balance:this.usedloan;
            double actualtransfer=maxtransfer<reduceLoan?reduceLoan:maxtransfer;
            this.setBalance(this.balance - actualtransfer);
            this.setUsedLoan(this.usedloan - actualtransfer);
            return actualtransfer;
        }
        public bool increaseMisgeret(double amount)
        {
          return this.setApprovedLoan(this.approvedloan + amount); 
        }
        public void printActions()
        {
            Console.WriteLine();
            Console.WriteLine("what do you want to do now?");
            Console.WriteLine("To change the maximum Misgeret(for supervisor only) enter 'CHANGE_MAX_MISGERET'press ENTER");
            Console.WriteLine("To check the maximum Misgeret enter 'MAX_MISGERET' and press ENTER");
            Console.WriteLine("To check the balance of your account enter 'ACCOUNT_TOTAL' and press ENTER");
            Console.WriteLine("To deposit money to your account enter 'DEPOSIT' and press ENTER");
            Console.WriteLine("To withdraw monet from your account enter 'WITHDRAW' and press ENTER");
            Console.WriteLine("To increase your approved misgeret enter 'INCREASE_MISGERET' and press ENTER");
            Console.WriteLine("To reduce the amount of the loan from your balance enter 'REDUCE_LOAN' and press ENTER");
            Console.WriteLine("To print the details of your account enter 'PRINT' and press ENTER");
            Console.WriteLine("To exit enter 'ENOUGH' and press ENTER");
        }
    }
}
