using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TestCollections
    {
        #region Private Fields

        private List<Team> _listOfTeams;
        private List<string> _listOfStrings;
        private Dictionary<Team, ResearchTeam> _dictionaryTeamResearchTeam;
        private Dictionary<string, ResearchTeam> _dictionaryStringResearchTeam;

        #endregion

        #region Constructor

        public TestCollections(int count)
        {
            _listOfTeams = new List<Team>();
            _listOfStrings = new List<string>();
            _dictionaryStringResearchTeam = new Dictionary<string, ResearchTeam>();
            _dictionaryTeamResearchTeam = new Dictionary<Team, ResearchTeam>();

            for(int i = 0; i < count; i++)
            {
                ResearchTeam researchTeam = CreateResearchTeam(i);
                Team team = new Team($"teamName{i+1}",i + 1);
                _listOfTeams.Add(team);
                _listOfStrings.Add(team.ToString());
                _dictionaryStringResearchTeam.Add(team.ToString(), researchTeam);
                _dictionaryTeamResearchTeam.Add(team, researchTeam);
            }
        }

        #endregion

        #region Methods

        public static ResearchTeam CreateResearchTeam(int index)
        {
            List<Paper> papers = new List<Paper>() { new Paper($"Publication{index}", new Person($"First{index}", $"Last{index}", new DateTime(index % 2000 + 1990, index % 11 + 1, index % 27 + 1)), new DateTime(index%2000 + 1990, index % 11 + 1, index % 27 + 1) )};
            ResearchTeam tempResearchTeam = new ResearchTeam($"NameOfOrganization{index}", $"Research Topic{index}", index + 1,
                TimeFrame.Year, papers);
            return tempResearchTeam;
        }

        public static Team CreateTeam(int index)
        {
            return new Team($"teamName{index + 1}", index + 1);
        }

        public void CollectionProductivity(int index)
        {
            Team team = CreateTeam(index);
            ResearchTeam researchTeam = CreateResearchTeam(index);
            
            int start = Environment.TickCount;
            if(_listOfTeams.Contains(team))
                Console.WriteLine("listOfTeam contains suggested team");
            int end = Environment.TickCount;
            Console.WriteLine("Time of suggested team in listOfTeams :" + (end - start));
            
            start = Environment.TickCount;
            if (_listOfStrings.Contains(team.ToString()))
                Console.WriteLine("listOfString contains suggested team");
            end = Environment.TickCount;
            Console.WriteLine("Time of suggested team in listOfString : "+ (end - start));

            start = Environment.TickCount;
            if(_dictionaryStringResearchTeam.ContainsKey(team.ToString()))
                if(researchTeam.Equals(_dictionaryStringResearchTeam[team.ToString()]))
                    Console.WriteLine("StringDictionary contains suggested team and dictionary");
            end = Environment.TickCount;
            Console.WriteLine("Dictionary researchTeam find (key) : "+ (end - start));

            start = Environment.TickCount;
            if(_dictionaryTeamResearchTeam.ContainsKey(team))
                if(researchTeam.Equals(_dictionaryTeamResearchTeam[team]))
                    Console.WriteLine("TeamDictionary contains suggested team and dictionary");
            end = Environment.TickCount;
            Console.WriteLine("Dictionary researchTeam find (key) : " + (end - start));
        }

        #endregion
        



    }
}
