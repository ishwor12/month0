using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(string name, string category, decimal price, int stock)
    {
        Name = name;
        Category = category;
        Price = price;
        Stock = stock;
    }


}
internal class Program
{
    public static void Main(string[] args)
    {
        var products = new List<Product>
{
    new("Laptop",     "Electronics", 1200m, 5),
    new("Phone",      "Electronics",  800m, 12),
    new("Desk",       "Furniture",    350m, 3),
    new("Chair",      "Furniture",    150m, 8),
    new("Headphones", "Electronics",   90m, 20),
    new("Monitor",    "Electronics",  450m, 0),
};


        // Project all products into a new anonymous
        // type: { Name, Category, StockValue(Price×Stock), IsExpensive(Price > 500) }.
        // Print all fields for each product.
        var xyz = products
            .Select(p => new
            {
                p.Name,
                p.Category,
                p.Stock,
                p.Price,
            }).MinBy(p => p.Price);
        Console.WriteLine($"{xyz.Name} {xyz.Price}");

        var data = SearchProducts(products, "Laptop", null, null);
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Name},{item.Category},{item.Price}");
        }
        // 17.Category summary report
        //Without GroupBy, produce a console report for each distinct category
        //showing: category name, product count, total stock value,
        //and most expensive product name.




        var cat = products.Select(p => p.Category).Distinct();

        foreach (var item in cat)
        {
            var exp = products.Where(p => p.Category == item)
                .MaxBy(m => m.Price);
            var count = products.Count(p => p.Category == item);
            var totalValue = products.Where(p => p.Category == item)
                             .Sum(p => p.Price * p.Stock);
            Console.WriteLine($"--- {item} ---");
            Console.WriteLine($"  Count      : {count}");
            Console.WriteLine($"  Stock value: {totalValue:C}");
            Console.WriteLine($"  Most exp.  : {exp.Name} ({exp.Price:C})");
        }


        }
    // 16. Search function
    // Write a method SearchProducts(string keyword, string? category, decimal? maxPrice)
    // that filters the list using all three optional parameters. 
    // Any null parameter means "no filter on that field".
    public static IEnumerable<Product> SearchProducts(List<Product> products, string? keyword, string? category, decimal? maxPrice)
    {
        return products.Where(p =>
        (keyword == null || p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)) &&
        (category == null || p.Category == category) &&
        (maxPrice == null || p.Price <= maxPrice)
        );

    }


}

















