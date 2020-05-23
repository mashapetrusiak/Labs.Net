using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam researchTeam = new ResearchTeam("topic" + 5, "organization" + 5, 5, ResearchTeam.TimeFrame.Year,
                new List<Paper> { new Paper("publication" + 5, new Person("first" + 3, "last" + 3, new DateTime(5 + 1990, 5 % 12, 5 % 27)),
                new DateTime(5 + 1990, 5 % 12, 5 % 27))});
            Paper paper = new Paper("publication" + 5, new Person("first" + 3, "last" + 3, new DateTime(5 + 1990, 5 % 12, 5 % 27)), new DateTime(5 + 1990, 5 % 12, 5 % 27));
            Person person = new Person("FirstName", "LastName", new DateTime(2000, 3, 19));

            researchTeam.AddMembers(person);
            researchTeam.AddPapers(paper);

            ResearchTeam copyResearchTeam = researchTeam.DeepCopy<ResearchTeam>(researchTeam);
            researchTeam.ResearchTopic = "TOPIC";
            Console.WriteLine(researchTeam.ResearchTopic);
            Console.WriteLine(copyResearchTeam.ResearchTopic);

            if (researchTeam.Save("test"))
            {
                Console.WriteLine("File is saved");
            }

            ResearchTeam loadedResearchTeam = new ResearchTeam();
            if(loadedResearchTeam.Load("test"))
            {
                Console.WriteLine("File is readed");
            }

            ResearchTeam researchTeamStatic = new ResearchTeam();
            ResearchTeam.Load("test", researchTeamStatic);
            Console.WriteLine(researchTeamStatic);
            ResearchTeam.Save("testt", copyResearchTeam);
            
            researchTeam.AddPaperFromConsole();
            researchTeam.Save("testt");



            Console.ReadLine();
        }
    }
}
