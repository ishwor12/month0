using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace day1
{
    class BankAccount
    {
        private string _accountNumber;
        private double _balance;
        private string _ownerName;

        public BankAccount(string accountNumber, string ownerName, double initialBalance = 0)
        {
            _accountNumber = accountNumber;
            _ownerName = ownerName;
            _balance = initialBalance;

        }
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            _balance += amount;
            Console.WriteLine("Sucessfully Deposited");
        }
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }

            _balance -= amount;
            Console.WriteLine("Withdraw");
        }
        public double GetBalance()
        {
            return _balance;
        }
        public virtual double CalculateFee()
        {
            return 5.00;
        }
        public virtual void Display()
        {
            Console.WriteLine($"{_ownerName} | Balance: ${_balance:F2}");
        }

    }
    class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accNo, string Name, double Balance):base(accNo, Name, Balance)
        {

        }
        public override double CalculateFee()
        {
            return 10.00;
        }

    }
        internal class Program
    {


        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("ACC001", "John", 500);
            BankAccount acc2 = new BankAccount("ACC002", "Alice", 1000);
            BankAccount acc3 = new BankAccount("ACC003", "Bob", 200);
            // Perform transactions
            acc1.Deposit(200);
            acc1.Withdraw(100);

            acc2.Withdraw(1500); // should fail
            acc2.Deposit(300);

            acc3.Withdraw(50);
            acc3.Deposit(-20); // should fail

            // Print statements
            acc1.GetBalance();
            acc2.GetBalance();
            acc3.GetBalance();



            List<BankAccount> accounts = new List<BankAccount>
        {
            new BankAccount("A001", "John", 500),
            new SavingsAccount("A002", "Alice", 1500),
            new SavingsAccount("A003", "Bob", 800),
             };

foreach (var item in accounts)
            {
                item.Display();

                Console.WriteLine($"Fee: ${item.CalculateFee():F2}");
                Console.WriteLine("----------------------");
            }


        }
    }

}