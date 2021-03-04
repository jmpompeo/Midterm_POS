using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        
        public void Menu()
        {
            var productList = Database.RetriveItems();

            Console.WriteLine("Welcome to CJR! Here is our menu:");

            foreach (var item in productList)
            {
                Console.WriteLine($"{item.MealNumber}: {item.Name}, {item.Description}, ${item.Price}");
                databaseList.Add(item);
            }
        }

        public List<Product> GetOrder(List<Product> databaseList)
        { 

            var products = new List<Product>();
            bool isValid;
            string addToOrder;
            string order;

            do
            {
                do
                {
                    Console.WriteLine("What would you like to order? ");
                    order = Console.ReadLine();

                } while (string.IsNullOrEmpty(order));
               

                int orderNumber = 0;
                string itemName = string.Empty;

                if(int.TryParse(order, out int number))
                {
                    var mealNumber = new List<int>();
                    foreach (var item in databaseList)
                    {
                        mealNumber.Add(item.MealNumber);
                    }

                    if (mealNumber.Contains(number))
                    {
                        orderNumber = number;

                    }
                    else
                    {
                        var tryAgain = string.Empty;
                        string mealString;
                        do
                        {
                            Console.WriteLine("Please enter a correct item:");
                            tryAgain = Console.ReadLine();
                            mealString = mealNumber.ToString();

                        } while (!mealString.Contains(tryAgain));
                    }
                }
                else
                {
                    var orderName = new List<string>();

                    foreach (var item in databaseList)
                    {
                        orderName.Add(item.Name);
                    }

                    if (orderName.Contains(order))      
                    {
                        itemName = order;
                    }
                    else
                    {
                        var tryAgain = string.Empty;
                        do
                        {
                            Console.WriteLine("Please enter a correct item:");
                            tryAgain = Console.ReadLine();

                        } while (!orderName.Contains(tryAgain));
                    }
                    
                }

                Console.WriteLine("How many would you like?");
                var quantity = int.TryParse(Console.ReadLine(), out int num) ? num : default;
            
                foreach (var item in databaseList)
                {
                    if (item.Name == itemName)
                    {
                        products.Add(new Product { Name = item.Name, Quantity = quantity, Price = item.Price });
                    }
                    else if(item.MealNumber == orderNumber)
                    {
                        products.Add(new Product { Name = item.Name, Quantity = quantity, Price = item.Price });
                    }
                }

                do
                {
                    Console.WriteLine("Would you like to add to your order? (y/n)");
                    addToOrder = Console.ReadLine();
                    isValid = addToOrder != "y" && addToOrder != "n";

                } while (isValid);               

            } while (addToOrder.ToLower() == "y");

            return products;
        }
    }
}