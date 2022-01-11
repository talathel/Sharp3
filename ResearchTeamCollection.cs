using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace C_Sharp_Lab
{
    delegate TKey KeySelector<TKey>(ResearchTeam rt);
    class ResearchTeamCollection<TKey>
    {

        private Dictionary<TKey, ResearchTeam> collection = new Dictionary<TKey, ResearchTeam>();
        private KeySelector<TKey> keySelector;

        public ResearchTeamCollection(KeySelector<TKey> keySelectorValue)
        {
            keySelector = keySelectorValue;
        }

        public DateTime LastDate
        {
            get
            {
                List<DateTime> lastDates = new List<DateTime>();
                lastDates.Add(new DateTime());
                foreach (ResearchTeam rt in collection.Values)
                {
                    if (rt.lastPaper != null)
                    {
                        lastDates.Add(rt.lastPaper.PublicationDate);
                    }
                }
                return lastDates.Max();
            }
        }

        public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> GroupByDuration
        {
            get
            {
                IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> result = collection.GroupBy( 
                   group => group.Value.Duration );
                return result;
            }
        }

        public void AddDefaults()
        {
            ResearchTeam defaultRT = new ResearchTeam();
            collection.Add(keySelector(defaultRT), defaultRT);
        }

        public void AddResearchTeams(params ResearchTeam[] paramsValue)
        {
            foreach (ResearchTeam param in paramsValue)
            {
                collection.Add(keySelector(param), param);
            }
        }

        public override string ToString()
        {
            string str = $"This collection contains {collection.Count} research teams: \n";
            str += "\n----------------------------------------------\n";
            foreach (ResearchTeam value in collection.Values)
            {
                str += value.ToString() + "\n----------------------------------------------\n";
            }
            return str;
        }

        public string ToShortString()
        {
            string str = $"This collection contains {collection.Count} research teams: \n";
            foreach (ResearchTeam value in collection.Values)
            {
                str += value.ToShortString();
            }
            return str;
        }

        public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value)
        {
            return collection.Where(group => group.Value.Duration == value);
        }






    }

}
