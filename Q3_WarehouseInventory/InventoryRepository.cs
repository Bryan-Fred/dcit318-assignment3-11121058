using System.Collections.Generic;
using dcit318_assignment3_11121058.Q3_WarehouseInventory.Exceptions;
using dcit318_assignment3_11121058.Q3_WarehouseInventory.Interfaces;

namespace dcit318_assignment3_11121058.Q3_WarehouseInventory
{
    public class InventoryRepository<T> where T : IInventoryItem
    {
        private readonly Dictionary<int, T> _items = new(); // key = item.Id

        public void AddItem(T item)
        {
            if (_items.ContainsKey(item.Id))
                throw new DuplicateItemException($"Item with ID {item.Id} already exists.");
            _items[item.Id] = item;
        }

        public T GetItemById(int id)
        {
            if (!_items.TryGetValue(id, out var item))
                throw new ItemNotFoundException($"Item with ID {id} was not found.");
            return item;
        }

        public void RemoveItem(int id)
        {
            if (!_items.Remove(id))
                throw new ItemNotFoundException($"Item with ID {id} was not found.");
        }

        public List<T> GetAllItems() => new List<T>(_items.Values);

        public void UpdateQuantity(int id, int newQuantity)
        {
            if (newQuantity < 0)
                throw new InvalidQuantityException("Quantity cannot be negative.");

            var item = GetItemById(id); // throws if not found
            item.Quantity = newQuantity;
        }
    }
}
