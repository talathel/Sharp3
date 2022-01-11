using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp_Lab
{
    class Team : INameAndCopy
    {
        protected string name;
        protected int number;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Number
        {
            get { return number; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(number.ToString());
                }
                number = value;
            }
        }
        public Team(string NameValue, int NumberValue)
        {
            name = NameValue;
            number = NumberValue;
        }
        public Team() : this("Name",0)
        {

        }

        public override bool Equals(object obj) => this.Equals(obj as Team);

        public bool Equals(Team p)
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

            return (name == p.name) && (number == p.number);
        }
        public override int GetHashCode() => (name,number).GetHashCode();
        public static bool operator ==(Team lhs, Team rhs)
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
        public static bool operator !=(Team lhs, Team rhs) => !(lhs == rhs);

        public override string ToString()
        {
            return "Team: " + name + " " + number;
        }

        public virtual object DeepCopy()
        {   
            Team TeamCopy = new Team(name,number);
            return TeamCopy;
        }

    }
}
