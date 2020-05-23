using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class TeamsJournal
    {
        #region Private Fields

        public List<TeamsJournalEntry> TeamsJournalEntries { get; set; }
        public string Name { get; set; }
        #endregion

        #region Events

        public event ResearchTeamCollection.TeamListHandler ResearchTeamAdded;
        public event ResearchTeamCollection.TeamListHandler ResearchTeamInserted;

        #endregion

        #region Constructors

        public TeamsJournal() : this(journals: new List<TeamsJournalEntry>())
        {
        }

        public TeamsJournal(List<TeamsJournalEntry> journals)
        {
            TeamsJournalEntries = journals;
        }

        #endregion

        #region Methods

        public void Show_Message(object source, TeamListHandlerEventArgs args)
        {
            TeamsJournalEntry teamsJournalEntry = new TeamsJournalEntry(args.CollectionName, args.CollectionChangeType, args.NumberChangeOfElement);
            TeamsJournalEntries.Add(teamsJournalEntry);

            //Console.WriteLine(args.ToString());
        }



        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Journal: " + Name);
            foreach (var team in TeamsJournalEntries)
            {
                builder.AppendLine(team.ToString());
            }
            return builder.ToString();
        }

        #endregion


    }
}
