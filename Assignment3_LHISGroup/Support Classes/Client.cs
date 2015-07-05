using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    public class Client
    {
        private int id;                 // Do not set this attribute, handled by DBMS
        private string firstname;
        private string surname;
        private string contactPerson;
        private string address;
        private string mobile;
        private string homePhone;
        private string email;
        private string engagedTo_firstName;
        private string engagedTo_surname;


        public Client()
        {
            firstname = null;
            surname = null;
        }

        public Client(string name, string surname, string contactPerson, string address, string mobile,
            string homeph, string email, string engagedTo_fn, string engagedTo_sn)
        {
            this.firstname = name;
            this.surname = surname;
            this.contactPerson = contactPerson;
            this.address = address;
            this.mobile = mobile;
            this.homePhone = homeph;
            this.email = email;
            this.engagedTo_firstName = engagedTo_fn;
            this.engagedTo_surname = engagedTo_sn;

        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
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

        public string EngagedTo_fn
        {
            get { return engagedTo_firstName; }
            set { engagedTo_firstName = value; }
        }

        public string EngagedTo_sn
        {
            get { return engagedTo_surname; }
            set { engagedTo_surname = value; }
        }

        public override string ToString()   
        {
            string res = "===Client============\n";
                res += ("[fn]" + firstname + " [sn]" + surname + " [cont]" + contactPerson + " [addr]" + address + " [mob]" +
                mobile + " [ph]" + homePhone + " [email]" + email + " [partner]" + engagedTo_firstName + " "
                + engagedTo_surname);
            return res;
        }

    }
}
