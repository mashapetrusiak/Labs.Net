using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Paper 
    { 
        #region Public Fields
        public string Publication { get; set; }
        public Person Person { get; set; }
        public DateTime DateTime { get; set; }
        #endregion

        #region Public Constructors
        public Paper(string publication, Person person, DateTime dateTime)
        {
            Publication = publication;
            Person = person;
            DateTime = dateTime;
        }

        public Paper() : this("null", new Person("null", "null", new DateTime(1000, 10, 10)), new DateTime(1000, 10, 10))
        {
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {

            return $"Name: {Person.FirstName} LastName: {Person.LastName} Date of birth: {Person.DateOfBirth} Publication: {Publication} Date: {DateTime}";
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }
        #endregion
    }
}
