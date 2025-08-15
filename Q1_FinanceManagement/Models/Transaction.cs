using System;

namespace dcit318_assignment3_11121058.Q1_FinanceManagement.Models
{
    // Immutable financial transaction record
    public record Transaction(int Id, DateTime Date, decimal Amount, string Category);
}
