using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace day1
{
    internal class Program
    {
        // class

        internal class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }



        static void Main(string[] args)
        {
            List<Item> cart = new List<Item>();
            int Choice;
            do
            {
                Console.WriteLine("\n=== Simple Shopping Cart ===");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Clear Cart");
                Console.WriteLine("5. Quit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out Choice))
                {
                    Console.WriteLine("Invalid Choice");
                    continue;
                }
                switch (Choice)
                {


                    case 1: // Add Item
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();

                        double price;
                        bool validPrice;
                        do
                        {
                            Console.Write("Enter item price: ");
                            validPrice = double.TryParse(Console.ReadLine(), out price);
                            if (!validPrice || price < 0)
                                Console.WriteLine("Invalid price. Enter a positive number.");
                        } while (!validPrice || price < 0);

                        cart.Add(new Item { Name = name, Price = price });
                        Console.WriteLine($"Added {name} - ${price:F2}");

                        break;
                    case 2: // Remove Item
                        Console.Write("Enter item name to remove: ");
                        string removeName = Console.ReadLine();

                        Item removable = cart.FirstOrDefault(i => i.Name.Equals(removeName, StringComparison.OrdinalIgnoreCase));

                        if (removable != null)
                        {
                            cart.Remove(removable);
                            Console.WriteLine($"Removed {removeName} from cart.");
                        }
                        else
                        {
                            Console.WriteLine($"Item '{removeName}' not found in cart.");
                        }
                        break;
                    case 3: // View Cart
                        if (cart.Count == 0)
                        {
                            Console.WriteLine("Cart is empty.");
                        }
                        else
                        {
                            Console.WriteLine("\nItems in Cart:");
                            foreach (var item in cart.OrderBy(i => i.Name))
                            {
                                Console.WriteLine($"{item.Name} - ${item.Price:F2}");
                            }
                            Console.WriteLine($"Total Price: ${cart.Sum(i => i.Price):F2}");
                        }
                        break;
                    case 4: // Clear Cart
                        cart.Clear();
                        Console.WriteLine("Cart has been cleared.");
                        break;

                    case 5: // Quit
                        Console.WriteLine("Thank you for shopping! Goodbye.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;

                }
            }
            while (Choice != 5);

        }


    }
}
