using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminal
{
    //Added Receipt class
    //Added GenerateReceipt method
    public class Receipt
    {
        public void GenerateReceipt(List<Product> newList)
        {
            var sb = new System.Text.StringBuilder();

            sb.Append(String.Format("{0,0} {1,15} {2,30}\n", "Quantity", "Item", "Price"));

            Console.WriteLine(sb);
            foreach (var item in newList)
            {
                Console.WriteLine("{0,0} {1,15}---------- {2,30}", $"{item.Quantity}", $"{item.Name}", $"{item.Price}");
         
            }
        }
    }
}
