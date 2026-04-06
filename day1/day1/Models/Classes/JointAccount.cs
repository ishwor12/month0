using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models
{
    internal class JointAccount: BankAccount
    {
        public string JointAccountName { get; set; }
        public decimal InterestAmount { get; set; }
        public JointAccount(
               int accountId,
               string ownerName,
                AccountType AccountType,
               decimal balance,
               DateTime createdDate,
               string notes,
               string JointAccountName,
               decimal InterestAmount
               )

               : base(accountId, ownerName, AccountType.Business,balance,  notes)
        {

            this.JointAccountName = JointAccountName;
            this.InterestAmount = InterestAmount;
        }

    }
}
