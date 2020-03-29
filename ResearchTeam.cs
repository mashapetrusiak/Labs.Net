using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ArrayList
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    }
    public class ResearchTeam : Team, INameAndCopy, IEnumerable
    {
        private string _researchTopic;
        private TimeFrame _durationResearch;
        private ArrayList _listOfPublications;
        private ArrayList _listOfMembers;

        public string ResearchTopic
        {
            get { return _researchTopic; }
            set { _researchTopic = value; }
        }

        public TimeFrame DurationOfResearch
        {
            get { return _durationResearch; }
            set { _durationResearch = value; }
        }

        public ArrayList ListOfPublications
        {
            get => _listOfPublications;
            set => _listOfPublications = value;
        }

        public ArrayList ListOfMembers
        {
            get => _listOfMembers;
            set => _listOfMembers = value;
        }

        public Team team
        {
            get
            {
                return new Team(Organization, RegisterNumber);
            }
            set
            {
                Organization = value.Name;
                RegisterNumber = value.RegisterNumber;
            }
        }

        public Paper LastPublication
        {
            get
            {
                if (ListOfPublications == null)
                    return null;
                else
                    return (Paper)ListOfPublications[ListOfPublications.Count - 1];
            }
        }


        public ResearchTeam(string resTopic, string organization, int regNumber, TimeFrame timeFrame, ArrayList publications, ArrayList members):base(organization,regNumber)
        {
            ResearchTopic = resTopic;
            DurationOfResearch = timeFrame;
            ListOfPublications = publications;
            ListOfMembers = members;
        }


        public ResearchTeam() : this("default", "default",1,new TimeFrame(), new ArrayList(), new ArrayList())
        {
        }

        public bool this[TimeFrame time]
        {
            get
            {
                return time == DurationOfResearch;
            }
        }





        public void AddPapers(params Paper[] papers)
        {
            ListOfPublications.AddRange(papers);
        }
        public void AddMembers(params Person[] members)
        {
            ListOfMembers.AddRange(members);
        }

        public virtual string ToShortString()
        {
            return $"Organization: {Organization} \t Topic: {ResearchTopic} \t Register number: {RegisterNumber} \t TimeFrame: {DurationOfResearch} ";
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(ToShortString());
            builder.AppendLine(base.ToString());
            builder.AppendLine($"Topic: {ResearchTopic}");
            builder.AppendLine($"Duration: {_durationResearch}");
            builder.AppendLine("Members: ");
            if (ListOfMembers != null)
                foreach (Person member in ListOfMembers)
                    builder.AppendLine(member.ToString());
            builder.AppendLine("Publications: ");
            if (ListOfPublications != null)
                foreach (Paper paper in ListOfPublications)
                    builder.AppendLine(paper.ToString());
            return builder.ToString();          
        }

        protected bool Equals(ResearchTeam research)
        {
            if (ListOfMembers.Count != research.ListOfMembers.Count)
                return false;
            if (ListOfPublications.Count == research.ListOfPublications.Count)
                return false;
            for(int i = 0; i < ListOfMembers.Count;i++)
            {
                if (ListOfMembers[i] == research.ListOfMembers[i])
                    continue;
                else
                    return false;
            }

            for(int i = 0; i < ListOfPublications.Count;i++)
            {
                if (ListOfPublications[i] == research.ListOfPublications[i])
                    continue;
                else
                    return false;
            }
            return base.Equals(research) && Organization.Equals(research.Organization) && DurationOfResearch.Equals(research.DurationOfResearch);       
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((ResearchTeam)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ ResearchTopic.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)DurationOfResearch;
                hashCode = (hashCode * 397) ^ (ListOfMembers != null ? ListOfMembers.GetHashCode() : 0);
                hashCode = (hashCode * 397) & (ListOfPublications != null ? ListOfPublications.GetHashCode() : 0);
                return hashCode;
            }
        }

        public string Name { get; set; }
        public object DeepCopy()
        {
            var selected = (ResearchTeam)MemberwiseClone();
            selected.ListOfMembers = new ArrayList();
            selected.ListOfPublications = new ArrayList();
            foreach (Person person in ListOfMembers)
                selected.ListOfMembers.Add(person.DeepCopy());
            foreach (Paper paper in ListOfPublications)
                selected.ListOfPublications.Add(paper);
            return selected;
        }


        public IEnumerable<Person> MembersWithoutAnyPublications()
        {
            if (ListOfPublications.Count < 0)
                yield break;
            foreach(Paper paper in ListOfPublications)
            {
                if(paper.Publication == null || paper.DateTime == default)
                {
                    yield return paper.Person;
                }
            }
            
                
        }

        public IEnumerable<Paper> GetPublishInRecentYears(int year)
        {
            if (ListOfPublications.Count < 0)
                yield break;
            foreach(Paper paper in ListOfPublications)
            {
                if (DateTime.Now.Year - paper.DateTime.Year < year)
                    yield return paper;
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
