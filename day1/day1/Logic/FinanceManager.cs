using day1.Models;
using day1.Models.Classes;
using day1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class FinanceManager
    {
     
        private List<BankAccount> accounts = new List<BankAccount>();
        private List<Transaction> transaction = new List<Transaction>();
        private List<Expense> expenses = new List<Expense>();

        private int _nextAccountId = 1;
        public int GenerateAccountId()
        {
            return _nextAccountId++;
        }

        // Account Methods 

        public string AddAccount(BankAccount account)
        {
            foreach (var existingAccount in accounts)
            {
                if (existingAccount.AccountId == account.AccountId)
                {
                    return "Account ID already exists.";
                }
            }
            accounts.Add(account);
            return "Account created successfully.";
        }
        
        public BankAccount FindAccountBYId(int AccountId)
        {
            foreach (var account in accounts)
            {
                if (account.AccountId == AccountId)
                {
                    return account;
                }
            }

            return null;
        }
        public BankAccount FindAccountByName(string AccountName)
        {
            return null;
        }
        public List<BankAccount> GetAllAccount()
        {
            return new List<BankAccount>();
        }


        // Transaction Methods
        public string DepositToAccount(int AccountId, decimal Amount)
        {
            var account = FindAccountBYId(AccountId);
            if (account == null)
            {
                return "Account not found.";
            }
            if (Amount <= 0)
            {
                return "Deposit amount must be greater than zero.";
            }
            account.Deposit(Amount);
            // Simple Transaction Logger 
            transaction.Add(new Transaction
                (_nextAccountId,
                AccountId,
                TransactionType.Deposit,
                Amount,
                DateTime.Now,
                "Deposit"));

            return "Deposit successful.";

        }
        public string WithdrawFromAccount(int accountId, decimal amount)
        {
            var account = FindAccountBYId(accountId);

            if (account == null)
            {
                return "Account not found.";
            }

            if (amount <= 0)
            {
                return "Withdrawal amount must be greater than zero.";
            }

            if (account.Balance < amount)
            {
                return "Insufficient balance.";
            }

            account.Withdraw(amount);

            transaction.Add(new Transaction(
                _nextAccountId,
                accountId,
                TransactionType.Withdrawal,
                amount,
                DateTime.Now,
                "Withdrawal"));

            return "Withdrawal successful.";
        }
        public List<BankAccount> GetAllAccounts()
        {
            return accounts;
        }
        public List<Transaction> GetAllTransaction()
        {
            return transaction;
        }


        // Expenses Method


    }
}
