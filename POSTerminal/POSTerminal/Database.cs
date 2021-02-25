using System.Collections.Generic;
using System.IO;

namespace POSTerminal
{
    static class Database
    {
        //readonly static string text = File.ReadAllText(@"C:\Users\Raff\source\GCBootcamp\Midterm_POS\POSTerminal\ProductItem.txt");//Change file path

        public static List<Class1> RetriveItems()
        {
            List<Class1> menu = new List<Class1>();

            using (var reader = new StreamReader(@"ProductItem.txt"))
            {
                string item;
                do
                {
                    item = reader.ReadLine();
                    var output = item.Split(",");
                    menu.Add(new Class1
                    {
                        Name = output[0],
                        Category = output[1],
                        Description = output[2],
                        Price = output[3]
                    }) ;

                } while (item != null);
            }

            return menu;
        }
    }
}
