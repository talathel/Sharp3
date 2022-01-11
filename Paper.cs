using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    class Paper : IComparable
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public Paper(string titleValue,Person authorValue,DateTime publicationDateValue)
        {
            Title = titleValue;
            Author = authorValue;
            PublicationDate = publicationDateValue;

        }
        public Paper() : this("publ", new Person(), new DateTime(2000,12,12))
        {

        }

        public override string ToString()
        {
            return "Paper: " + Title + " | " + Author.ToShortString() + " | " + PublicationDate + '\n';
        }
        public object DeepCopy()
        {
            return new Paper(Title, Author, PublicationDate);

        }

        //сравнение по дате публикации
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Paper otherPaper = obj as Paper;
            if (otherPaper != null)
                return this.PublicationDate.CompareTo(otherPaper.PublicationDate);
            else
                throw new ArgumentException("Object is not a Paper");
        }

    }

    class PaperComp : IComparer<Paper>
    {
        // сравнение по названию
        public int Compare(Paper x, Paper y)
        {
            if (x.Title.CompareTo(y.Title) != 0)
            {
                return x.Title.CompareTo(y.Title);
            }
            else
            {
                return 0;
            }
        }
    }

    class PaperCompAuthor : IComparer<Paper>
    {
        // сравнение по фамилии автора
        public int Compare(Paper x, Paper y)
        {
            if (x.Author.Surname.CompareTo(y.Author.Surname) != 0)
            {
                return x.Author.Surname.CompareTo(y.Author.Surname);
            }
            else
            {
                return 0;
            }
        }
    }




}
