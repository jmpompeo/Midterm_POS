using System;
using System.Collections.Generic;
using System.IO;


namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CJR!");
            Console.WriteLine();
            var products = Database.RetriveItems(); 
            DisplayMenu(products); 
        }

        public static void DisplayMenu(List<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} {item.Category} {item.Description} {item.Price}");
            }
        }
        private static string GetItemChoice()
        {
            Console.WriteLine("What would you like to order?");
            string order = Console.ReadLine();
          
            return $"You ordered {order}";
        }
        // Menu
        // Select itme by name or number
        // Select quantity
        // Give user a line item
        // Redisplay menu 
    }
}
