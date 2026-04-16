using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int Id,string name, string category, decimal price, int stock)
    {
       this.Id = Id;
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
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public Order(int Id, int CustomerId, int ProductId,int Quantity,DateTime Date)
    {
        this.Id = Id;
        this.CustomerId = CustomerId;
        this.ProductId = ProductId;
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
    new(1,"Laptop",     "Electronics", 1200m,  5),
    new(2,"Phone",      "Electronics",  800m, 12),
    new(3,"Desk",       "Furniture",    350m,  3),
    new(4,"Chair",      "Furniture",    150m,  8),
    new(5,"Headphones", "Electronics",   90m, 20),
    new(6,"Monitor",    "Electronics",  450m,  0),
    new(7,"Bookshelf",  "Furniture",    200m,  6),
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
    new(1, 1, 1, 1, new DateTime(2024, 1, 15)),
    new(2, 1, 2, 2, new DateTime(2024, 1, 20)),
    new(3, 2, 3, 3, new DateTime(2024, 2, 5)),
    new(4, 3, 2, 2, new DateTime(2024, 2, 10)),
    new(5, 3, 3, 2, new DateTime(2024, 2, 10)),
    new(6, 4, 3, 3, new DateTime(2024, 3, 1)),
    new(7, 1, 2, 1, new DateTime(2024, 3, 5)),
};

        //   Join — Inner join between two collections

        var orderdetails = from order in orders
                           join customer in customers
                           on
                           order.CustomerId equals customer.Id
                           select new
                           {
                               Name= customer.Name,
                               City=customer.City,
                               ProductName=order.ProductId,
                               Quantity=order.Quantity,
                              
                           };
        foreach (var o in orderdetails)
        {
            Console.WriteLine($"{o.Name} ({o.City}) ordered {o.Quantity}x {o.ProductName}");
        }


        Console.WriteLine("!!!!!!!!!!!!!!!________________!!!!!!!!!!!!!!!!");
        // join to get order total price

        var total = from product in products
                    join
                    order in orders
                    on product.Id equals order.ProductId
                    where order.ProductId == 1
                    select new
                    {
                        Name = product.Name,
                        Category = product.Category,
                        quantity = order.Quantity,
                        price = order.Quantity * product.Price,

                    };
        foreach (var item in total)
        {

            Console.WriteLine($"You have ordered {item.Name} of category {item.Category}.\n");
            Console.WriteLine($"The price is{item.price} and the quantity is{item.quantity}. \n");

        }


    }
}

















