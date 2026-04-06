using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models.Classes
{
    internal class Expenses
    {
        public int ExpenseId { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public ExpenseCategory Category { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Expenses(int expenseId, int accountId, string description, decimal amount, ExpenseCategory category, DateTime date, string notes)
        {
            ExpenseId = expenseId;
            AccountId = accountId;
            Description = description;
            Amount = amount;
            Category = category;
            Date = date;
            Notes = notes;
        }
    }
}
