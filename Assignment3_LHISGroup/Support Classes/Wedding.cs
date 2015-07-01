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

        private string title;
        private Client client1;
        private Client client2;
        private DateTime startDate;
        private DateTime eventDate;
        private Staff weddingPlanner;

        public Wedding(string title, Client c1, Client c2, Staff staff, DateTime startDate, DateTime eventDate)
        {
            this.title = title;
            this.client1 = c1;
            this.client2 = c2;
            this.weddingPlanner = staff;
            this.startDate = startDate;
            this.eventDate = eventDate;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
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
    }
}
