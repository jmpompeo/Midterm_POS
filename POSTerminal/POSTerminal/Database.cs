using System.Collections.Generic;
using System.IO;

namespace POSTerminal
{
    static class Database
    {

        public static List<Product> RetriveItems()
        {
            List<Product> menu = new List<Product>();


            using (var reader = new StreamReader(@"C:\Users\Owner\Source\Repos\Midterm_POS\POSTerminal\POSTerminal\ProductItem.txt"))

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
                        OrderNumber = output[0],
                        Name = output[1],
                        Category = output[2],
                        Description = output[3],

                        Price = decimal.TryParse(output[4], out int number) ? number : default
                    });

                } while (item != null);
            }

            return menu;
        }
    }
}
 