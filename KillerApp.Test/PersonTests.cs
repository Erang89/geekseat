using System.Collections.Generic;
using Xunit;

namespace KillerApp.Test
{
    public class PersonTests
    {

        // Test Born Year of Person
        [Fact]
        public void BornYear_Test()
        {
            // Arrage
            Person person = new Person()
            {
                AgeOfDeath = 10,
                YearOfDeath = 12
            };
            int expected = 2;

            // Act
            int bornYear = person.BornOn;

            // Assert
            Assert.Equal(expected, bornYear);
        }



    }
}
