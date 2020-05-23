using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam team1, ResearchTeam team2)
        {
            return team1.ListOfPublications.Count.CompareTo(team2.ListOfPublications.Count);
        }
    }
}
