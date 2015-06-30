using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    class Client
    {
        public enum Gender { male, female };

        private string name;
        private Gender gender;
        private string contactPerson;
        private string address;
        private string mobile;
        private string homePhone;
        private string email;
        private Client engagedTo;


        public Client(string name, Gender g, string contact, string address, string mobile,
            string homeph, string email, Client engagedTo)
        {
            this.name = name;
            this.gender = g;
            this.contactPerson = contact;
            this.address = address;
            this.mobile = mobile;
            this.homePhone = homeph;
            this.email = email;
            this.engagedTo = engagedTo;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Gender ClientGender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string HomePhone
        {
            get { return homePhone; }
            set { homePhone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Client EngagedTo
        {
            get { return engagedTo; }
            set { engagedTo = value; }
        }
    
    }
}
