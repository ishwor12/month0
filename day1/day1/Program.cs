using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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
        //        Console app: Build a MathHelper class with these methods: • int Add(int a, int b) •
        //double Divide(double a, double b) — returns 0 if b==0 • bool IsEven(int n) • int Max(int
        //a, int b) • int Max(int a, int b, int c) — overload • string Repeat(string s, int times = 3) —
        //optional param Call every method from Main and print the results

        
        internal int Add(int value1, int value2)
        {
            
            return  value1 + value2;
        }
        public double Divide(double a, double b)
        {
            if (b == 0)
                return 0;
            return a / b;
        }



        static void Main(string[] args)
        {
            Program p = new Program();
           
                Console.WriteLine("Enter Value 1");
            p.Add(4, 5);

            int[] numbers = new int[5];

            Console.WriteLine("Enter 5 numbers:");

            for (int i = 0; i < numbers.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter number {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out numbers[i]))
                        break;
                    else
                        Console.WriteLine("Invalid input. Try again.");
                }
            }
            Console.WriteLine("Smallest: " + numbers.Min());
            Console.WriteLine("Largest: " + numbers.Max());
            Console.WriteLine("Average: " + numbers.Average());

            var sorted = numbers.OrderBy(n => n).ToArray();
            Console.WriteLine("Sorted: " + string.Join(", ", sorted));
            var dsorted = numbers.OrderByDescending(n => n).ToArray();
            Console.WriteLine("Desc - Sorted: " + string.Join(", ", dsorted));

            Dictionary<string, List<string>> Entries = new Dictionary<string, List<string>>();
            Entries.Add("Ishwor",new List<string> { "Work Hard","Learn Everyday","Get Job"});
            Entries.Add("Sabi",new List<string> { "Work Smart","Learn English","Improve Skill"});
            Entries.Add("Ishita",new List<string> { "Study","No Mobile","No Sweets"});

            foreach (var item in Entries)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(string.Join(", ", item.Value));
            }
        
        }


    }
}
