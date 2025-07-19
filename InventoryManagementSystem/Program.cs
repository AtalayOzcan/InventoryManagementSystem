using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    internal class Program
    {
        static List<Product> products = new List<Product>();
        // Product class to hold product details
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            // Constructor to initialize product details
            public Product(string name, decimal price, int stock)
            {
                Name = name;
                Price = price;
                Stock = stock;
            }
            public override string ToString()
            {
                return $"{Name} - Price: {Price}, Stock: {Stock}";
            }
        }

        // Methods to manage products
        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter stock quantity: ");
            int stock = int.Parse(Console.ReadLine());

            products.Add(new Product(name, price, stock));
            Console.WriteLine("Product added successfully.");
        }

        // Method to update stock of a product
        static void UpdateStock()
        {
            Console.Write("Enter product name to update stock: ");
            string name = Console.ReadLine();
            // Find the product by name
            var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            // If product is found, update its stock
            if (product != null)
            {
                Console.Write("Enter new stock quantity: ");
                int newStock = int.Parse(Console.ReadLine());
                product.Stock = newStock;
                Console.WriteLine("Stock updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        // Method to view all products
        static void ViewProducts()
        {// Display all products in the inventory
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                Console.WriteLine("Available Products:");
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
        }
        // Method to remove a product from the inventory
        static void RemoveProduct()
        {
            Console.Write("Enter product name to remove: ");
            string name = Console.ReadLine();
            // Find the product by name
            var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            // If product is found, remove it from the list
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product removed successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        static void Main(string[] args)
        {// Main method to run the inventory management system
            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Stock");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateStock();
                        break;
                    case "3":
                        ViewProducts();
                        break;
                    case "4":
                        RemoveProduct();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}


//Inventory management system

//To complete this challenge, you will need to create a console application where users can manage product stock. Users should be able to add new products, update stock, and remove products.

//Some key features include:

//Add new products with name, price, and stock quantity.

//Update stock when products are sold or restocked.

//View all products and their stock levels.

//Remove products from inventory.
