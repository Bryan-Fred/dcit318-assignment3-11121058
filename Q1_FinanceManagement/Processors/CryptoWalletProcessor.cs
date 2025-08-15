using System;
using dcit318_assignment3_11121058.Q1_FinanceManagement.Interfaces;
using dcit318_assignment3_11121058.Q1_FinanceManagement.Models;

namespace dcit318_assignment3_11121058.Q1_FinanceManagement.Processors
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"💰 Crypto Wallet processed: {transaction.Amount:C} for {transaction.Category} on {transaction.Date:d}");
        }
    }
}
