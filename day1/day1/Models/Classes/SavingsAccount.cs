using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models
{
    internal class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; }
        
        public decimal SavingsGoalAmount { get; set; }
        
        public SavingsAccount(
            int accountId,
            string ownerName,
            AccountType  AccountType,
              decimal balance,
            string notes,
            decimal interestRate,
            decimal savingsGoalAmount)
            : base
            (   accountId,
                  ownerName, 
                  AccountType.Savings,
                  balance,
                  notes
            )
        {
            InterestRate = interestRate;
            SavingsGoalAmount = savingsGoalAmount;
        }
        public override decimal CalculateFee()
        {
            return Balance > 1000 ? 0 : 2.5m;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Interest Rate: {InterestRate}");
        }

    }
}
