using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSTerminal
{
    //Removed Item ordered method
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
            bool isValid;
            string addToOrder;
            do
            {                
                Console.WriteLine("What would you like to order? ");
                var response = Console.ReadLine();

                int output = 0;
                string outputString = "";

                if(int.TryParse(response, out int number))
                {
                    output = number;
                }
                else
                {
                    outputString  = response;
                }

                Console.WriteLine("How many would you like?");
                var quantity = int.TryParse(Console.ReadLine(), out int num) ? num : default;
            
                foreach (var item in databaseList)
                {
                    if (item.Name == outputString)
                    {
                        products.Add(new Product { Name = item.Name, Quantity = quantity, Price = item.Price });
                    }
                    else if(item.MealNumber == output)
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