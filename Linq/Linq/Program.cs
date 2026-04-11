using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    // Exercise 1: Filter a number array — return all numbers greater than 10
  //  int[] nums = { 3, 15, 7, 22, 10, 1, 18 };

    // Exercise 2: Select strings from a list that start with the letter "A"
   // List<string> names = new() { "Alice", "Bob", "Anna", "Charlie", "Alex" };

    // Exercise 3: Write the same query twice — once in query syntax, once in method syntax
    
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 15, 7, 22, 10, 1, 18, 20, 16, 45, 8, 2, 11 };

            var num = numbers.Where(n => n > 10);

            var nm = from n in num
                     where n > 3
                     select n;

            foreach (var item in num)
            {
                Console.WriteLine(item);
            }

            List<string> names = new List<string> { "Alice", "bob", "Aana", "Eve", "Ishwor", "Sabita", "AakashVai" };

            var nam = from n in names
                      where n.Contains("A")
                      select n;
            foreach (var item in nam)
            {
                Console.WriteLine(item);
            }
            var name = names.FirstOrDefault();
            foreach (var item in name)
            {
                Console.WriteLine(name);
            }

       // Query: from the list of names, select those whose length is more than 4 characters


       var namesx = from n in names
                         where n.Count() > 4

                         select n;
            foreach (var item in namesx)
            {
                Console.WriteLine(item);
            }

            var numx = names.Where(x => x.Contains("b"));
            foreach (var item in numx)
            {
                Console.WriteLine(item);
            }


        }
    }
}
