using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Team : INameAndCopy, IComparable
    {
        #region Private Fields
        private string _nameOfOrganization;
        private int _registerNumber;
        private Team team;
        #endregion

        #region Public Fields
        public string NameOfOrganization
        {
            get { return _nameOfOrganization; }
            set { _nameOfOrganization = value; }
        }
        public int RegisterNumber
        {
            get
            {
                return _registerNumber;
            }
            set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new Exception($"Register number must be bigger than 0. You set {value}");
                    }
                    _registerNumber = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error : {e.Message}");
                }
            }
        }

        public string Name { get; set; }
        #endregion

        #region Public Constructors
        public Team(string nameOfOrganization, int registerNumber)
        {
            NameOfOrganization = nameOfOrganization;
            RegisterNumber = registerNumber;
        }
        public Team() : this("default name of organization", 1)
        {

        }
        #endregion


        #region Public Methods

        public int CompareTo(object obj)
        {            
            return RegisterNumber.CompareTo((obj as Team).RegisterNumber);
        }


        public virtual object DeepCopy()
        {
            return new Team(Name, RegisterNumber);
        }

        protected bool Equals(Team team)
        {
            return string.Equals(NameOfOrganization, team.NameOfOrganization) && string.Equals(RegisterNumber, team.RegisterNumber);
        }

        public override bool Equals(object obj)
        {
            if (obj is Team team)
            {
                return Equals(team);
            }
            else 
                return false;
        }

        public override int GetHashCode()
        {
            var hashCode = NameOfOrganization != null ? RegisterNumber.GetHashCode() : 0;
            hashCode = (hashCode * 397) ^ (NameOfOrganization != null ? NameOfOrganization.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (RegisterNumber.GetHashCode());
            return hashCode;
        }

        public override string ToString()
        {
            return $"NameOrganization : {NameOfOrganization}\t RegNumber : {RegisterNumber}";
        }

        #endregion

       
    }
}
