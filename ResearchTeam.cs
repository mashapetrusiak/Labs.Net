using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    }
    public class ResearchTeam : Team, INameAndCopy, IEnumerable, IComparer<ResearchTeam>
    {

        #region Private Fields
        private string _researchTopic;
        private TimeFrame _durationOfResearch;
        private List<Person> _people;
        private List<Paper> _papers;

        #endregion

        #region Public Fields

        public TimeFrame DurationOfResearch
        {
            get => _durationOfResearch;
            set => _durationOfResearch = value;
        }
       
        public new string NameResearchTopic
        {
            get
            {
                return _researchTopic;
            }
            set
            {
                _researchTopic = value;
            }

        }

        public bool this[TimeFrame time]
        {
            get
            {
                return time == _durationOfResearch;
            }
        }

        public List<Paper> Publications
        {
            get => _papers;
            set => _papers = value;
        }
        
        public List<Person> People
        {
            get => _people;
            set => _people = value;
        }

        public Paper LastPublication
        {
            get
            {
                if (Publications != null || Publications.Count > 0)
                    return Publications.Last();
                else
                    return null;
            }
        }

        public Team TeamObject
        {
            get
            {
                return new Team(NameOfOrganization, RegisterNumber);
            }
            set
            {
                NameOfOrganization = value.NameOfOrganization;
                RegisterNumber = value.RegisterNumber;
            }
        }
        #endregion

        #region Public Constructors
        public ResearchTeam() : base()
        {
            _researchTopic = "default topic";
            _durationOfResearch = default;
        }

        public ResearchTeam(string nameOfOrganization, string researchTopic, int registerNumber, TimeFrame durationOfResearch, List<Paper> publications) : base(nameOfOrganization, registerNumber)
        {
            _researchTopic = researchTopic;
            _durationOfResearch = durationOfResearch;
            _papers = publications;
        }

        #endregion

        #region Public Methods

        public void AddPapers(params Paper[] papers)
        {
            foreach (var paper in papers)
                Publications.Add(paper);
        }

        public string ToShortString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Research topic : " + _researchTopic);
            stringBuilder.Append("Duration of research: " + _durationOfResearch);
            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            return base.ToString() + $"{_researchTopic} {_durationOfResearch}\n\t{string.Join("\n\t", _papers.Select(x => x.ToString()).ToArray())}";
            /*var stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append("Research Topic: " + _researchTopic);
            stringBuilder.Append("Duration of research: " + _durationOfResearch);
            stringBuilder.Append("Participants: ");
            if (People != null)
            {
                foreach (var person in People)
                {
                    stringBuilder.Append(person.ToString());
                }
            }
            stringBuilder.Append("Papers: ");
            if (Publications != null)
            {
                foreach (var paper in Publications)
                {
                    if (paper == null)
                        continue;
                    else
                    {
                        stringBuilder.Append(paper.ToString());
                        stringBuilder.Append("\n");
                    }

                }
            }
            return stringBuilder.ToString();*/
        }

        public override object DeepCopy()
        {
            ResearchTeam copyResearchTeam = new ResearchTeam(NameOfOrganization, _researchTopic, RegisterNumber, _durationOfResearch, Publications);
            copyResearchTeam._people = _people;
            return copyResearchTeam;
        }

        public IEnumerable<Person> GetMemberWithoutAnyPublish()
        {
            var members = _people.Where(x => !_papers.Any(p => p.Person.Equals(x)));
            if (members.Count() < 0)
                yield break;

            foreach (var person in members)
                yield return person;
        }

        public IEnumerable<Paper> GetPublishInRecentYears(int year)
        {
            var publications = _papers.Where(x => (DateTime.Now.Year - x.DateTime.Year) < year);
            if (publications.Count() < 0)
                yield break;
            foreach (var publication in publications)
                yield return publication;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetMemberWithoutAnyPublish();
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.NameOfOrganization.CompareTo(y.NameOfOrganization);
        }

        public ResearchTeam ShallowCopy()
        {
            return (ResearchTeam)MemberwiseClone();
        }




        #endregion
    }
}
