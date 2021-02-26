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

            var productList = new List<Product>();
            productList.Add(new Product { Name = "Cheeseburger", Price = 4, Quantity = 2 });
            productList.Add(new Product { Name = "Cheeseburger", Price = 4, Quantity = 4 });
            productList.Add(new Product { Name = "Cheeseburger", Price = 4, Quantity = 3 });

            var trans = new Transaction();
            var amount = trans.GetLineTotal(productList);
            Console.WriteLine(amount);
            
        }

        private static void DisplayMenu(List<Product> products)
        {
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} {item.Category} {item.Description} {item.Price}");
            }

        }

        // Select item by name or number
        // Select quantity
        // Give user a line item
        // Redisplay menu 

    }
}
