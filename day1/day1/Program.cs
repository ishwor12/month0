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
            List<BankAccount> obj = new List<BankAccount>
            {
                new BankAccount("Ishwor", 500),
                new SavingAccount("Ram", 1500, 0.05m),
                new CurrentAccount("Hari", 800),

            };
            foreach (SavingAccount abc in obj)
            {
                Console.WriteLine($"{abc.OwnerName} | Balance: {abc.Balance:C} | Fee: {abc.CalculateFee():C}");
            }
        }

    }
}