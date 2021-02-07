using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Intro to Object Oriented Programming with C#
            BankAccount newAccount = new BankAccount("Emirhan", 1453);
            newAccount.Print();
            newAccount.MakeWithdrawal(1119, DateTime.Now, "New laptop.");
            newAccount.Print();

            Console.WriteLine();
            newAccount.PrintTransactions();
            Console.WriteLine();

            // Exception Handling
            Console.WriteLine("Attempting to overdraw...");
            // Test for a negative balance.
            try
            {
                newAccount.MakeWithdrawal(540, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Trying to create invalid account.");
            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }
        }
    }
}