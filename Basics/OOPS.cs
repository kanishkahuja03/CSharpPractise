using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    interface IAccount
    {
        public void Deposit(double amount);
        public void Withdraw(double amount);
        public void DisplayDetails();
    }

    abstract class Account : IAccount
    {
        protected int AccountNumber;
        protected string HolderName;
        protected double Balance;

        public Account(int accNo, string name, double balance)
        {
            AccountNumber = accNo;
            HolderName = name;
            Balance = balance;
        }

        public abstract void Withdraw(double amount);

        public virtual void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("Amount Deposited Successfully.");
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Account No: {AccountNumber}");
            Console.WriteLine($"Holder Name: {HolderName}");
            Console.WriteLine($"Balance: {Balance}");
        }

        public int GetAccountNumber()
        {
            return AccountNumber;
        }
    }

    class SavingsAccount : Account
    {
        public SavingsAccount(int accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Withdrawal Successful.");
            }
            else
            {
                Console.WriteLine("Insufficient Balance.");
            }
        }
    }

    class CurrentAccount : Account
    {
        private double OverdraftLimit = 5000;

        public CurrentAccount(int accNo, string name, double balance)
            : base(accNo, name, balance) { }

        public override void Withdraw(double amount)
        {
            if (amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine("Withdrawal Successful (Overdraft Allowed).");
            }
            else
            {
                Console.WriteLine("Overdraft Limit Exceeded.");
            }
        }

    }

    class Program
    {
        static List<Account> accounts = new List<Account>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("BANK MANAGEMENT SYSTEM");
                Console.WriteLine("1. Create Savings Account");
                Console.WriteLine("2. Create Current Account");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Withdraw");
                Console.WriteLine("5. Display Account Details");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateAccount("Savings");
                        break;
                    case 2:
                        CreateAccount("Current");
                        break;
                    case 3:
                        Transaction("Deposit");
                        break;
                    case 4:
                        Transaction("Withdraw");
                        break;
                    case 5:
                        DisplayAccount();
                        break;
                    case 6:
                        Console.WriteLine("Thank You!");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 6);
        }

        static void CreateAccount(string type)
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Initial Balance: ");
            double balance = double.Parse(Console.ReadLine());

            if (type == "Savings")
                accounts.Add(new SavingsAccount(accNo, name, balance));
            else
                accounts.Add(new CurrentAccount(accNo, name, balance));

            Console.WriteLine($"{type} Account Created Successfully.");
        }

        static Account FindAccount(int accNo)
        {
            return accounts.Find(a => a.GetAccountNumber() == accNo);
        }

        static void Transaction(string type)
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());
            Account acc = FindAccount(accNo);

            if (acc != null)
            {
                Console.Write("Enter Amount: ");
                double amount = double.Parse(Console.ReadLine());

                if (type == "Deposit")
                    acc.Deposit(amount);
                else
                    acc.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account Not Found.");
            }
        }

        static void DisplayAccount()
        {
            Console.Write("Enter Account Number: ");
            int accNo = int.Parse(Console.ReadLine());
            Account acc = FindAccount(accNo);

            if (acc != null)
                acc.DisplayDetails();
            else
                Console.WriteLine("Account Not Found.");
        }
    }
}

