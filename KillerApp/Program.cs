using System;
using System.Collections.Generic;

namespace KillerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IKilledVillagersCounter victimCounter = new KilledVillagersCounter();

            // Show total killed per year
            Console.WriteLine("Total Killed each year:");
            Console.WriteLine("----------------------------");
            for (int i = 1; i <= 10; i++)
            {
                string year = i == 1 ? "1st" : (i == 2 ? "2nd" : $"{i}th");
                int totalKilled = victimCounter.TotalKilledOnYear(i);
                Console.WriteLine($"{year} she kills : {totalKilled} villager{(totalKilled > 1 ? "s" : "")}");
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Average Killed on born year of Persons:");
            Console.WriteLine("--------------------------------------");



            // Show average 
            List<Person> People = new List<Person>()
            {
                new Person{AgeOfDeath = 10, YearOfDeath = 12, Name = "Person A" },
                new Person{AgeOfDeath = 13, YearOfDeath = 17, Name = "Person B" },
            };

            foreach (var person in People)
                Console.WriteLine($"Name: {person.Name}, " +
                    $"Born on: {person.BornOn}, " +
                    $"Killed on: {person.YearOfDeath}, " +
                    $"Age of Death: {person.AgeOfDeath}");

            Console.WriteLine("");
            Console.WriteLine($"Average Killed on born year: {victimCounter.AverageNumberKilledOnBirthYearOfPeople(People)}");
            Console.WriteLine(victimCounter.ErrorMessage);

            Console.ReadLine();
        }
    }
}
