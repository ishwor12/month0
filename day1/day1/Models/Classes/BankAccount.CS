using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models
{
    internal class BankAccount
    {
        public int AccountId { get; private  set; }
        public String OwnerName { get; private  set; }
        public AccountType AccountType { get; private  set; }
        public decimal Balance { get; private set; }
       
        public string Notes { get; private  set; }
        public BankAccount(int Id, string Name, AccountType AccountType, decimal balance, string note)
        {
            AccountId = Id;
            OwnerName = Name;
            this.AccountType = AccountType;
            Balance = balance;
            Notes = note;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;

        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
