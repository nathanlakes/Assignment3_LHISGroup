using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    class Wedding
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
    }
}
