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
— controllers and services talk to IProductRepository, not ProductRepository directly