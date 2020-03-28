using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class TeamsJournal
    {
        #region Properties

        public List<TeamsJournalEntry> TeamsJournalEntries;
        public string Name { get; set; }

        #endregion

        #region Constructors

        public TeamsJournal() : this(teamsJournalEntries: new List<TeamsJournalEntry>())
        {
        }
        public TeamsJournal(List<TeamsJournalEntry> teamsJournalEntries)
        {
            TeamsJournalEntries = teamsJournalEntries;
        }

        #endregion


        #region Events

        public event ResearchTeamCollection.TeamListHandler ResearchTeamAdded;
        public event ResearchTeamCollection.TeamListHandler ResearchTeamInserted;

        #endregion


        #region Methods

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Journal: " + Name + "\n");
            foreach(var elem in TeamsJournalEntries)
            {
                stringBuilder.Append(elem);
            }
            return stringBuilder.ToString();
        }

        #endregion



    }
}
