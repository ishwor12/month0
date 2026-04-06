using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Helper
{
    internal class InsufficientFundsException : Exception
    {
        public decimal Balance { get; }
        public decimal AttemptedAmount { get; }

        public InsufficientFundsException(decimal balance, decimal amount)
            : base($"Insufficient funds. Balance: {balance}, Attempted: {amount}")
        {
            Balance = balance;
            AttemptedAmount = amount;
        }
    }
    internal class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(int accountId)
            : base($"Account with ID {accountId} not found.")
        {
        }
    }
}
