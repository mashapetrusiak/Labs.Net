using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Paper
    {
        public string Publication { get; set; }
        public Person Person { get; set; }
        public DateTime DateTime { get; set; }

        public Paper(string publication, Person person, DateTime dateTime)
        {
            Publication = publication;
            Person = person;
            DateTime = dateTime;
        }

        public Paper() : this("null", new Person("null", "null", new DateTime(1000, 10, 10)), new DateTime(1000, 10, 10))
        {
        }

        public override string ToString()
        {
           
            return $"Name: {Person.FirstName} LastName: {Person.LastName} Date of birth: {Person.DateOfBirth} Publication: {Publication} Date: {DateTime}";
        }



    }
}
