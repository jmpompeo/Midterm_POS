using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminal
{
    public class Product
    {
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        //public void Menu()
        //{
        //    var orderList = Database.RetriveItems();

        //    foreach (var item in orderList)
        //    {
        //        Console.WriteLine($"{item.OrderNumber} {item.Name} {item.Price}");
        //    }
        //}

        //public List<string> GetProductItem()
        //{
        //    List<string> itemsordered = new List<string>();


        //    return itemsordered;
        //}

        //private static string ItemOrdered()
        //{


        //    return " ";
        //}

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
