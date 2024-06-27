using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Please enter your birth date (MM/DD/YYYY): ");
            string birthDateString = Console.ReadLine();

            if (DateTime.TryParse(birthDateString, out DateTime birthDate))
            {
                int age = CalculateAge(birthDate);

                Console.WriteLine($"Hello {fullName}, you are {age} years old.");
            }
            else
            {
                Console.WriteLine("Invalid birth date format. Please try again.");
            }
        }

        static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
