using System;

namespace dcit318_assignment3_11121058.Q1_FinanceManagement.Models
{
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction.Amount > Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Insufficient funds.");
                Console.ResetColor();
            }
            else
            {
                Balance -= transaction.Amount;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✅ Transaction successful. Updated balance: {Balance:C}");
                Console.ResetColor();
            }
        }
    }
}
