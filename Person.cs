using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ArrayList
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

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

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Person() : this("default", "default", new DateTime(2000, 10, 10))
        {
        }

        public override string ToString()
        {
            return $"First name: {FirstName} Last name: {LastName} Date of birth: {DateOfBirth}";
        }

        public virtual string ToShortString()
        {
            return $"{FirstName} {LastName}";
        }


        protected bool Equals(Person p)
        {
            return FirstName.Equals(p.FirstName) && LastName.Equals(p.LastName) && DateOfBirth.Equals(p.DateOfBirth);
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
            unchecked
            {
                var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DateOfBirth.GetHashCode();
                return hashCode;
            }
        }
        
        public static bool operator == (Person left, Person right)
        {
            return ReferenceEquals(left, right);
        }
        public static bool operator !=(Person left, Person right)
        {
            return !ReferenceEquals(left, right);
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }



    }
}
