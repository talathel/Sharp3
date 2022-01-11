using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lab
{
    class Person
    {
        string name;
        string surname;
        DateTime date;

        public Person(string nameValue, string surnameValue, DateTime dateValue)
        {
            name = nameValue;
            surname = surnameValue;
            date = dateValue;
        }
        public Person() : this(" Dima ", "Pupkin ", new DateTime(2002, 12, 5))
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Year
        {
            get { return Date.Year; }
            set { Date = new DateTime(value, Date.Month, Date.Day); }
        }

        public override string ToString() {
            return "Person: " + Name + " "  +  Surname + " " + Date ;
        }

        public string ToShortString()
        {
            return "Person: " + Name + " " + Surname ;
        }

        public override bool Equals(object obj) => this.Equals(obj as Person);

        public bool Equals(Person p)
        {
            if (p is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            if (this.GetType() != p.GetType())
            {
                return false;
            }

            return (name == p.surname) && (date == p.date);
        }

        public override int GetHashCode() => (name,surname,date).GetHashCode();

        public static bool operator ==(Person lhs, Person rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Person lhs, Person rhs) => !(lhs == rhs);

        public object DeepCopy()
        {
            return new Person(name, surname, date);
        }


    }
}