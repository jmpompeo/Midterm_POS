using System;
using System.IO;

namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var transaction = new Transaction(15);

            var trans = transaction.UseCredit();
            Console.WriteLine(trans);

            transaction.UseCheck();

            
            
        }
    }
}
