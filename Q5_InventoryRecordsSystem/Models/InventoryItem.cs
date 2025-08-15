using System;
using dcit318_assignment3_11121058.Q5_InventoryRecordsSystem.Interfaces;

namespace dcit318_assignment3_11121058.Q5_InventoryRecordsSystem.Models
{
    // Immutable inventory item record
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;
}
