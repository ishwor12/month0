using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    internal class Program
    {
        //(1) for loop: print numbers 1 to 20, skip even //numbers using continue.
        //(2) while loop: keep asking user for a password until they
        //type 'secret123'.
        //(3) do-while: show a menu(1 = add, 2 = subtract, 3 = quit), keep running
        //until user types 3.
        /// <summary>
        /// /(4) foreach: loop through an array of 5 city names and print each.
        /// </summary>
        /// <param name="args"></param>


        static void Main(string[] args)
        {

            int choice;
            double num1 = 0, num2 = 0;
            bool isValid;

            do
            {

                Console.WriteLine("\n=== Smart Calculator ===");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Modulus");
                Console.WriteLine("6. Quit");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }
                if (choice >= 1 && choice <= 5)
                {
                    // Input first number
                    do
                    {
                        Console.Write("Enter first number: ");
                        isValid = double.TryParse(Console.ReadLine(), out num1);
                        if (!isValid)
                            Console.WriteLine("Invalid input. Try again.");
                    } while (!isValid);

                    do
                    {
                        Console.Write("Enter second number: ");
                        isValid = double.TryParse(Console.ReadLine(), out num2);
                        if (!isValid)
                            Console.WriteLine("Invalid input. Try again.");
                    } while (!isValid);


                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Result: " + (num1 + num2));
                        break;

                    case 2:
                        Console.WriteLine("Result: " + (num1 - num2));
                        break;

                    case 3:
                        Console.WriteLine("Result: " + (num1 * num2));
                        break;

                    case 4:
                        if (num2 == 0)
                            Console.WriteLine("Error: Cannot divide by zero.");
                        else
                            Console.WriteLine("Result: " + (num1 / num2));
                        break;
                    case 5:
                        if (num2 == 0)
                            Console.WriteLine("Error: Cannot perform modulus with zero.");
                        else
                            Console.WriteLine("Result: " + (num1 % num2));
                        break;
                }
            } while (choice != 6);

            Console.WriteLine("Calculator closed. Goodbye!");





        }
    }
}
