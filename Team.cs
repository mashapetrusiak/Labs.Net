using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [DataContract]
    public class Team : INameAndCopy, IComparable
    {
        #region Private Fields

        private string _organization;
        private int _registerNumber;

        #endregion

        #region Properties
        [DataMember]
        public string Organization
        {
            get => _organization;
            set => _organization = value;
        }
        [DataMember]
        public int RegisterNumber
        {
            get => _registerNumber;
            set
            {
                if (value <= 0)
                    throw new Exception($"{nameof(RegisterNumber)} must be grater than 0");
                _registerNumber = value;
            }
        }

        #endregion


        #region Constructors

        public Team() : this(default, 1)
        {

        }

        public Team(string organization, int regNumber)
        {
            Organization = organization;
            RegisterNumber = regNumber;
        }

        #endregion

        #region Methods

        public string Name { get; set; }

        public  object DeepCopy()
        {
            return MemberwiseClone();
        }

        protected bool Equals(Team team)
        {

            return string.Equals(Organization, team.Organization) && RegisterNumber.Equals(team.RegisterNumber);
        }


        public override bool Equals(object obj)
        {
            if (obj is Team team)
                return Equals(team);
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = (hash * 29) + Organization.GetHashCode();
            return (hash * 29) + RegisterNumber;
        }

        public override string ToString()
        {
            return $"{nameof(Organization)} has registry number {RegisterNumber}";
        }

        public int CompareTo(object obj)
        {
            return RegisterNumber.CompareTo((obj as Team).RegisterNumber);
        }
        #endregion
    }
}
