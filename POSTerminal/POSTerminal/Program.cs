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
        }
        private static string GetPaymentType()
        {
            Console.WriteLine("Your total is (enter total here).");
            Console.WriteLine("Please select payment type" + "\r\n" +
                               "Cash" + "\r\n" +
                               "Credit" + "\r\n" +
                               "Check");
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

        private static decimal CashGiven()
        {
            decimal cash = 0;
            bool isValid;
            do
            {
                Console.WriteLine("Please enter the amount of cash given");
                isValid = decimal.TryParse(Console.ReadLine(), out cash);

            } while (!isValid);

            return cash;
        }

    }
}