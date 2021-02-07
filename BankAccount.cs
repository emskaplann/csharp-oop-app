using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        public string Number { get; } // This how you give permission for operation on the object(get, set).
        public string Owner { get; set; }
        public decimal Balance {
            get // Here is how you set a getter in C#.
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 100000000;

        private List<Transaction> allTransactions = new List<Transaction> { };

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            MakeDeposit(initialBalance, DateTime.Now, "initial deposit.");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public void Print()
        {
            Console.WriteLine($"Owner: {this.Owner}, Balance: ${this.Balance}, Account Number: #{this.Number}");
        }

        public void PrintTransactions()
        {
            var report = new StringBuilder();
            
            // Header Line
            report.AppendLine("Idx\tDate\t\tAmount\tNote");
            Console.WriteLine("Transactions:");
            int index = 1;
            foreach (Transaction transaction in allTransactions)
            {
                report.AppendLine($"{index}\t{transaction.Date.ToShortDateString()}\t{transaction.Amount}\t{transaction.Note}");
                index++;
            }
            Console.Write(report.ToString());
        }
    }
}