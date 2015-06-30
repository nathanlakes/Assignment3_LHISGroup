using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    class Staff
    {
        enum Status { active, inactive };


        private string firstname;
        private string surname;
        private string email;
        private string phone;
        private string notes;
        private Status status; 

        public Staff(string fn, string sn, string em, string ph, string not, Status s)
        {
            firstname = fn;
            surname = sn;
            email = em;
            phone = ph;
            notes = not;
            status = s;
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
       
        public Status StaffStatus
        {
            get { return status; }
            set { status = value; }
        }

    }
}
