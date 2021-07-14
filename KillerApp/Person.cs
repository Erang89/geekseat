using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillerApp
{
   public class Person
    {
        public string Name { get; set; }
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }

        // This Property count the born year of person,
        // using the AgeOfDeath and YearOfDeath Property Value
        public int BornOn => YearOfDeath - AgeOfDeath;
    }
}
