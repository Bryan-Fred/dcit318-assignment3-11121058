using System;
using System.Collections.Generic;
using dcit318_assignment3_11121058.Q1_FinanceManagement.Models;
using dcit318_assignment3_11121058.Q1_FinanceManagement.Processors;

namespace dcit318_assignment3_11121058.Q1_FinanceManagement
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new();

        public void Run()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== FINANCE MANAGEMENT SYSTEM ===\n");
            Console.ResetColor();

            // 1. Instantiate SavingsAccount
            var account = new SavingsAccount("ACC-001", 1000m);
            Console.WriteLine($"Account Created: {account.AccountNumber}, Initial Balance: {account.Balance:C}\n");

            // 2. Create transactions
            var t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 200m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 500m, "Entertainment");

            // 3. Processors
            var mobileMoneyProcessor = new MobileMoneyProcessor();
            var bankTransferProcessor = new BankTransferProcessor();
            var cryptoWalletProcessor = new CryptoWalletProcessor();

            // 4. Process each transaction
            Console.WriteLine("Processing Transactions:\n");

            mobileMoneyProcessor.Process(t1);
            account.ApplyTransaction(t1);
            _transactions.Add(t1);
            Console.WriteLine();

            bankTransferProcessor.Process(t2);
            account.ApplyTransaction(t2);
            _transactions.Add(t2);
            Console.WriteLine();

            cryptoWalletProcessor.Process(t3);
            account.ApplyTransaction(t3);
            _transactions.Add(t3);
            Console.WriteLine();

            // 5. Summary
            PrintSummary();
        }

        private void PrintSummary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== TRANSACTION SUMMARY ===");
            Console.ResetColor();

            foreach (var tx in _transactions)
            {
                Console.WriteLine($"ID: {tx.Id}, Date: {tx.Date:d}, Amount: {tx.Amount:C}, Category: {tx.Category}");
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
