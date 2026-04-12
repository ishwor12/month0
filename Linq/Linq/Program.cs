using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Linq
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Find all Electronics under $500, ordered cheapest first
            // 2. Get the top 3 most expensive products (name and price only)
            // 3. Check if any product is out of stock (Stock == 0)
            // 4. Calculate total inventory value (Price × Stock, summed)
            // 5. Find the most expensive product in the Furniture category
            // 6. Get a distinct list of all categories (use .Select(...).Distinct())

            var products = new List<Product>
            {
                new Product { Name = "Laptop",     Category = "Electronics", Price = 120m, Stock = 5  },
                new Product { Name = "Phone",      Category = "Electronics", Price =  800m, Stock = 12 },
                new Product { Name = "Desk",       Category = "Furniture",   Price =  350m, Stock = 3  },
                new Product { Name = "Chair",      Category = "Furniture",   Price =  150m, Stock = 8  },
                new Product { Name = "Chair",      Category = "Furniture",   Price =  150m, Stock = 8  },
                new Product { Name = "Headphones", Category = "Electronics", Price =   90m, Stock = 20 },
                new Product { Name = "Monitor",    Category = "Electronics", Price =  450m, Stock = 0  },
            };

            var items = from n in products
                        where n.Category.Contains("Furniture")
                        orderby n.Stock descending
                        select n;

            var fur = products.Where(p => p.Price > 300)
                        .OrderByDescending(o => o.Price);


            var elec = products.Where(p => p.Category.Contains("Electronics"))
                            .OrderBy(o => o.Price)
                            .Skip(2)
                            .Take(2)
                            ;

            //out of stock

            var outs = from n in products
                       where n.Stock <= 1
                       select n;
            //counting product
            var counts = from na in products
                         where na.Category == "Electronics"
                         select na;
            var countng = products.Count(p => p.Category == "Furniture");

            //   Calculate total inventory value(Price × Stock, summed)

            var productx = products.Where(x => x.Category == "Furniture")
                                    .Sum(y => y.Price * y.Stock);

            //Safest equal that fail:
            var producty = products.SingleOrDefault(x => x.Name == "Desk");
            var productz = products.FirstOrDefault(x => x.Category == "Electronics");
            ;
            Console.WriteLine("============     yy       ====================== ");
            Console.WriteLine(producty.Name);
            Console.WriteLine(productz.Name);

            //foreach (var item in productz)
            //{
            //    Console.WriteLine(item.Name + "- ! - ! "+item.Price);
            //}

            // calculate by inventory
            var totalval = products.Where(p => p.Category == "Furniture").Sum(p => p.Price);


            var counting = products.
                Where(p => p.Category == "Electronics")
                .Count();
            Console.WriteLine(counting);



            foreach (var item in fur)
            {
                Console.WriteLine($"{item.Name} - {item.Category} - {item.Price:C} -{item.Stock}");

            }
            // InStock Only
            Console.WriteLine("*************");
            var Stocksx = products.Where(p => p.Stock > 0);
            var namesx = products.Select(p => p.Name);
            var all = from n in products
                      orderby n.Name ascending
                      select n;

            foreach (var item in Stocksx)
            {

                Console.WriteLine($"{item.Name} - {item.Category} - {item.Price:C} -{item.Stock}");

            }
            Console.WriteLine("!!!!!!!_____!!!!!!!!!!!");
            foreach (var item in all)
            {

                Console.WriteLine($"{item.Name} -  - {item.Price:C} ");

            }
            Console.WriteLine("-------------");

            var allp = products.OrderBy(o => o.Name)
                .Select(y => y.Name);
            foreach (var itemsx in allp)
            {
                Console.WriteLine(itemsx);
            }

            Console.WriteLine("------------");

            var range = products.Where(p => p.Price >= 100 && p.Price <= 500)
                .OrderByDescending(p => p.Price)
                .Distinct();

            Console.WriteLine("!*!*!*!*!*!*!*!*!*!*!*!*!*");
            foreach (var itemsx in range)
            {
                Console.WriteLine(itemsx.Name + "- -" + itemsx.Price);
            }
            Console.WriteLine("_!_!_!_!_!_!_!_!_!_!_!_!_");
            foreach (var itemsx in elec)
            {
                Console.WriteLine(itemsx.Name + "- -" + itemsx.Price);
            }


            //Print "LOW STOCK WARNING" if any product has Stock less than 3.Print "All good" otherwise.
            var low = (products.Any(p => p.Category == "Furniture" && p.Stock < 3));

            var lowx = (products.All(p => p.Stock < 3));
            if (low == true)
            {

                Console.WriteLine("LOw Stock Warning for all");
            }
            else
            {
                Console.WriteLine("All Good");
            }


            // level 3 Hard

            //11.Inventory value per category
            //Without using GroupBy, calculate and print the total inventory
            //value(Price × Stock) for Electronics and Furniture separately
            //using two LINQ queries.

            Console.WriteLine("{{{{{{{{{{{{{}}}}}}}}}}}}}}}}}}}}");

            var invent = products.Where(p => p.Category == "Electronics")
                        .Sum(p => p.Price * p.Stock);
            var invent2 = products.Where(p => p.Category == "Furniture")
                        .Sum(p => p.Price * p.Stock);
            Console.WriteLine(invent);
            Console.WriteLine(invent2);

            //Find the cheapest product in Electronics
            //AND the cheapest in Furniture using MinBy.
            //Print name and price for each
            var cheap = products.Where(p => p.Category == "Electronics")
                        .First()
                        ;

            Console.WriteLine(cheap);

        }
    }

}
