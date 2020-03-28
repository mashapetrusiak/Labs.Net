using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Person
    {

        #region Private Fields
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        #endregion

        #region Public Fields
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }
        public int YearOfBirth
        {
            get
            {
                return _dateOfBirth.Year;
            }
            set
            {
                DateTime NewdateTime = new DateTime(value, _dateOfBirth.Month, _dateOfBirth.Day);
                _dateOfBirth = NewdateTime;
            }
        }
        #endregion

        #region Public Constructors
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person() : this("default", "default", new DateTime(2000, 10, 10))
        {
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return $"First name: {FirstName} Last name: {LastName} Date of birth: {DateOfBirth}";
        }

        public virtual string ToShortString()
        {
            return $"{FirstName} {LastName}";
        }

        protected bool Equals(Person other)
        {
            return string.Equals(FirstName, other.FirstName) && string.Equals(LastName, other.LastName) && DateOfBirth.Equals(other.DateOfBirth);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = FirstName != null ? FirstName.GetHashCode() : 0;
            hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (DateOfBirth.GetHashCode());
            return hashCode;
        }




        #endregion

        #region public operators
        public static bool operator ==(Person person1, Person person2)
        {
            return string.Equals(person1.FirstName, person2.FirstName) && string.Equals(person1.LastName, person2.LastName) && DateTime.Equals(person1.DateOfBirth, person2.DateOfBirth);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !string.Equals(person1.FirstName, person2.FirstName) && !string.Equals(person1.LastName, person2.LastName) && !DateTime.Equals(person1.DateOfBirth, person2.DateOfBirth);
        }
        #endregion

    }
}
