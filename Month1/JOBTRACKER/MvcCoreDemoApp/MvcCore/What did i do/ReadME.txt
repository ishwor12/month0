day 1: Learning 

-> Architecture Setup Repository:
What did i Uderstand:
why do i have repo n service layer as i have same structure in both ??
 Service Layer  ||  Repository Layer  (Repository — Only Talks to the Database)
  "WHAT to do"   ||   "HOW to get data"
  Business Logic Here ||   Data Access Only Here

CascadeDelete:

Day 2: 
Generic Repository:
type independant and type safety


-- everything always depend on the Interface, not the class 
— controllers and services talk to IProductRepository, not ProductRepository directly.

Day 3:
GetAllAsync   →  "Give me ALL files"   → returns a stack of files
GetByIdAsync  →  "Find file #5"        → returns that file OR "not found"
CreateAsync   →  "File this document"  → you just nod, nothing handed back
UpdateAsync   →  "Update this record"  → you just nod, nothing handed back.

If search is empty → get ALL products, otherwise → get only products that match the search keyword.
ternary operator.? something : something
like if something else something.

!!!!!!!!!!!!!!!!!!!!------------------------------------!!!!!!!!!!!!!!!
var viewModels = orders.Select(o => new OrderViewModel
{
    Id           = o.Id,
    OrderDate    = o.OrderDate,
    Status       = o.Status,
    CustomerId   = o.CustomerId,
    CustomerName = o.Customer?.Name,      // ← pulling from navigation property
    Items        = o.Items?.Select(i => new OrderItemViewModel  // ← nested mapping
    {
        ProductId   = i.ProductId,
        ProductName = i.Product?.Name,
        Quantity    = i.Quantity,
        UnitPrice   = i.UnitPrice
    }).ToList() ?? new()                  // ← if Items is null → empty list
});


---------------------VS--VS---VS---VS---VS---VS-----VS--------------------
var orders = await _orderService.GetAllOrdersAsync();
return View(orders);


why ? Why ? why ?

1st one is doing : orders (EF Entity — what DB knows)
    ↓  .Select() — loop every order
viewModels (ViewModel — what View needs)

AND
2nd Code Block is :: Skipping the mapping — passing raw entity to view
// View is now doing this
@model IEnumerable<SalesOrder>

Problem: // Anytime if  you rename a column in DB?
// Add a new required field to SalesOrder?
// Your VIEW breaks too easily and crash


whereas: ViewModel Only exposes what view needs

// can use Automapper instead also.


// ReSTART :: Removed Identity we will add it latter

//Week 2:
