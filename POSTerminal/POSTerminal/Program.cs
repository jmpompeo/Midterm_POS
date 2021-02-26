using System;


using System.Collections.Generic;
using System.IO;


namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {

            var newList = Database.RetriveItems();
            DisplayMenu(newList);
            
        }

        private static void DisplayMenu(List<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} {item.Category} {item.Description} {item.Price}");
            }

        }

        // Menu
        // Select itme by name or number
        // Select quantity
        // Give user a line item
        // Redisplay menu 

    }
}
