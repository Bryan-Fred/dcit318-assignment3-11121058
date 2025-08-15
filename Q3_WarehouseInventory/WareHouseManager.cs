using System;
using System.Collections.Generic;
using dcit318_assignment3_11121058.Q3_WarehouseInventory.Exceptions;
using dcit318_assignment3_11121058.Q3_WarehouseInventory.Interfaces;
using dcit318_assignment3_11121058.Q3_WarehouseInventory.Models;

namespace dcit318_assignment3_11121058.Q3_WarehouseInventory
{
    public class WareHouseManager
    {
        private readonly InventoryRepository<ElectronicItem> _electronics = new();
        private readonly InventoryRepository<GroceryItem> _groceries = new();

        // --- Seed data ---
        public void SeedData()
        {
            // Electronics (2–3)
            _electronics.AddItem(new ElectronicItem(201, "Smartphone", 15, "TechOne", 24));
            _electronics.AddItem(new ElectronicItem(202, "Laptop", 10, "GigaCore", 12));
            _electronics.AddItem(new ElectronicItem(203, "Bluetooth Speaker", 25, "SoundMax", 18));

            // Groceries (2–3)
            _groceries.AddItem(new GroceryItem(301, "Rice 5kg", 40, DateTime.Today.AddMonths(12)));
            _groceries.AddItem(new GroceryItem(302, "Milk 1L", 60, DateTime.Today.AddMonths(2)));
            _groceries.AddItem(new GroceryItem(303, "Eggs (Tray)", 30, DateTime.Today.AddDays(21)));
        }

        // --- Printing ---
        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== {typeof(T).Name.ToUpper()} LIST ===");
            Console.ResetColor();

            var items = repo.GetAllItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items.\n");
                return;
            }

            foreach (var item in items)
            {
                // Base info
                Console.Write($"ID: {item.Id,-4} Name: {item.Name,-20} Qty: {item.Quantity,-4}");

                // Type-specific extras
                switch (item)
                {
                    case ElectronicItem e:
                        Console.WriteLine($" Brand: {e.Brand,-10} Warranty: {e.WarrantyMonths}m");
                        break;
                    case GroceryItem g:
                        Console.WriteLine($" Expiry: {g.ExpiryDate:dd/MM/yyyy}");
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            Console.WriteLine();
        }

        // --- Mutations with exception handling ---
        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id); // throws if not found
                var newQty = item.Quantity + quantity;
                repo.UpdateQuantity(id, newQty);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✅ Stock updated for ID {id}. New quantity: {newQty}");
                Console.ResetColor();
            }
            catch (ItemNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ResetColor();
            }
            catch (InvalidQuantityException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ResetColor();
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✅ Removed item with ID {id}");
                Console.ResetColor();
            }
            catch (ItemNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ResetColor();
            }
        }

        // --- Demo runner for Program.cs (follows Main flow in the brief) ---
        public void Run()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== WAREHOUSE INVENTORY SYSTEM ===\n");
            Console.ResetColor();

            SeedData();

            // Print all items
            PrintAllItems(_groceries);
            PrintAllItems(_electronics);

            // v. Try scenarios (duplicate, remove missing, invalid quantity)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== TESTING ERROR HANDLING ===");
            Console.ResetColor();

            // Add duplicate item
            try
            {
                Console.WriteLine("Attempting to add duplicate Electronics ID 201...");
                _electronics.AddItem(new ElectronicItem(201, "Phone (Duplicate)", 5, "TechOne", 24));
            }
            catch (DuplicateItemException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ResetColor();
            }

            // Remove non-existent item
            Console.WriteLine("Attempting to remove Grocery ID 999...");
            RemoveItemById(_groceries, 999);

            // Update with invalid quantity
            Console.WriteLine("Attempting to set negative quantity for Electronics ID 202...");
            try
            {
                _electronics.UpdateQuantity(202, -10);
            }
            catch (InvalidQuantityException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ResetColor();
            }
            catch (ItemNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
