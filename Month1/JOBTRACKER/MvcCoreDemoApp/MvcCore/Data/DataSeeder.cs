using Microsoft.EntityFrameworkCore;
using MvcCore.Models;
using MvcCore.Models.Enums;

namespace MvcCore.Data
{
    public class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)

        {
            // Already data is seeded — don't run again skip for AllSkip IFAny. 
           if (context.Categories.Any()) return;

            var categories = new List<Category>
            {
                new() { Name = "Electronics",    Description = "Electronic devices and accessories" },
                new() { Name = "Office Supplies", Description = "Stationery and office equipment" },
                new() { Name = "Furniture",       Description = "Office and home furniture" },
                new() { Name = "Clothing",        Description = "Apparel and accessories" },
                new() { Name = "Food & Beverage", Description = "Consumable goods and drinks" }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var suppliers = new List<Supplier>
            {
                new() { Name = "TechWorld NZ",     ContactName = "James Patel",   Email = "james@techworld.co.nz" },
                new() { Name = "OfficeHub",        ContactName = "Sarah Kim",     Email = "sarah@officehub.co.nz" },
                new() { Name = "FurniturePlus",    ContactName = "Mike Thompson", Email = "mike@furnitureplus.co.nz" },
                new() { Name = "StyleCo",          ContactName = "Emma Wilson",   Email = "emma@styleco.co.nz" },
                new() { Name = "FreshSupplies NZ", ContactName = "Raj Sharma",    Email = "raj@freshsupplies.co.nz" }
            };

            await context.Suppliers.AddRangeAsync(suppliers);
            await context.SaveChangesAsync();


            var products = new List<Product>
            {
                // Electronics
                new() { Name = "Laptop Pro 15",      SKU = "ELEC-001", Price = 1899.99m, StockQty = 25,  LowStockThreshold = 5,  CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },
                new() { Name = "Wireless Mouse",      SKU = "ELEC-002", Price = 49.99m,  StockQty = 3,   LowStockThreshold = 10, CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },
                new() { Name = "USB-C Hub",           SKU = "ELEC-003", Price = 79.99m,  StockQty = 40,  LowStockThreshold = 10, CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },
                new() { Name = "Mechanical Keyboard", SKU = "ELEC-004", Price = 149.99m, StockQty = 8,   LowStockThreshold = 10, CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },
                new() { Name = "Monitor 27inch",      SKU = "ELEC-005", Price = 599.99m, StockQty = 2,   LowStockThreshold = 5,  CategoryId = categories[0].Id, SupplierId = suppliers[0].Id },

                // Office Supplies
                new() { Name = "A4 Paper Ream",       SKU = "OFFC-001", Price = 12.99m,  StockQty = 200, LowStockThreshold = 50, CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },
                new() { Name = "Ballpoint Pens 12pk", SKU = "OFFC-002", Price = 8.99m,   StockQty = 5,   LowStockThreshold = 20, CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },
                new() { Name = "Stapler Heavy Duty",  SKU = "OFFC-003", Price = 24.99m,  StockQty = 30,  LowStockThreshold = 10, CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },
                new() { Name = "Whiteboard A1",       SKU = "OFFC-004", Price = 89.99m,  StockQty = 4,   LowStockThreshold = 5,  CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },
                new() { Name = "File Cabinet 4-Draw", SKU = "OFFC-005", Price = 299.99m, StockQty = 12,  LowStockThreshold = 3,  CategoryId = categories[1].Id, SupplierId = suppliers[1].Id },

                // Furniture
                new() { Name = "Ergonomic Chair",     SKU = "FURN-001", Price = 499.99m, StockQty = 10,  LowStockThreshold = 3,  CategoryId = categories[2].Id, SupplierId = suppliers[2].Id },
                new() { Name = "Standing Desk",       SKU = "FURN-002", Price = 799.99m, StockQty = 2,   LowStockThreshold = 3,  CategoryId = categories[2].Id, SupplierId = suppliers[2].Id },
                new() { Name = "Bookshelf 5-Tier",    SKU = "FURN-003", Price = 199.99m, StockQty = 7,   LowStockThreshold = 3,  CategoryId = categories[2].Id, SupplierId = suppliers[2].Id },
                new() { Name = "Meeting Table",       SKU = "FURN-004", Price = 1299.99m,StockQty = 1,   LowStockThreshold = 2,  CategoryId = categories[2].Id, SupplierId = suppliers[2].Id },
                new() { Name = "Locker Unit 6-Door",  SKU = "FURN-005", Price = 449.99m, StockQty = 6,   LowStockThreshold = 2,  CategoryId = categories[2].Id, SupplierId = suppliers[2].Id },

                // Clothing
                new() { Name = "Hi-Vis Vest",         SKU = "CLTH-001", Price = 19.99m,  StockQty = 3,   LowStockThreshold = 15, CategoryId = categories[3].Id, SupplierId = suppliers[3].Id },
                new() { Name = "Work Boots Size 10",  SKU = "CLTH-002", Price = 129.99m, StockQty = 22,  LowStockThreshold = 5,  CategoryId = categories[3].Id, SupplierId = suppliers[3].Id },
                new() { Name = "Safety Gloves L",     SKU = "CLTH-003", Price = 14.99m,  StockQty = 4,   LowStockThreshold = 20, CategoryId = categories[3].Id, SupplierId = suppliers[3].Id },

                // Food & Beverage
                new() { Name = "Coffee Beans 1kg",    SKU = "FOOD-001", Price = 29.99m,  StockQty = 45,  LowStockThreshold = 10, CategoryId = categories[4].Id, SupplierId = suppliers[4].Id },
                new() { Name = "Water Bottles 24pk",  SKU = "FOOD-002", Price = 18.99m,  StockQty = 9,   LowStockThreshold = 10, CategoryId = categories[4].Id, SupplierId = suppliers[4].Id }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // ── 4. Customers ───────────────────────────────────────
            var customers = new List<Customer>
            {
                new() { Name = "Auckland City Council", Email = "procurement@aucklandcc.govt.nz", Phone = "09 301 0101" },
                new() { Name = "Hamilton Tech Ltd",     Email = "orders@hamiltontech.co.nz",      Phone = "07 838 1234" },
                new() { Name = "Wellington Office Pro", Email = "buying@wellingtonoffice.co.nz",  Phone = "04 472 5678" },
                new() { Name = "Christchurch Builds",   Email = "supply@chchbuilds.co.nz",        Phone = "03 366 9012" },
                new() { Name = "Tauranga Supplies Co",  Email = "info@taurangasupplies.co.nz",    Phone = "07 578 3456" },
                new() { Name = "Dunedin University",    Email = "procurement@otago.ac.nz",         Phone = "03 479 1100" },
                new() { Name = "Palmerston North Hub",  Email = "orders@pnhub.co.nz",             Phone = "06 355 7890" },
                new() { Name = "Rotorua Retail Group",  Email = "supply@rotoruaretail.co.nz",     Phone = "07 348 2345" }
            };

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();

            // ── 5. Sales Orders + Items ────────────────────────────
            var orders = new List<SalesOrder>
            {
                // January
                new()
                {
                    CustomerId = customers[0].Id,
                    OrderDate  = new DateTime(2025, 1, 5),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[0].Id,  Quantity = 2, UnitPrice = products[0].Price },
                        new() { ProductId = products[3].Id,  Quantity = 3, UnitPrice = products[3].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[1].Id,
                    OrderDate  = new DateTime(2025, 1, 15),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[5].Id,  Quantity = 10, UnitPrice = products[5].Price },
                        new() { ProductId = products[6].Id,  Quantity = 5,  UnitPrice = products[6].Price }
                    }
                },

                // February
                new()
                {
                    CustomerId = customers[2].Id,
                    OrderDate  = new DateTime(2025, 2, 3),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[10].Id, Quantity = 4, UnitPrice = products[10].Price },
                        new() { ProductId = products[11].Id, Quantity = 2, UnitPrice = products[11].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[3].Id,
                    OrderDate  = new DateTime(2025, 2, 20),
                    Status     = OrderStatus.Cancelled,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[15].Id, Quantity = 20, UnitPrice = products[15].Price }
                    }
                },

                // March
                new()
                {
                    CustomerId = customers[4].Id,
                    OrderDate  = new DateTime(2025, 3, 8),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[18].Id, Quantity = 5,  UnitPrice = products[18].Price },
                        new() { ProductId = products[19].Id, Quantity = 10, UnitPrice = products[19].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[5].Id,
                    OrderDate  = new DateTime(2025, 3, 22),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[1].Id,  Quantity = 8, UnitPrice = products[1].Price },
                        new() { ProductId = products[2].Id,  Quantity = 6, UnitPrice = products[2].Price },
                        new() { ProductId = products[4].Id,  Quantity = 2, UnitPrice = products[4].Price }
                    }
                },

                // April
                new()
                {
                    CustomerId = customers[6].Id,
                    OrderDate  = new DateTime(2025, 4, 10),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[7].Id,  Quantity = 3, UnitPrice = products[7].Price },
                        new() { ProductId = products[8].Id,  Quantity = 2, UnitPrice = products[8].Price },
                        new() { ProductId = products[9].Id,  Quantity = 1, UnitPrice = products[9].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[7].Id,
                    OrderDate  = new DateTime(2025, 4, 28),
                    Status     = OrderStatus.Pending,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[12].Id, Quantity = 2, UnitPrice = products[12].Price },
                        new() { ProductId = products[13].Id, Quantity = 1, UnitPrice = products[13].Price }
                    }
                },

                // May
                new()
                {
                    CustomerId = customers[0].Id,
                    OrderDate  = new DateTime(2025, 5, 5),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[0].Id,  Quantity = 3, UnitPrice = products[0].Price },
                        new() { ProductId = products[2].Id,  Quantity = 5, UnitPrice = products[2].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[1].Id,
                    OrderDate  = new DateTime(2025, 5, 18),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[16].Id, Quantity = 4, UnitPrice = products[16].Price },
                        new() { ProductId = products[17].Id, Quantity = 6, UnitPrice = products[17].Price }
                    }
                },

                // June
                new()
                {
                    CustomerId = customers[2].Id,
                    OrderDate  = new DateTime(2025, 6, 2),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[5].Id,  Quantity = 20, UnitPrice = products[5].Price },
                        new() { ProductId = products[6].Id,  Quantity = 15, UnitPrice = products[6].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[3].Id,
                    OrderDate  = new DateTime(2025, 6, 19),
                    Status     = OrderStatus.Pending,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[10].Id, Quantity = 2, UnitPrice = products[10].Price }
                    }
                },

                // July
                new()
                {
                    CustomerId = customers[4].Id,
                    OrderDate  = new DateTime(2025, 7, 7),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[18].Id, Quantity = 8,  UnitPrice = products[18].Price },
                        new() { ProductId = products[19].Id, Quantity = 12, UnitPrice = products[19].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[5].Id,
                    OrderDate  = new DateTime(2025, 7, 25),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[3].Id,  Quantity = 5, UnitPrice = products[3].Price },
                        new() { ProductId = products[4].Id,  Quantity = 3, UnitPrice = products[4].Price }
                    }
                },

                // August
                new()
                {
                    CustomerId = customers[6].Id,
                    OrderDate  = new DateTime(2025, 8, 12),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[11].Id, Quantity = 1, UnitPrice = products[11].Price },
                        new() { ProductId = products[14].Id, Quantity = 3, UnitPrice = products[14].Price }
                    }
                },

                // September
                new()
                {
                    CustomerId = customers[7].Id,
                    OrderDate  = new DateTime(2025, 9, 3),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[1].Id,  Quantity = 10, UnitPrice = products[1].Price },
                        new() { ProductId = products[6].Id,  Quantity = 8,  UnitPrice = products[6].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[0].Id,
                    OrderDate  = new DateTime(2025, 9, 21),
                    Status     = OrderStatus.Cancelled,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[13].Id, Quantity = 2, UnitPrice = products[13].Price }
                    }
                },

                // October
                new()
                {
                    CustomerId = customers[1].Id,
                    OrderDate  = new DateTime(2025, 10, 8),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[0].Id,  Quantity = 5, UnitPrice = products[0].Price },
                        new() { ProductId = products[2].Id,  Quantity = 8, UnitPrice = products[2].Price },
                        new() { ProductId = products[3].Id,  Quantity = 4, UnitPrice = products[3].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[2].Id,
                    OrderDate  = new DateTime(2025, 10, 29),
                    Status     = OrderStatus.Pending,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[15].Id, Quantity = 10, UnitPrice = products[15].Price },
                        new() { ProductId = products[16].Id, Quantity = 5,  UnitPrice = products[16].Price }
                    }
                },

                // November
                new()
                {
                    CustomerId = customers[3].Id,
                    OrderDate  = new DateTime(2025, 11, 11),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[18].Id, Quantity = 15, UnitPrice = products[18].Price },
                        new() { ProductId = products[19].Id, Quantity = 20, UnitPrice = products[19].Price }
                    }
                },

                // December
                new()
                {
                    CustomerId = customers[4].Id,
                    OrderDate  = new DateTime(2025, 12, 5),
                    Status     = OrderStatus.Confirmed,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[0].Id,  Quantity = 4, UnitPrice = products[0].Price },
                        new() { ProductId = products[10].Id, Quantity = 6, UnitPrice = products[10].Price }
                    }
                },
                new()
                {
                    CustomerId = customers[5].Id,
                    OrderDate  = new DateTime(2025, 12, 20),
                    Status     = OrderStatus.Pending,
                    Items      = new List<SalesOrderItem>
                    {
                        new() { ProductId = products[5].Id,  Quantity = 30, UnitPrice = products[5].Price },
                        new() { ProductId = products[7].Id,  Quantity = 10, UnitPrice = products[7].Price }
                    }
                }
            };

            await context.SalesOrders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }
    }
}