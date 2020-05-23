using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ResearchTeamCollection
    {
        private const int DefaultsSize = 4;
        #region Delegates

        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        #endregion

        #region Events

        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        #endregion


        #region Constructors


        public ResearchTeamCollection()
        {
            _listResearchTeams = new List<ResearchTeam>();
        }

        #endregion

        #region Private Fields

        public List<ResearchTeam> _listResearchTeams;

        #endregion


        #region Properties

        public string Name { get; set; }
        public int MinRegisterNumber
        {
            get
            {
                if (_listResearchTeams.Count <= 0)
                    return default;
                else
                    return _listResearchTeams.Select(x => x.RegisterNumber).Min();
            }
        }

        public IEnumerable<ResearchTeam> GetTwoYearsLongResearchTeam
        {
            get
            {
                return _listResearchTeams.Where(x => x.DurationOfResearch == ResearchTeam.TimeFrame.TwoYears).ToList();
            }
        }

        #endregion Private Fields

        #region Methods

        public void InsertAt(int index, ResearchTeam researchTeam)
        {
            if (researchTeam == null)
                return;

            if (index >= _listResearchTeams.Count)
            {
                _listResearchTeams.Add(researchTeam);
                ResearchTeamAdded?.Invoke(researchTeam, new TeamListHandlerEventArgs(Name, "Added", _listResearchTeams.Count - 1));
                return;
            }

            _listResearchTeams.Insert(index, researchTeam);
            ResearchTeamInserted?.Invoke(researchTeam, new TeamListHandlerEventArgs(Name, "Inserted", _listResearchTeams.IndexOf(researchTeam, index)));
        }


        public ResearchTeam this[int index]
        {
            get => _listResearchTeams[index];
            set
            {
                _listResearchTeams[index] = value;
                ResearchTeamInserted?.Invoke(this, new TeamListHandlerEventArgs(Name, $"Item by index {index} was changed ", index));
            }
        }
        public List<ResearchTeam> NGroup(int value)
        {
            List<IGrouping<int, ResearchTeam>> group = _listResearchTeams.GroupBy(x => x.ListOfMembers?.Count ?? 0).ToList();
            return group[value].ToList();
        }

        public void SortByRegisterNumber()
        {
            _listResearchTeams.Sort();
        }


        public void SortByResearchTopic()
        {
            _listResearchTeams.Sort(new ResearchTeam());
        }

        public void SortByCountOfPublications()
        {
            _listResearchTeams.Sort(new ResearchTeamComparer());
        }


        public void AddDefaults()
        {
            for (int i = 0; i < DefaultsSize; i++)
            {
                _listResearchTeams.Add(new ResearchTeam());
                ResearchTeamAdded?.Invoke(_listResearchTeams, new TeamListHandlerEventArgs(Name, "New item added to collection. ", _listResearchTeams.Count - 1));
            }
        }


        public void AddResearchTeams(params ResearchTeam[] researches)
        {
            if (researches == null)
                return;
            foreach (var research in researches)
            {
                _listResearchTeams.Add(research);
                ResearchTeamAdded?.Invoke(_listResearchTeams, new TeamListHandlerEventArgs(Name, "New item added to collection.", _listResearchTeams.Count - 1));
            }

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var researchTeam in _listResearchTeams)
            {
                builder.AppendLine(researchTeam.ToString());
            }
            return builder.ToString();

        }


        public virtual string ToShortString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (ResearchTeam team in _listResearchTeams)
            {
                builder.AppendLine(team.ToShortString());
                builder.AppendLine("Total members: " + team.ListOfMembers.Count);
                builder.AppendLine("Total publications: " + team.ListOfPublications.Count);
            }
            return builder.ToString();
        }

        #endregion Methods



    }
}
