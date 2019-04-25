using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_04
{
    class Program
    {
        static void Main(string[] args)
        {
            InternetStore store = new InternetStore();

            /*using(var context = new AppContext())
            {
                context.Products.Add(new Product()
                {
                    Name = "Селдь",
                    Cost = 1240
                });
                context.Products.Add(new Product()
                {
                    Name = "Пиво",
                    Cost = 2000
                });
                context.SaveChanges();
            }*/

            store.Run();
            Console.ReadLine();
        }
    }
}
