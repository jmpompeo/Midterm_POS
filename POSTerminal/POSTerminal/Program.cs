﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Product> itemSold = new List<Product>();

            bool isValid;
            string response;
            do
            {
                var product = new Product();
                product.Menu();
                Console.WriteLine();

                var newList = product.GetOrder(product.databaseList);

                AddItemToList(newList, itemSold);
                Console.WriteLine();

                var trans = new Transaction();
                var lineTotal = trans.GetLineTotal(newList);
                trans.DisplayLineTotal(lineTotal);
                Console.WriteLine();

                var getTotal = trans.CalculateTotal(lineTotal);
                Console.WriteLine();

                trans.OrderAmount = getTotal;
                var paymentType = GetPaymentType();
                Console.WriteLine();

                trans.SelectPayment(paymentType);
                Console.WriteLine();

                var receipt = new Receipt();
                receipt.GenerateReceipt(lineTotal);
                Console.WriteLine();

                DisplayItemSoldToday(itemSold);
                do
                {
                    Console.WriteLine("Would you like to add another order?");
                    response = Console.ReadLine();
                    isValid = response != "y" && response != "n";

                } while (isValid);

                GetNewMenuItem(product.databaseList);

            } while (response.ToLower() == "y");

            EndProgram();
        }
        private static void EndProgram()
        {
            Console.WriteLine("Thank you for coming to CJR Burgers. Hope to see you soon!");
        }

        public static void AddItemToList(List<Product> newList, List<Product> itemSold)
        {
            foreach (var item in newList)
            {
                if (!itemSold.Any(x => x.Name == item.Name))
                {
                    itemSold.Add(new Product { Name = item.Name, Quantity = item.Quantity });
                }
                else
                {
                    foreach (var product in itemSold)
                    {
                        if (product.Name == item.Name)
                        {
                            product.Quantity += item.Quantity;
                        }
                    }
                }
            }
        }

        private static string GetPaymentType()
        {
            string paymentType;
            bool isValid;
            do
            {
                Console.WriteLine("Please select payment type: " + "\r\n" +
                                 "Cash, Credit or Check");
                paymentType = Console.ReadLine();

                isValid = paymentType != "Cash" && paymentType != "Credit" && paymentType != "Check";

            } while (isValid);

            if (paymentType.ToLower() == "cash")
            {
                return "cash";
            }
            else if (paymentType.ToLower() == "credit")
            {
                Console.WriteLine("Will it be debit or credit");
                var creditOrDebit = Console.ReadLine();
                if (creditOrDebit == "credit")
                {
                    return "credit";
                }
                else
                {
                    return "debit";
                }
            }
            else
            {
                return "check";
            }
        }

        private static void DisplayItemSoldToday(List<Product> itemSold)
        {
            foreach (var item in itemSold)
            {
                Console.WriteLine($"{item.Name} : {item.Quantity}");
            }
        }

        private static void GetNewMenuItem(List<Product> databaseList)
        {
            string response;
            bool isValid;
            do
            {
                Console.WriteLine("Would you like to add an item to the menu?");
                response = Console.ReadLine();
                isValid = response != "y" && response != "n";
            } while (isValid);

            string name = string.Empty;
            string category = string.Empty;
            string description = string.Empty;
            string price = string.Empty;

            if (response.ToLower() == "y")
            {
                Console.WriteLine("Please enter a name:");
                name = Console.ReadLine();

                Console.WriteLine("Please enter a category:");
                category = Console.ReadLine();

                Console.WriteLine("Please enter a description:");
                description = Console.ReadLine();

                Console.WriteLine("Enter a price:");
                price = Console.ReadLine();


                List<int> mealNumbers = new List<int>();
                int newItemNum = 0;
                foreach (var item in databaseList)
                {
                    mealNumbers.Add(item.MealNumber);
                }
                newItemNum = mealNumbers.Max();
                newItemNum++;

                StringBuilder builder = new StringBuilder();
                builder.Append($"{newItemNum},");
                builder.Append($"{name},");
                builder.Append($"{category},");
                builder.Append($"${price}");

                string message = builder.ToString();

                Database.AddItemToMenu(message);
            }
        }
    }
}