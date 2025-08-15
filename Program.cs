using System;
using dcit318_assignment3_11121058.Q1_FinanceManagement;

namespace dcit318_assignment3_11121058
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ensure console can display UTF-8 characters if needed
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
                        Console.WriteLine("\n[Q2 not implemented yet]");
                        Pause();
                        break;

                    case "3":
                        Console.WriteLine("\n[Q3 not implemented yet]");
                        Pause();
                        break;

                    case "4":
                        Console.WriteLine("\n[Q4 not implemented yet]");
                        Pause();
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
