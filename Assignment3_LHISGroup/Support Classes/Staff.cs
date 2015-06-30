using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    class Staff
    {

        private string firstname;
        private string surname;
        private string email;
        private string phone;
        private string notes;
        private bool active; 

        public Staff(string firstn, string surn, string email, string ph, string note, bool status)
        {
            this.firstname = firstn;
            this.surname = surn;
            this.email = email;
            this.phone = ph;
            this.notes = note;
            this.active = status;
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
       
        public bool StaffStatus
        {
            get { return active; }
            set { active = value; }
        }

    }
}
