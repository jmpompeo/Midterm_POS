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
    }
}
