using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team1 = new Team("test_organization1",123);
            Team team2 = new Team("test_organization2",345);
            Console.WriteLine(team1 == team2);
            Console.WriteLine("HashCode of team1: " + team1.GetHashCode());
            Console.WriteLine("HashCode of team2: " + team2.GetHashCode());

            
            try
            {
                Team incorrectTeam = new Team("test", -12345);    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Person[] people = new Person[]
            {
                new Person("F1","L1", new DateTime(1999,05,12)),
                new Person("F2","L2", new DateTime(1999,02,08))
            };

            Paper[] papers = new Paper[]
            {
                new Paper("publication_test1", people[0], new DateTime(2015,09,18)),
                new Paper("publication_test2", people[1], new DateTime(2017,03,07)),
                new Paper("publication_test3", people[0], new DateTime(2019,10,20)),
                new Paper(null,new Person("F3","L3", new DateTime(1999,09,19)), default)
            };
            ResearchTeam researchTeam = new ResearchTeam();

            researchTeam.AddPapers(papers);
            researchTeam.AddMembers(people);
            Console.WriteLine(researchTeam.ToString());
            Console.WriteLine(researchTeam.team.ToString() + "\n");

            ResearchTeam copyResearchTeam = new ResearchTeam();
            copyResearchTeam = researchTeam.DeepCopy() as ResearchTeam;
            researchTeam.RegisterNumber = 9999;
            Console.WriteLine(researchTeam.ToString() + "\n");
            Console.WriteLine(copyResearchTeam.ToString() + "\n");
            
            foreach(Paper paper in researchTeam.GetPublishInRecentYears(2))
            {
                Console.WriteLine(paper.ToString());
            }
            Console.WriteLine();
            foreach(Person person in researchTeam.MembersWithoutAnyPublications())
            {
                Console.WriteLine(person.ToString());
            }


            Console.ReadLine();
        }
    }

}
