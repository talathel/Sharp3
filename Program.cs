using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace C_Sharp_Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Exercise 1 : \n");
            Person Person1 = new Person("Ivan", "Ivanov", new DateTime(1976, 2, 29));
            Person Person2 = new Person("Antoine", "de Saint-Exupéry", new DateTime(1900, 6, 29));
            Person Person3 = new Person("Lev", "Landau", new DateTime(1908, 1, 22));
            Paper Paper1 = new Paper("publ1", Person1, new DateTime(2200, 3, 3));
            Paper Paper2 = new Paper("publ3", Person1, new DateTime(2010, 6, 6));
            Paper Paper3 = new Paper("publ2", new Person(), new DateTime(2021, 5, 5));
            ResearchTeam RTeam = new ResearchTeam("topic1", "teamName1", TimeFrame.TwoYears, 12);
            RTeam.AddPapers(new Paper[] { Paper1, Paper2, Paper3 });
            RTeam.AddMembers(new Person[] { Person1, Person2, Person3, new Person() });
            Console.WriteLine(RTeam);
            RTeam.SortByDate();
            Console.WriteLine(RTeam);
            RTeam.SortByTitle();
            Console.WriteLine(RTeam);
            RTeam.SortByAuthor();
            Console.WriteLine(RTeam);

            Console.WriteLine("Exercise 2 : \n");
            KeySelector<string> keySelector = (ResearchTeam rt) => rt.GetHashCode().ToString();
            ResearchTeamCollection<string> collection = new ResearchTeamCollection<string>(keySelector);

            ResearchTeam RTeam2 = new ResearchTeam("topic2", "teamName2", TimeFrame.TwoYears, 12);
            RTeam2.AddPapers(new Paper[] { Paper1, new Paper() });
            RTeam2.AddMembers(new Person[] { Person1, new Person() });
            collection.AddDefaults();
            collection.AddResearchTeams(RTeam, RTeam2);
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Exercise 3 : \n");
            Console.WriteLine($"Last Paper Date: {collection.LastDate}");
            Console.WriteLine($"Groups by duration: \n");
            foreach (var group in collection.GroupByDuration)
            {
                Console.WriteLine(group.Key.ToString() + ":\n");
                foreach (var item in group)
                {
                    Console.WriteLine(item.Value);
                }
            }
            Console.WriteLine($"TwoYears Duration Group: \n");
            foreach (var item in collection.TimeFrameGroup(TimeFrame.TwoYears))
            {
                Console.WriteLine(item.Value.ToString() + "\n");
            }

            GenerateElement<Team, ResearchTeam> generateElement = (int j) =>
            {
                Team key = new Team($"Test{j}",j);
                ResearchTeam value = new ResearchTeam($"topic{j}",key.Name,TimeFrame.Year, key.Number);
                return new KeyValuePair<Team, ResearchTeam>(key,value);
            };
            TestCollections<Team,ResearchTeam> Test = new TestCollections<Team, ResearchTeam>(1000000,generateElement);
            Console.WriteLine("Search time for element in key list: \n");
            Test.SearchTimeKeyList();
            Console.WriteLine("Search time for element in string list: \n");
            Test.SearchTimeKeyList();
            Console.WriteLine("Search time for element by key in dictionary: \n");
            Test.SearchTimeKeyList();
            Console.WriteLine("Search time for element value in dictionary: \n");
            Test.SearchTimeKeyList();

        }
    }
}
