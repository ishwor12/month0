using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models
{
    internal class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Transaction(int transactionId, int accountId, TransactionType transactionType, decimal amount, DateTime date, string description)
        {
            TransactionId = transactionId;
            AccountId = accountId;
            TransactionType = transactionType;
            Amount = amount;
            Date = date;
            Description = description;
        }
    }
}
