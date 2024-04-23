using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname = "";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Name);
        }
    }
}
