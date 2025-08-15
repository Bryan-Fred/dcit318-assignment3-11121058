using System;
using dcit318_assignment3_11121058.Q3_WarehouseInventory.Interfaces;

namespace dcit318_assignment3_11121058.Q3_WarehouseInventory.Models
{
    public class GroceryItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; }

        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }
    }
}
