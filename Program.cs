using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Program
    {
        public static TeamsJournal teamsJournal1 { get; set; }
        public static TeamsJournal teamsJournal2 { get; set; }
        public static void ShowMessage(object source, TeamListHandlerEventArgs args)
        {
            TeamsJournalEntry journalEntry = new TeamsJournalEntry(args.NameOfActionCollection, args.InformationOfActionCollection, args.NumberOfElement);
            if(journalEntry.Name == "researchTeam1")
            {
                teamsJournal1.TeamsJournalEntries.Add(journalEntry);                
            }
            teamsJournal2.TeamsJournalEntries.Add(journalEntry);
            Console.WriteLine(args.ToString());
        }


        static void Main(string[] args)
        {
            ResearchTeamCollection researchTeamCollection1 = new ResearchTeamCollection();
            ResearchTeamCollection researchTeamCollection2 = new ResearchTeamCollection();
            teamsJournal1 = new TeamsJournal();
            teamsJournal2 = new TeamsJournal();

            teamsJournal1.Name = nameof(teamsJournal1);
            teamsJournal2.Name = nameof(teamsJournal2);
            researchTeamCollection1.NameOfCollection = nameof(researchTeamCollection1);
            researchTeamCollection2.NameOfCollection = nameof(researchTeamCollection2);

            researchTeamCollection1.ResearchTeamAdded += ShowMessage;
            researchTeamCollection1.ResearchTeamInserted += ShowMessage;
            researchTeamCollection2.ResearchTeamAdded += ShowMessage;
            researchTeamCollection2.ResearchTeamInserted += ShowMessage;

            researchTeamCollection1.InsertAt(0, new ResearchTeam());
            researchTeamCollection1.InsertAt(3, new ResearchTeam());
            researchTeamCollection2.InsertAt(0, new ResearchTeam());
            researchTeamCollection2.InsertAt(1, new ResearchTeam());
            researchTeamCollection2.InsertAt(1, new ResearchTeam());
            researchTeamCollection2.InsertAt(3, new ResearchTeam());
            researchTeamCollection2.InsertAt(3, new ResearchTeam());
            researchTeamCollection2.InsertAt(7, new ResearchTeam());

            Console.WriteLine(Environment.NewLine + teamsJournal1.ToString());
            Console.WriteLine(Environment.NewLine + teamsJournal2.ToString());



            Console.ReadLine();
        }
    }
}
