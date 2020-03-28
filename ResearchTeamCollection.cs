using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ResearchTeamCollection
    {
        #region Private Fields
        
        private List<ResearchTeam> _researchTeamList;

        #endregion

        #region Constructors

        public ResearchTeamCollection()
        {
            _researchTeamList = new List<ResearchTeam>();
        }

        #endregion

        #region Properties

        public int MinRegisterNumber
        {
            get
            {
                if(_researchTeamList.Count <= 0)
                {
                    return default;
                }
                else
                {
                    return _researchTeamList.Select(x => x.RegisterNumber).Min();
                }
            }
        }


        public IEnumerable<ResearchTeam> GetTwoYearsLongResearchTeam
        {
            get
            {
                return _researchTeamList.Where(x => x.DurationOfResearch == TimeFrame.TwoYears).ToList();
            }
        }

        #endregion



        #region Public Methods

        public List<ResearchTeam> NGroup(int value)
        {
            List<IGrouping<int, ResearchTeam>> group = _researchTeamList.GroupBy(x => x.People?.Count ?? 0).ToList();
            return group[value].ToList();
        }

        public void AddDefaults(int count)
        {
            for(int i = 0; i < count;i++)
            {
                _researchTeamList.Add(new ResearchTeam());
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            foreach (var resTeam in researchTeams)
                _researchTeamList.Add(resTeam);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _researchTeamList.Select(x => x.ToString()));
        }

        public virtual string ToShortString()
        {
            return string.Join(Environment.NewLine, _researchTeamList.Select(x => x.ToShortString()));
        }

        public void SortByRegistrationNumber()
        {
            _researchTeamList.Sort();
        }

        public void SortByResearchTopic()
        {
            _researchTeamList.Sort(new ResearchTeam());
        }

        public void SortByCountOfPublications()
        {
            _researchTeamList.Sort(new ResearchTeamComparer());
        }


        #endregion

    }
}
