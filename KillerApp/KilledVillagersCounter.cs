using System.Collections.Generic;
using System.Linq;

namespace KillerApp
{
    public interface IKilledVillagersCounter
    {
        string ErrorMessage { get; }
        decimal AverageNumberKilledOnBirthYearOfPeople(List<Person> persons);
        int TotalKilledOnYear(int year);
    }



    public class KilledVillagersCounter : IKilledVillagersCounter
    {

        public string ErrorMessage { get; private set; }


        /// <summary>
        /// This function is count the additional target to be killed on particular year
        /// parm year start from 1; 1 is indicate the first year
        /// </summary>
        /// <param name="year">year</param>
        /// <returns></returns>
        private int GetAdditionalNumberOnYear(int year)
            => GetAdditionalNumberOnYearByIndex(year - 1);



        /// <summary>
        /// This function is count the additional target to be killed on particular year
        /// parm year start from 0; 0 is indicate the first year
        /// </summary>
        /// <param name="year">year</param>
        /// <returns></returns>
        private int GetAdditionalNumberOnYearByIndex(int yearIndex)
        {
            if (yearIndex < 0) return 0;
            if (yearIndex == 0) return 1;

            // last year total killed
            int lastYearTotalKild = GetAdditionalNumberOnYearByIndex(yearIndex - 1);

            // second year before total killed
            int secondYearBeforelastYearTotalKild = GetAdditionalNumberOnYearByIndex(yearIndex - 2);

            // additional target on current year
            int currentAddationalTarget = lastYearTotalKild + secondYearBeforelastYearTotalKild;

            return currentAddationalTarget;

        }



        /// <summary>
        /// This function return the total of villager killed on the given year
        /// parm year start from 1. 1 indicate the first year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int TotalKilledOnYear(int year)
        {
            List<int> ListOfVictimEveryYear = new List<int>();

            for (int i = 1; i <= year; i++)
            {
                ListOfVictimEveryYear.Add(GetAdditionalNumberOnYear(i));
            }

            return ListOfVictimEveryYear.Sum();
        }




        public decimal AverageNumberKilledOnBirthYearOfPeople(List<Person> persons)
        {
            // validate
            if (IsVictimDataValid(persons) == false) return -1;


            // Find the total killed on year depand on given person data. (born year of persons)
            List<int> ListVictimsOnBirthYear =
                persons.Select(x => TotalKilledOnYear(x.BornOn)).ToList();

            // count and return average number
            return ListVictimsOnBirthYear.Sum(x => (decimal)x ) / ListVictimsOnBirthYear.Count;
        }



        // Validate the given person
        private bool IsVictimDataValid(List<Person> persons)
        {
            foreach (Person person in persons)
            {

                // validate Age
                if (person.AgeOfDeath < 0)
                {
                    ErrorMessage = $"The Age of {person.Name} is invalid";
                    return false;
                }
            }

            return true;
        }


    }
}
