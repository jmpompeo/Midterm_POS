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
            //int count = 0;

            foreach (var item in products)
            {
                //++count;

                Console.WriteLine($"{item.OrderNumber}", $"{item.Name} {item.Category} {item.Description} {item.Price}");
            }

        }
        //++count;++count;++count;

        // Menu
        // Select itme by name or number
        // Select quantity
        // Give user a line item
        // Redisplay menu 

    }
}
