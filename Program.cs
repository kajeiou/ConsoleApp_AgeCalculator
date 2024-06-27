using System;

namespace AgeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your full name: ");
            string fullName = Console.ReadLine();

            DateTime birthDate;
            while (true)
            {
                Console.Write("Please enter your birth date (DD/MM/YYYY): ");
                string birthDateString = Console.ReadLine();

                if (DateTime.TryParse(birthDateString, out birthDate))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid birth date format. Please try again.");
                }
            }

            int age = CalculateAge(birthDate);
            DateTime nextBirthday = GetNextBirthday(birthDate);
            int daysUntilNextBirthday = (nextBirthday - DateTime.Today).Days;

            Console.WriteLine($"Hello {fullName}, you are {age} years old.");

            if (daysUntilNextBirthday == 0)
            {
                Console.WriteLine("Happy Birthday!");
            }
            else
            {
                Console.WriteLine($"There are {daysUntilNextBirthday} days left until you turn {age + 1}.");
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

        static DateTime GetNextBirthday(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            DateTime nextBirthday = new DateTime(today.Year, birthDate.Month, birthDate.Day);

            if (nextBirthday < today)
            {
                nextBirthday = nextBirthday.AddYears(1);
            }

            return nextBirthday;
        }
    }
}
