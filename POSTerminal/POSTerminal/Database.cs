using System.Collections.Generic;
using System.IO;

namespace POSTerminal
{
    static class Database
    {
        readonly static string text = File.ReadAllText(@"C:\Users\Raff\source\GCBootcamp\Midterm_POS\POSTerminal\ProductItem.txt");//Change file path


        
        public static List<string> DisplayDatabase()
        {
            List<string> menu = new List<string>();
           
            menu.Add(text);

            return menu;
        }        
    }
}
