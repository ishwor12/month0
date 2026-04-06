using day1.Helper;
using day1.Models;
using day1.Models.Enums;
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

    internal class Program
    {

        static void Main(string[] args)
        {
            FinanceManager manager = new FinanceManager();
            bool isRunning = true;

            while (true)
            {
                ShowMenu();

                Console.Write("Select option: ");
                if (!int.TryParse(Console.ReadLine(), out int Choice))
                {
                    Console.WriteLine("Invalid Choice .");
                }
                switch (Choice)
                {
                    case 1:
                        CreateAccount(manager);
                        break;

                    case 2:
                        ViewAccount(manager);
                        break;

                    case 3:
                        Deposit(manager);
                        break;

                    case 4:
                        Withdraw(manager);
                        break;


                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        private static void ShowMenu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("      FINANCE TRACKER PRO");
            Console.WriteLine("====================================");
            Console.WriteLine("1 = Create Account");
            Console.WriteLine("2 = View Accounts");
            Console.WriteLine("3 = Deposit");
            Console.WriteLine("4 = Withdraw");
            Console.WriteLine("5 = Add Expense");
            Console.WriteLine("6 = View Transactions");
            Console.WriteLine("7 = Exit");
            Console.WriteLine("====================================");
        }
        static void CreateAccount(FinanceManager manager)
        {
            try
            {
                Console.Write("Enter Account ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Owner Name: ");
                string name = Console.ReadLine();

                Console.Write("Initial Balance: ");
                decimal balance = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Select Account Type: 1=Savings, 2=Current, 3=Business");
                int type = int.Parse(Console.ReadLine());

                BankAccount account = null;

                if (type == 1)
                {
                    Console.Write("Interest Rate: ");
                    decimal rate = decimal.Parse(Console.ReadLine());

                    Console.Write("Savings Goal: ");
                    decimal goal = decimal.Parse(Console.ReadLine());

                    account = new SavingsAccount(id, name, AccountType.Savings, balance, "", rate, goal);
                }
                else if (type == 2)
                {
                    Console.Write("Overdraft Limit: ");
                    decimal overdraft = decimal.Parse(Console.ReadLine());

                    Console.Write("Monthly Fee: ");
                    decimal fee = decimal.Parse(Console.ReadLine());

                    account = new CurrentAccount(id, name, AccountType.Current, balance, "", overdraft, fee);
                }
                else if (type == 3)
                {
                    Console.Write("Accont Name: Joint ");
                    string bname = Console.ReadLine();

                    Console.Write(" Rate: ");
                    decimal tax = decimal.Parse(Console.ReadLine());

                    account = new JointAccount(id, name, AccountType.Business, balance, DateTime.Now, "", bname, tax);
                }
                else
                {
                    Console.WriteLine("Invalid type.");
                    return;
                }

                manager.AddAccount(account);
                Console.WriteLine("Account created successfully!");
            }


            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        static void ViewAccount(FinanceManager manager)
        {
            var account = manager.GetAllAccount();
            if (account.Count() == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }
            foreach (var item in account)
            {
                Console.WriteLine($"\nID: {item.AccountId}");
                Console.WriteLine($"Name: {item.OwnerName}");
                Console.WriteLine($"Balance: {item.Balance}");
                Console.WriteLine($"Type: {item.AccountType}");

            }
        }
        static void Deposit(FinanceManager manager)
        {
            try
            {
                Console.Write("Account ID: ");
                int id = int.Parse(Console.ReadLine());

                // check if account exist

                Console.Write("Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                manager.DepositToAccount(id, amount);

                Console.WriteLine("Deposit successful!");
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            catch (Exception)
            {
                Console.WriteLine("Unexpected error occurred.");
            }
        }
        static void Withdraw(FinanceManager manager)
        {
            try
            {
                Console.Write("Account ID: ");
                int id = int.Parse(Console.ReadLine());

                //linq to check if account exist

                Console.Write("Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                // check if amoun isnt greateer than balance.

                manager.WithdrawFromAccount(id, amount);

                Console.WriteLine("Withdrawal successful!");
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error occurred.");
            }
        }

    }
}