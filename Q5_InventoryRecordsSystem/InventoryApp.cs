using System;
using System.IO;
using dcit318_assignment3_11121058.Q5_InventoryRecordsSystem.Models;
using dcit318_assignment3_11121058.Q5_InventoryRecordsSystem.Services;

namespace dcit318_assignment3_11121058.Q5_InventoryRecordsSystem
{
    public class InventoryApp
    {
        private readonly InventoryLogger<InventoryItem> _logger;
        private readonly string _filePath;

        public InventoryApp()
        {
            _filePath = Path.Combine(GetProjectRootPath(), "inventory.json");
            _logger = new InventoryLogger<InventoryItem>(_filePath);
        }

        public void SeedSampleData()
        {
            // Use a fixed DateAdded for repeatable output, or DateTime.Now if you prefer freshness
            DateTime now = DateTime.Now;

            _logger.Add(new InventoryItem(1, "Laptop", 10, now));
            _logger.Add(new InventoryItem(2, "Smartphone", 25, now));
            _logger.Add(new InventoryItem(3, "Keyboard", 50, now));
            _logger.Add(new InventoryItem(4, "Monitor", 15, now));
            _logger.Add(new InventoryItem(5, "Mouse", 40, now));
        }

        public void SaveData() => _logger.SaveToFile();

        public void LoadData() => _logger.LoadFromFile();

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            if (items.Count == 0)
            {
                Console.WriteLine("⚠ No items in inventory.");
                return;
            }

            Console.WriteLine("\n📦 INVENTORY ITEMS:");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id} | Name: {item.Name} | Quantity: {item.Quantity} | Date Added: {item.DateAdded}");
            }
        }

        private string GetProjectRootPath()
        {
            // Walk up 3 levels from bin/Debug/netX.X to the project root
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var root = Directory.GetParent(baseDir)!.Parent!.Parent!.Parent!.FullName;
            return root;
        }
    }
}
