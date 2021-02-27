using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminal
{
    public class Product
    {
        public int MealNumber { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
      
        public List<string> GetProductItem()
        {
            List<string> itemsordered = new List<string>();

            return itemsordered;
        }

        private static string ItemOrdered()
        {
           return "";
        }

        public void Menu()
        {
            var producutList = Database.RetriveItems();

            Console.WriteLine("Welcom to CJR! Here is our menu:");

            foreach (var item in prudcutList)
            {
                Console.WriteLine($"{item.MealNumber}: {item.Name}, {item.Description}, ${item.Price}");
            }
        }
      
        public static Dictionary<int, int> CustomerOrders()
        {
            Dictionary<int, int> menuItems = new Dictionary<int, int>();

            bool addToOrder = true;

            while (addToOrder)
            {
                Console.WriteLine("What would you like to order?");
                string item = Console.ReadLine();
                int itemselect;
                Int32.TryParse(item, out itemselect);

                Console.WriteLine($"How many {item}(s) would you like to order?");
                string quantity = Console.ReadLine();
                int itemquantity;
                Int32.TryParse(quantity, out itemquantity);
              
                menuItems.Add(itemselect, itemquantity);

                Console.WriteLine("Would you like to add to your order? (y/n)");
                string response = Console.ReadLine().ToUpper();

                if (response == "N")
                {
                    addToOrder = false;
                }

            }
          
            return menuItems;
        }
    }
}