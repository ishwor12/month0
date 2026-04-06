using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Models.Classes
{
    internal class Expense
    {
        public int ExpenseId { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Category { get; set; }
    }
}
