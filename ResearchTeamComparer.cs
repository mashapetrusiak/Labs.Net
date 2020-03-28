using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ResearchTeamComparer :IComparer<ResearchTeam>
    {
        
        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.Publications.Count.CompareTo(y.Publications.Count);
        }
    }
}
