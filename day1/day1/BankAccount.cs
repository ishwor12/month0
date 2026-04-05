using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    // Exercise 2: Create a BankAccount class with Deposit(),
    // Withdraw(), and GetStatement().
    // Reject invalid withdrawals.

    internal class BankAccount
    {
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string ownerName, decimal balance)
        {
            OwnerName = ownerName;
            Balance = balance;

        }
        public virtual decimal CalculateFee()
        {
            return 5.00m;
        }
    }
    internal class SavingAccount: BankAccount
    {
        public decimal InterestRate { get; set; }
        public SavingAccount(string ownerName, decimal balance, decimal interestRate):base (ownerName,  balance)
        {
            InterestRate = interestRate;
        }
        public override decimal CalculateFee()
        {
            return Balance < 1000 ? 0.01m : 2.50m;
        }
    }
    internal class CurrentAccount : BankAccount
    {
        public CurrentAccount(string ownerName, decimal balance) :base( ownerName,  balance)
        {

        }
        public override decimal CalculateFee()
        {
            return 0.00m;
        }
    }
}
