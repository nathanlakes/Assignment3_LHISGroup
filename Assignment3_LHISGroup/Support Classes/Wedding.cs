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
        private Client c1;
        private Client c2;
        private DateTime startDate;
        private DateTime eventDate;

        public Wedding(string title, Client c1, Client c2, DateTime startDate, DateTime eventDate)
        {
            this.title = title;
            this.c1 = c1;
            this.c2 = c2;
            this.startDate = startDate;
            this.eventDate = eventDate;
        }
    }
}
