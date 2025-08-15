using System;
using System.IO;
using dcit318_assignment3_11121058.Q1_FinanceManagement;
using dcit318_assignment3_11121058.Q4_GradingSystem; // ✅ Added for Q4 classes

namespace dcit318_assignment3_11121058
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=== DCIT 318 - ASSIGNMENT 3 ===");
                Console.ResetColor();
                Console.WriteLine("Select a question to run:\n");
                Console.WriteLine("1. Question 1 - Finance Management System");
                Console.WriteLine("2. Question 2 - Healthcare System");
                Console.WriteLine("3. Question 3 - Warehouse Inventory System");
                Console.WriteLine("4. Question 4 - Grading System");
                Console.WriteLine("5. Question 5 - Inventory Records System");
                Console.WriteLine("0. Exit");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        var financeApp = new FinanceApp();
                        financeApp.Run();
                        break;

                    case "2":
                        var healthApp = new dcit318_assignment3_11121058.Q2_HealthcareSystem.HealthSystemApp();
                        healthApp.Run();
                        break;

                    case "3":
                        var wh = new dcit318_assignment3_11121058.Q3_WarehouseInventory.WareHouseManager();
                        wh.Run();
                        break;

                    case "4":
                        Console.WriteLine(">>> Entered Q4 flow...");
                        try
                        {
                            var processor = new StudentResultProcessor();
                            var result = processor.ReadStudentsFromFile("students.txt");

                            // Display errors
                            foreach (var error in result.errors)
                            {
                                Console.WriteLine($"❌ {error}");
                            }

                            // Write the valid report
                            processor.WriteReportToFile(result.validStudents, "StudentReport.txt");
                            Console.WriteLine($"\n✅ Report written to StudentReport.txt with {result.validStudents.Count} valid records.");
                        }
                        catch (FileNotFoundException ex)
                        {
                            Console.WriteLine($"❌ File error: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Unexpected error: {ex.Message}");
                        }
                        Console.WriteLine("Press any key to return to menu...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("\n[Q5 not implemented yet]");
                        Pause();
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Invalid choice. Try again.");
                        Console.ResetColor();
                        Pause();
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
