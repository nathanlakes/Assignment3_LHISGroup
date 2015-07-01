using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    /**
     *   An employee of the Wedding Planning busines.
     */
    public class Staff
    {
        public enum Active { active, inactive }

        private int id;
        private string firstname;
        private string surname;
        private string email;
        private string phone;
        private string notes;
        private Active active; 

        public Staff(string firstn, string surn, string email, string ph, string note, Active status)
        {
            this.firstname = firstn;
            this.surname = surn;
            this.email = email;
            this.phone = ph;
            this.notes = note;
            this.active = status;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
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

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public Active StaffStatus
        {
            get { return active; }
            set { active = value; }
        }

        public string StatusToString()
        {
            if (active == Active.inactive) return "inactive";
            else return "active";
        }

    }
}
