using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Product> databaseList = new List<Product>();
      
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
            var productList = Database.RetriveItems();

            Console.WriteLine("Welcom to CJR! Here is our menu:");

            foreach (var item in productList)
            {
                Console.WriteLine($"{item.MealNumber}: {item.Name}, {item.Description}, ${item.Price}");
                databaseList.Add(item);
            }
        }

        public List<Product> GetOrder(List<Product> databaseList)
        {
            var products = new List<Product>();
            Console.WriteLine("What would you like to order? ");
            var reponse = Console.ReadLine();

            if (reponse.ToLower() == "1" || reponse.ToLower() == "cheeseburger")
            {
                products.Add(databaseList[0]);
            }
            else if (reponse.ToLower() == "2" || reponse.ToLower() == "double cheeseburger")
            {
                products.Add(databaseList[1]);
            }
            else if (reponse.ToLower() == "3" || reponse.ToLower() == "cheesesticks")
            {
                products.Add(databaseList[2]);
            }
            else if (reponse.ToLower() == "4" || reponse.ToLower() == "chicken nuggets")
            {
                products.Add(databaseList[3]);
            }
            else if (reponse.ToLower() == "5" || reponse.ToLower() == "french fries")
            {
                products.Add(databaseList[4]);
            }
            else if (reponse.ToLower() == "6" || reponse.ToLower() == "onion rings")
            {
                products.Add(databaseList[5]);
            }
            else if (reponse.ToLower() == "7" || reponse.ToLower() == "coca cola")
            {
                products.Add(databaseList[6]);
            }
            else if (reponse.ToLower() == "8" || reponse.ToLower() == "diet coke")
            {
                products.Add(databaseList[7]);
            }
            else if (reponse.ToLower() == "9" || reponse.ToLower() == "sprite")
            {
                products.Add(databaseList[8]);
            }
            else if (reponse.ToLower() == "10" || reponse.ToLower() == "water")
            {
                products.Add(databaseList[9]);
            }
            else if (reponse.ToLower() == "11" || reponse.ToLower() == "vanilla ice cream")
            {
                products.Add(databaseList[10]);
            }
            else if (reponse.ToLower() == "12" || reponse.ToLower() == "chocolate ice cream")
            {
                products.Add(databaseList[11]);
            }
            else
            {
                Console.WriteLine("Go away");
            }
            return products;
        }
      
        //public Dictionary<int, int> GetCustomerOrder()
        //{
        //    Dictionary<int, int> menuItems = new Dictionary<int, int>();

        //    bool addToOrder = true;

        //    while (addToOrder)
        //    {
        //        Console.WriteLine("What would you like to order?");
        //        string item = Console.ReadLine();
        //        int itemselect;
        //        Int32.TryParse(item, out itemselect);

        //        Console.WriteLine($"How many {item}(s) would you like to order?");
        //        string quantity = Console.ReadLine();
        //        int itemquantity;
        //        Int32.TryParse(quantity, out itemquantity);
              
        //        menuItems.Add(itemselect, itemquantity);

        //        Console.WriteLine("Would you like to add to your order? (y/n)");
        //        string response = Console.ReadLine().ToUpper();

        //        if (response == "N")
        //        {
        //            addToOrder = false;
        //        }
        //    }
          
        //    return menuItems;
        //}
    }
}