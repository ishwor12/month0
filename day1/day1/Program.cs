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
        static List<Student> students = new List<Student>();

        enum Grade
        {
            A, B, C, F
        }
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime DOB { get; set; }
            public List<int> Scores { get; set; } = new List<int>();


            public Double GetAverage()
            {
                if (Scores.Count == 0)
                {
                    return 0;
                }
                return Scores.Average();
            }

            public int GetAge()
            {
                DateTime today = DateTime.Today;
                int Age = today.Year - DOB.Year;
                if (today < DOB.AddYears(Age))
                    Age--;

                return Age;
            }

        }
            static void Main(string[] args)
        {
             int choice;
            do
            {
                Console.WriteLine("\n=== Student Grade Calculator ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Score");
                Console.WriteLine("3. View All Students");
                Console.WriteLine("4. Leaderboard");
                Console.WriteLine("5. Search Student");
                Console.WriteLine("6. Quit");
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter DOB (dd/mm/yyyy): ");
                        DateTime dob;
                        while (!DateTime.TryParse(Console.ReadLine(), out dob))
                        {
                            Console.Write("Invalid date. Try again: ");
                        }
                        students.Add(new Student { Name=name, DOB=dob });
                        break;
                    case 2:
                        Console.Write("Enter student name: ");
                        string Name = Console.ReadLine().ToUpper();

                        var student = students.FirstOrDefault(s => s.Name.ToUpper() == Name);

                        if (student == null)
                        {
                            Console.WriteLine("Student not found.");
                            return;
                        }

                        Console.Write("Enter score: ");
                        int score;
                        while (!int.TryParse(Console.ReadLine(), out score) || score < 0 || score > 100)
                        {
                            Console.Write("Invalid score (0-100). Try again: ");
                        }

                        student.Scores.Add(score);
                        Console.WriteLine("Score added!");
                        break;
                    case 3:
                        if (students.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                            return;
                        }

                        var sorted = students
                            .OrderByDescending(s => s.GetAverage())
                            .ToList();

                        Console.WriteLine("\n=== Leaderboard ===");

                        for (int i = 0; i < sorted.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {sorted[i].Name} - {sorted[i].GetAverage():F2}");
                        }
                        break;
                }
            }
            while (choice != 6);
        }

    }
}
