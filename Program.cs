using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person[] members = new Person[]
            {
                new Person("First" + 1, "Last" + 1, new DateTime(1990 + 1, 1%12, 1 % 27)),
                new Person("First" + 2, "Last" + 2, new DateTime(1990 + 2, 2%12, 2 % 27)),
                new Person("First" + 3, "Last" + 3, new DateTime(1990 + 3, 3%12, 3 % 27))
            };
            ResearchTeamCollection researchTeamCollection = new ResearchTeamCollection();
            ResearchTeam[] researchTeams = new ResearchTeam[]
            {
                new ResearchTeam("name" + 8, "topic" + 8,8, TimeFrame.Year, new List<Paper>{ new Paper("publication" + 8, new Person("first" + 1,"last" + 1, new DateTime(1990+8,8%12,8%27)),
                new DateTime(8 + 1990,8%12, 8%27))}),
                new ResearchTeam("name" + 16, "topic" + 16,16, TimeFrame.Year, new List<Paper>{ new Paper("publication" + 16, new Person("first" + 1,"last" + 1, new DateTime(1990+16,16%12,16%27)),
                new DateTime(16 + 1990,16%12, 16%27))}),
                new ResearchTeam("name" + 33, "topic" + 33,33, TimeFrame.Year, new List<Paper>{ new Paper("publication" + 33, new Person("first" + 1,"last" + 1, new DateTime(1990+33,33%12,33%27)),
                new DateTime(33 + 1990,33%12, 33%27))}),
                new ResearchTeam("name" + 11, "topic" + 11,11, TimeFrame.Year, new List<Paper>{ new Paper("publication" + 11, new Person("first" + 1,"last" + 1, new DateTime(1990+11,11%12,11%27)),
                new DateTime(11 + 1990,11%12, 11%27))}),
                new ResearchTeam("name" + 25, "topic" + 25,25, TimeFrame.Year, new List<Paper>{ new Paper("publication" + 25, new Person("first" + 1,"last" + 1, new DateTime(1990+25,25%12,25%27)),
                new DateTime(25 + 1990,25%12, 25%27))})
            };
            researchTeams[2].People = members.Skip(2).ToList();
            researchTeams[1].People = members.Skip(1).ToList();
            researchTeams[0].People = members.ToList();
            researchTeamCollection.AddResearchTeams(researchTeams);
            Console.WriteLine(researchTeamCollection.ToString());

            Console.WriteLine("Sort Methods: ");
            Console.WriteLine("Sort by registration number: ");
            researchTeamCollection.SortByRegistrationNumber();
            Console.WriteLine(researchTeamCollection.ToString());
            Console.WriteLine("Sort by research topic: ");
            researchTeamCollection.SortByResearchTopic();
            Console.WriteLine(researchTeamCollection.ToString());
            Console.WriteLine("Sort by count of publication: ");
            researchTeamCollection.SortByCountOfPublications();
            Console.WriteLine(researchTeamCollection.ToString());

            Console.WriteLine($"Minimal registration number : {researchTeamCollection.MinRegisterNumber}");
            var strTwoYears = string.Join(Environment.NewLine, researchTeamCollection.GetTwoYearsLongResearchTeam.Select(x => x.ToString()));
            Console.WriteLine(strTwoYears);
            
            var groupingOfElements = string.Join(Environment.NewLine, researchTeamCollection.NGroup(1).Select(x => x.ToString()));
            Console.WriteLine(groupingOfElements);

            TestCollections testCollections = new TestCollections(10000);
            testCollections.CollectionProductivity(1);
            testCollections.CollectionProductivity(1000001);
            testCollections.CollectionProductivity(1999999);
            testCollections.CollectionProductivity(2111111);

            Console.ReadLine();
        }
    }
}
