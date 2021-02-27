﻿using System;
using System.Collections.Generic;
using System.IO;


namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product();
            product.Menu();
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
    }
}
