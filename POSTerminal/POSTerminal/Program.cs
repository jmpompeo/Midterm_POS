using System;


using System.Collections.Generic;
using System.IO;


namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var trans = new Transaction(50);

            trans.UseCredit();

        }

        // Menu
        // Select itme by name or number
        // Select quantity
        // Give user a line item
        // Redisplay menu 

    }
}
