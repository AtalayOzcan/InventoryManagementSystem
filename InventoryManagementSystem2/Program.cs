using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace InventoryManagementSystem
{
    internal class Program
    {
        public static List<Product> products = new List<Product>();
        public static string filePath = "products.json";

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public string Category { get; set; }

            public Product(int id, string name, decimal price, int stock, string category)
            {
                Id = id;
                Name = name;
                Price = price;
                Stock = stock;
                Category = category;
            }

            public override string ToString()
            {
                return $"ID: {Id} | Name: {Name} | Price: {Price:C} | Stock: {Stock} | Category: {Category}";
            }
        }

        public static void SaveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true }));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"💾 Products saved to {filePath}");
            Console.ResetColor();
        }

        public static void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"📂 Products loaded from {filePath}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("⚠️ File not found. Starting with empty inventory.");
                Console.ResetColor();
                products = new List<Product>();
            }
        }

        public static void ChangeFile()
        {
            Console.Write("Enter new file name (without .json): ");
            string name = Console.ReadLine();
            filePath = $"{name}.json";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"✅ Data file changed to {filePath}");
            Console.ResetColor();
            LoadFromFile();
        }

        public static void AddProduct()
        {
            try
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                if (products.Any(p => p.Id == id))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ This ID already exists!");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Stock: ");
                int stock = int.Parse(Console.ReadLine());

                Console.Write("Category: ");
                string category = Console.ReadLine();

                products.Add(new Product(id, name, price, stock, category));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Product added!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.ResetColor();
            }
        }

        public static void DisplayProducts()
        {
            if (!products.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("⚠️ No products to display.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📦 Inventory List:");
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
            Console.ResetColor();
        }

        public static void UpdateStock()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Product not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("New Stock Quantity: ");
            product.Stock = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Stock updated.");
            Console.ResetColor();
        }

        public static void UpdatePrice()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Product not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("New Price: ");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Price updated.");
            Console.ResetColor();
        }

        public static void RemoveProduct()
        {
            Console.Write("Enter product ID: ");
            int id = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Product not found.");
                Console.ResetColor();
                return;
            }

            products.Remove(product);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Product removed.");
            Console.ResetColor();
        }

        public static void CategoryReport()
        {
            if (!products.Any())
            {
                Console.WriteLine("⚠️ No products to report.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            var group = products.GroupBy(p => p.Category);
            foreach (var cat in group)
            {
                Console.WriteLine($"Category: {cat.Key} | Count: {cat.Count()}");
            }
            Console.ResetColor();
        }

        public static void SearchProduct()
        {
            Console.Write("Search by Name or Category: ");
            string keyword = Console.ReadLine().ToLower();
            var results = products.Where(p => p.Name.ToLower().Contains(keyword) || p.Category.ToLower().Contains(keyword)).ToList();

            if (!results.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ No matching products.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Search Results:");
            foreach (var p in results)
                Console.WriteLine(p);
            Console.ResetColor();
        }

        public static void SortProducts()
        {
            Console.WriteLine("Sort by:");
            Console.WriteLine("1. Price (Ascending)");
            Console.WriteLine("2. Price (Descending)");
            Console.WriteLine("3. Stock (Ascending)");
            Console.WriteLine("4. Stock (Descending)");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            IEnumerable<Product> sorted = products;
            switch (choice)
            {
                case "1": sorted = products.OrderBy(p => p.Price); break;
                case "2": sorted = products.OrderByDescending(p => p.Price); break;
                case "3": sorted = products.OrderBy(p => p.Stock); break;
                case "4": sorted = products.OrderByDescending(p => p.Stock); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ Invalid choice.");
                    Console.ResetColor();
                    return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 Sorted Products:");
            foreach (var p in sorted) Console.WriteLine(p);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter file name (without .json): ");
            filePath = $"{Console.ReadLine()}.json";
            LoadFromFile();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n=== Inventory Menu ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. Update Price");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Category Report");
                Console.WriteLine("6. Remove Product");
                Console.WriteLine("7. Save Products");
                Console.WriteLine("8. Search Product");
                Console.WriteLine("9. Sort Products");
                Console.WriteLine("10. Change File");
                Console.WriteLine("11. Exit");
                Console.ResetColor();
                Console.Write("Choice: ");
                var option = Console.ReadLine();

                Console.WriteLine();

                switch (option)
                {
                    case "1": AddProduct(); break;
                    case "2": UpdateStock(); break;
                    case "3": UpdatePrice(); break;
                    case "4": DisplayProducts(); break;
                    case "5": CategoryReport(); break;
                    case "6": RemoveProduct(); break;
                    case "7": SaveToFile(); break;
                    case "8": SearchProduct(); break;
                    case "9": SortProducts(); break;
                    case "10": ChangeFile(); break;
                    case "11": SaveToFile(); Console.WriteLine("👋 Goodbye!"); return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Invalid option.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}

