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
            
            var newList = product.databaseList;
            
            product.GetOrder(newList);
        }

       
    }
}
