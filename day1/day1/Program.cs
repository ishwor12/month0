using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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


        static void Main(string[] args)
        {
            Console.Write("Enter your Date of Birth (MM/DD/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                Console.WriteLine("Invalid data");
            }

            DateTime today = DateTime.Today;

            int ageYear = today.Year - dob.Year;

            int ageMnth = today.Month - dob.Month;

            int ageDays = today.Day - dob.Day;

            if (today < dob.AddYears(ageYear))
            {
                ageYear--;
            }
             if (today < dob.AddMonths(ageMnth))
            {
                ageMnth--;
            }
            if (today < dob.AddDays(ageDays))
            {
                ageDays--;
            }
            Console.WriteLine("Your Age is: " + ageYear + " years" + ageMnth + " Months" + ageDays + " Days");

            // =========================
            // (2) EVENT COUNTDOWN
            // =========================
            Console.Write("\nEnter event name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter event date (dd/mm/yyyy): ");
            DateTime eventDate;

            while (!DateTime.TryParse(Console.ReadLine(),out eventDate))
            {
                Console.Write("Invalid format. Please use dd/mm/yyyy: ");
            }
            int daysRemaining = (eventDate - today).Days;

            if (daysRemaining > 0)
                Console.WriteLine($"{eventName} is in {daysRemaining} days.");
            else if (daysRemaining == 0)
                Console.WriteLine($"{eventName} is today!");
            else
                Console.WriteLine($"{eventName} already happened {Math.Abs(daysRemaining)} days ago.");

        }

    }
}
