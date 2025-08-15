using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using dcit318_assignment3_11121058.Q5_InventoryRecordsSystem.Interfaces;

namespace dcit318_assignment3_11121058.Q5_InventoryRecordsSystem.Services
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private readonly List<T> _log = new();
        private readonly string _filePath;

        public InventoryLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll() => new(_log);

        public void SaveToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
                Console.WriteLine($"✅ Data saved to {_filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    Console.WriteLine("⚠ No saved data found.");
                    return;
                }

                var json = File.ReadAllText(_filePath);
                var items = JsonSerializer.Deserialize<List<T>>(json);

                if (items != null)
                {
                    _log.Clear();
                    _log.AddRange(items);
                    Console.WriteLine($"✅ Data loaded from {_filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading file: {ex.Message}");
            }
        }
    }
}
