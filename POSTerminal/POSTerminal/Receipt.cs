using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminal
{
    //Added Receipt class
    //Added GenerateReceipt method
    public class Receipt
    {
        public void GenerateReceipt(List<Product> lineTotal)
        {
            decimal pricePerItem;
            decimal subTotal = 0;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("{0,30}", "Welcome to CJR Burgers"));
            sb.AppendLine(String.Format("{0,24}", "123 Main St"));
            sb.AppendLine(String.Format("{0,26}", "Hell, MI 48169"));
            sb.AppendLine(String.Format("{0,25}", "313-432-8637"));

            sb.AppendLine("==============================================");
            sb.AppendLine(String.Format("{0,-8} {1,-30} {2,-30}\n", "Qty", "Item", "Price"));
            Console.WriteLine(sb);
            foreach (var item in lineTotal)
            {
                Console.WriteLine("{0,-8} {1,-30} {2,-30}", $"{item.Quantity}", $"{item.Name}", $"${item.Price}");
                pricePerItem = item.Quantity * item.Price;
                subTotal += pricePerItem;
            }
            Console.WriteLine("==============================================");
            Console.WriteLine("{0,-8} {1,33:NO}", "Subtotal:", $"${subTotal}");
            decimal salesTax = .06M;
            decimal totalSalesTax = subTotal * salesTax;
            Console.WriteLine("{0,-8} {1,34:NO}", "Sales Tax:", $"${totalSalesTax}");
            decimal total = totalSalesTax + subTotal;
            Console.WriteLine("{0,-8} {1,37:NO}", "Total:", $"${total}");
        }
    }
}
