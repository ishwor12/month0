using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public Customer(int id,string name, string city)
    {
        Id = id;
        Name = name;
        City = city;

    }
}
public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public Order(int Id, int CustomerId, string ProductName,int Quantity,DateTime Date)
    {
        this.Id = Id;
        this.CustomerId = CustomerId;
        this.ProductName = ProductName;
        this.Quantity = Quantity;
        this.Date = Date;

    }
}
internal class Program
{
    public static void Main(string[] args)
    {
        var products = new List<Product>
{
    new("Laptop",     "Electronics", 1200m,  5),
    new("Phone",      "Electronics",  800m, 12),
    new("Desk",       "Furniture",    350m,  3),
    new("Chair",      "Furniture",    150m,  8),
    new("Headphones", "Electronics",   90m, 20),
    new("Monitor",    "Electronics",  450m,  0),
    new("Bookshelf",  "Furniture",    200m,  6),
};
        var customers = new List<Customer>
{
    new(1, "Alice",   "Auckland"),
    new(2, "Bob",     "Wellington"),
    new(3, "Carol",   "Auckland"),
    new(4, "Dave",    "Christchurch"),
    new(5, "Eve",     "Wellington"),
};
        var orders = new List<Order>
{
    new(1, 1, "Laptop",     1, new DateTime(2024, 1, 15)),
    new(2, 1, "Headphones", 2, new DateTime(2024, 1, 20)),
    new(3, 2, "Phone",      1, new DateTime(2024, 2, 5)),
    new(4, 3, "Desk",       1, new DateTime(2024, 2, 10)),
    new(5, 3, "Chair",      2, new DateTime(2024, 2, 10)),
    new(6, 4, "Monitor",    1, new DateTime(2024, 3, 1)),
    new(7, 1, "Desk",       1, new DateTime(2024, 3, 5)),
};

        //  GroupBy — Split a collection into groups


        var category = products.GroupBy(p => p.Category);
        foreach (var item in category)
        {
            Console.WriteLine($"{item.Key}");
        }
        //anynomous type or class
        var summary = products.GroupBy(x => x.Category)
        .Select(s => new
        {
            category = s.Key,
            count = s.Count(),
            totalValue = s.Sum(p => p.Price * p.Stock),
            mostExpensive = s.MaxBy(p => p.Price).Name,
            AvgPrice = s.Average(p => p.Price)

        });
        foreach (var s in summary)
        {
            Console.WriteLine($"{s.category}: {s.count} products, " +
                       $"avg {s.AvgPrice:C}, " +
                       $"stock value {s.totalValue:C}, " + "\n"+
                       $"Expensive item in d category is: {s.mostExpensive}");
        }


        var grouped = products.GroupBy(p => new { p.Category, InStock = p.Stock > 0 });
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key.Category} - " +
                              $"{(group.Key.InStock ? "In stock" : "Out of stock")}: " +
                              $"{group.Count()} products"
                              );
        }

    }
}

















