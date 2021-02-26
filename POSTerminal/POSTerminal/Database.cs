using System.Collections.Generic;
using System.IO;

namespace POSTerminal
{
    static class Database
    {
        
        public static List<Product> RetriveItems()
        {
            List<Product> menu = new List<Product>();


            using (var reader = new StreamReader(@"C:\Users\Raff\source\GCBootcamp\Midterm_POS\POSTerminal\POSTerminal\ProductItem.txt"))

            {

                string item;
                do
                {
                    item = reader.ReadLine();

                    if (item == null)
                    {
                        break;
                    }

                    var output = item.Split(",");
                    menu.Add(new Product
                    {
                        Name = output[0],
                        Category = output[1],
                        Description = output[2],

                        Price = decimal.TryParse(output[3], out int number) ? number : default
                    });

                } while (item != null);
            }

            return menu;
        }
    }
}
 