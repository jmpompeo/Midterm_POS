using System;
using System.Collections.Generic;

namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var newList = Database.DisplayItems();
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
