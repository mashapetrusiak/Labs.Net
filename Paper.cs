using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ArrayList
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



        protected bool Equals(Paper paper)
        {
            return Publication.Equals(paper.Publication) && Person.Equals(paper.Person) && DateTime.Equals(paper.DateTime);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Paper)obj);
        }



        public override string ToString()
        {

            return $"Name: {Person.FirstName} LastName: {Person.LastName} Date of birth: {Person.DateOfBirth} Publication: {Publication} Date: {DateTime}";
        }

    }
}
