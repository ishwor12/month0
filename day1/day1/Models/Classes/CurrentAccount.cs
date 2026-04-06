using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models
{
    internal class CurrentAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }
        public decimal MonthlyFee { get; set; }

        public CurrentAccount(
         int accountId,
         string ownerName,
         AccountType AccountType,
         decimal balance,
         string notes,
         decimal overdraftLimit,
         decimal monthlyFee)
         : base(accountId, ownerName, AccountType.Current, balance,  notes)
        {
            OverdraftLimit = overdraftLimit;
            MonthlyFee = monthlyFee;
        }
    }
}
