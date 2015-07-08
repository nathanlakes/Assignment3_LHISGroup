using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    public class Wedding
    {
        public enum Status { Underway, Finished, OnHold, Cancelled, InPreparation };

        private int id;                 // Do not set this attribute, handled by DBMS
        private string title;
        private string description;
        private Client client1;
        private Client client2;
        private DateTime startDate;
        private DateTime eventDate;
        private Staff weddingPlanner;
        private Status status;

        public Wedding()
        {
            title = null;
        }


        public Wedding(string title, string description, Client c1, Client c2, 
            Staff staff, DateTime startDate, DateTime eventDate, Status status)
        {
            this.title = title;
            this.description = description;
            this.client1 = c1;
            this.client2 = c2;
            this.weddingPlanner = staff;
            this.startDate = startDate;
            this.eventDate = eventDate;
            this.status = status;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Client Client1
        {
            get { return client1; }
            set { client1 = value; }
        }

        public Client Client2
        {
            get { return client2; }
            set { client2 = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }

        public Staff WeddingPlanner
        {
            get { return weddingPlanner; }
            set { weddingPlanner = value; }
        }

        public Status WeddingStatus
        {
            get { return status; }
            set { this.status = value; }
        }

        public override string ToString()
        {
            string res = "===Wedding=======\n";
            res += ("[title]" + title + " [desc]" + description + " [client1]" + client1.Firstname + " " + client1.Surname +
                " [client2]" + client2.Firstname + " " + client2.Surname +
                " [startDate]" + startDate.ToShortDateString() + " [eventDate]" + eventDate.ToShortDateString() +
                " [staff]" + weddingPlanner.FirstName + " " + weddingPlanner.Surname + " [status]" + status.ToString());


            return res;
        }
    }
}
