using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    class ResearchTeam : Team, System.Collections.IEnumerable
    {
        private string topic;
        TimeFrame duration;
        List<Person> members;
        List<Paper> papers;

        public ResearchTeam() : this("topicDefault", "nameDefault", TimeFrame.Year, 0)
        {

        }

        public ResearchTeam(string topicValue, string nameValue, TimeFrame durationValue, int numberValue)
        {
            topic = topicValue;
            duration = durationValue;
            name = nameValue;
            number = numberValue;
            members = new List<Person>();
            papers = new List<Paper>();

        }
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public TimeFrame Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public List<Paper> Papers
        {
            get { return papers; }
            set { papers = value; }
        }
        public List<Person> Members
        {
            get { return members; }
            set { members = value; }
        }

        public Paper lastPaper
        {
            get
            {
                if (this.papers.Count == 0)
                {
                    return null;
                }
                else
                {
                    Paper PaperNeeded = (Paper)papers[0];
                    for (int i = 0; i < Papers.Count; i++)
                    {
                        Paper PaperTemp = (Paper)papers[i];
                        if (PaperTemp.PublicationDate.CompareTo(PaperNeeded.PublicationDate) >= 0)
                        {
                            PaperNeeded = PaperTemp;
                        }
                    }
                    return PaperNeeded;
                }
            }

        }
        public Team BaseTeam
        {
            get
            {
                return new Team(name, number);
            }
            set
            {
                name = value.Name;
                number = value.Number;
            }
        }
        public void AddPapers(params Paper[] PapersValue)
        {
            for (int i = 0; i < PapersValue.Length; i++)
            {
                papers.Add(PapersValue[i]);
            }
        }
        public void AddMembers(params Person[] MembersValue)
        {
            for (int i = 0; i < MembersValue.Length; i++)
            {
                members.Add(MembersValue[i]);
            }
        }

        public bool this[TimeFrame index]
        {
            get
            {
                return Duration.CompareTo(index) == 0;
            }
        }

        public override string ToString()
        {
            string PapersString = new string("Papers: \n");
            if (papers.Count > 0)
            {
                PapersString += papers[0].ToString();
                for (int i = 1; i < papers.Count; i++)
                {
                    PapersString += papers[i].ToString();
                }
            }
            string MembersString = new string("Members: \n");
            if (members.Count > 0)
            {
                MembersString += (members[0].ToString() + '\n');
                for (int i = 1; i < members.Count; i++)
                {
                    MembersString += (members[i].ToString() + '\n');
                }
            }
            return "Topic: " + Topic + "\n"
                + "Name: " + Name + '\n'
                + "Number: " + Number + '\n'
                + "Duration: " + Duration + '\n'
                + PapersString + MembersString;
        }
        public string ToShortString()
        {
            return "Topic: " + Topic + "\n"
                + "Name: " + Name + '\n'
                + "Number: " + Number + '\n'
                + "Duration: " + Duration + '\n';
        }

        public override object DeepCopy()
        {
            ResearchTeam TeamCopy = new ResearchTeam();
            TeamCopy.topic = topic;
            TeamCopy.duration = duration;
            TeamCopy.name = name;
            TeamCopy.number = number;
            TeamCopy.members = new List<Person>();
            TeamCopy.papers = new List<Paper>(); ;
            foreach (Person p in members)
            {
                TeamCopy.members.Add((Person)p.DeepCopy());
            }
            foreach (Paper p in papers)
            {
                TeamCopy.papers.Add((Paper)p.DeepCopy());
            }
            return TeamCopy;
        }

        public System.Collections.IEnumerable NoPublication()
        {
            for (int i = 0; i < members.Count; i++)
            {
                bool noPublication = true;
                Person PersonTemp = (Person)members[i];

                for (int j = 0; j < papers.Count; j++)
                {
                    Paper PaperTemp = (Paper)papers[j];

                    if (PaperTemp.Author == PersonTemp)
                    {
                        noPublication = false;
                    }

                }

                if (noPublication == true)
                {
                    yield return PersonTemp;
                }

            }

        }
        public System.Collections.IEnumerable LastPublications(int n)
        {
            for (int i = 0; i < papers.Count; i++)
            {
                Paper PaperTemp = (Paper)papers[i];

                if (PaperTemp.PublicationDate > DateTime.Today.AddYears(-n))
                {
                    yield return PaperTemp;
                }

            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            return new ResearchTeamEnumerator(members, papers);
        }

        public System.Collections.IEnumerable MoreThanOnePublication()
        {
            foreach (Person member in this)
            {
                int counter = 0;
                foreach (Paper p in papers)
                {
                    if (p.Author == member)
                    {
                        counter++;
                    }
                }
                if (counter > 1)
                {
                    yield return member;
                }
            }
        }

        public System.Collections.IEnumerable LastYearPublications()
        {
            foreach (Paper p in LastPublications(1))
            {
                yield return p;
            }
        }

        public void SortByDate()
        {
            papers.Sort();
        }
        public void SortByTitle()
        {
            papers.Sort(new PaperComp());
        }
        public void SortByAuthor()
        {
            papers.Sort(new PaperCompAuthor());
        }

    }
}
