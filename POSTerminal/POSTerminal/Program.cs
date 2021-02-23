using System;

namespace POSTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var newList = Database.DisplayDatabase();
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
