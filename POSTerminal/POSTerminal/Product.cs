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

        //public List<string> GetProductItem()
        //{
        //    List<string> itemsordered = new List<string>();


        //    return itemsordered;
        //}

        //private static string ItemOrdered()
        //{


        //    return "";
        //}

        //public static string Inventory()
        //{
        //    //    Dictionary<string, int> menuItems = new Dictionary<string, int>()
        //    //{
        //    //    {"burger", 1}
        //    //};
        //    //    int dictionarykey = 1;

        //    //    if (menuItems.Values.Equals(dictionarykey))
        //    //    {
        //    //        return menuItems.Keys.Equals(string);
        //    //    }

        //    Dictionary<string, int> menuItems = new Dictionary<string, int>();
        //    menuItems.Add("Ind", 1);


        //    int num = 0;
        //    while (true)
        //    {
        //        Console.WriteLine("How many ____ would you like to order?");
        //        var itemquantity = Console.ReadLine();
        //        if (itemquantity == itemquantity)
        //            menuItems.Add();


          // }
        }
    }


        //    }

        //}
    }


}

