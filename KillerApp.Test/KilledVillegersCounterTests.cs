using System.Collections.Generic;
using Xunit;

namespace KillerApp.Test
{
    public class KilledVillegersCounterTests
    {


        [Fact]
        public void TotalKilledOnYear_Test_Count5thYear()
        {
            // Arrage
            IKilledVillagersCounter killedCounter = new KilledVillagersCounter();
            int expected = 12;

            // Act
            int killedOn5thYear = killedCounter.TotalKilledOnYear(5);

            // Assert
            Assert.Equal(expected, killedOn5thYear);
        }



        [Fact]
        public void TotalKilledOnYear_Test_Count3thYear()
        {

            // Arrage
            IKilledVillagersCounter killedCounter = new KilledVillagersCounter();
            int expected = 4;

            // Act
            int killedOn5thYear = killedCounter.TotalKilledOnYear(3);

            // Assert
            Assert.Equal(expected, killedOn5thYear);

        }



        [Fact]
        public void TotalKilledOnYear_Test_Count4thYear()
        {

            // Arrage
            IKilledVillagersCounter killedCounter = new KilledVillagersCounter();
            int expected = 7;

            // Act
            int killedOn5thYear = killedCounter.TotalKilledOnYear(4);

            // Assert
            Assert.Equal(expected, killedOn5thYear);

        }






        /// <summary>
        /// Test Averages
        /// </summary>
        [Fact]
        public void AverageNumberKilledOnBirthYearOfPeople_Year2And7()
        {

            // Arrage
            IKilledVillagersCounter killedCounter = new KilledVillagersCounter();
            decimal expected = (decimal)4.5;
            var persons = new List<Person>()
            {
                new Person{AgeOfDeath = 10, YearOfDeath = 12, Name = "Person A" },
                new Person{AgeOfDeath = 13, YearOfDeath = 17, Name = "Person B" },
            };

            // Act
            decimal average = killedCounter.AverageNumberKilledOnBirthYearOfPeople(persons);

            // Assert
            Assert.Equal(expected, average);
        }




        /// <summary>
        /// Test Average Villagers Killed on birth year of person
        /// But the AgeOfDate of person is invalid
        /// </summary>
        [Fact]
        public void AverageNumberKilledOnBirthYearOfPeople_InvalidAge()
        {

            // Arrage
            IKilledVillagersCounter killedCounter = new KilledVillagersCounter();
            decimal expected = -1;
            var persons = new List<Person>()
            {
                new Person{AgeOfDeath = -2, YearOfDeath = 12, Name = "Person A" },
                new Person{AgeOfDeath = 13, YearOfDeath = 17, Name = "Person B" },
            };

            // Act
            decimal average = killedCounter.AverageNumberKilledOnBirthYearOfPeople(persons);

            // Assert
            Assert.Equal(expected, average);
        }


    }
}
