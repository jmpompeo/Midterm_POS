using System;
using System.Collections.Generic;
using System.IO;


namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product();
            product.Menu();
            Console.WriteLine();
            var newList = product.GetOrder(product.databaseList);
            Console.WriteLine();
            var trans = new Transaction();

            var lineTotal = trans.GetLineTotal(newList);
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
            product.ItemsSoldToday(newList);
        }

        private static string GetPaymentType()
        {
            Console.WriteLine("Please select payment type: " + "\r\n" +
                               "Cash, Credit or Check");
               
            var paymentType = Console.ReadLine();

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
    }
}