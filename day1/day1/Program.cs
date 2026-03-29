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
            for (int i = 0; i <= 20; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                continue;
            }

            while (true)
            {
                Console.WriteLine("enter password");
                var abc = Console.ReadLine();
                if (abc == "secret123")
                {
                    Console.WriteLine("Verified");
                    break;
                }
                else
                    Console.WriteLine("NOt Verified");
            }
            int choice;

            do
            {
                Console.WriteLine("enter 1 for Addition");
                Console.WriteLine("enter 2 for Sybstraction");
                Console.WriteLine("enter 3 for Exit");
                choice = int.Parse(Console.ReadLine());

            } while (choice != 3);

            string answer;

            do
            {
                Console.WriteLine("Would you like to continue (Y/N)?");
                answer = Console.ReadLine(); // Get user input

                // Optional: convert input to lowercase for simpler condition checking
                if (answer != null)
                {
                    answer = answer.ToLower();
                }

            } while (answer != "y" && answer != "n"); // Loop continues as long as input is NOT 'y' and NOT 'n'

            Console.WriteLine($"User selected: {answer}");
            Console.WriteLine("Program continues...");

            // MILESTONE PROJECT: Smart Calculator Console App Build a console calculator
            // that: • Has a menu loop(do -while): 1 = Add, 2 = Subtract, 3 = Multiply, 4 = Divide,
            // 5 = Modulus, 6 = Quit • Asks for two numbers using Console.ReadLine() with TryParse
            // validation • Handles division by zero with a clear error message
            // 

            
            double num1, num2;
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



                }
                while







    }
