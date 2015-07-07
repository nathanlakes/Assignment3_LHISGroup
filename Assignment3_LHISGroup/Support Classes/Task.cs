using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    public class Task
    {
        public enum Priority { low, med, high };

        private int id;                     // Do not set this attribute, handled by DBMS
        private string taskName;
        private string description;
        private Priority priority;
        private DateTime completeByDate;
        private Nullable<DateTime> completionDate = null;
        private Staff assignedTo;
        private Wedding wedding;

        public Task()
        {
            taskName = null;
        }

        public Task(string task, string desc, Priority prior, DateTime compBy, Staff assigned, Wedding wed)
        {
            taskName = task;
            description = desc;
            priority = prior;
            completeByDate = compBy;
            completionDate = new DateTime();
            assignedTo = assigned;
            wedding = wed;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Priority TaskPriority
        {
            get { return priority; }
            set { priority = value; }
        }

        public DateTime CompleteBy
        {
            get { return completeByDate.Date; }
            set 
            {
                DateTime today = DateTime.Now.Date;
                DateTime cb = value.Date;

                int v = DateTime.Compare(cb, today);

                if (v < 0)
                {
                    throw new Exception("Date to complete job by must be today or later.");
                }
                else 
                {
                    completeByDate = cb;
                }
            
            }
        }

        /**
         *    Have to test whether returns DateTime.MinValue at user end.
         */
        public Nullable<DateTime> CompletionDate
        {
            get
            {
                if (completionDate.HasValue)
                {
                    return completionDate.Value.Date;
                }
                return DateTime.MinValue; }
            set { completionDate = value; }
        }

        public Staff AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; }
        }

        public Wedding Wedding
        {
            get { return wedding; }
            set { wedding = value; }
        }

        public override string ToString()
        {
            string res = "";
            try
            {
                res += "===Task==========\n";
                res += ("[task]" + taskName + " [desc]" + description + " [priority]" + priority.ToString() +
                    " [completeBy]" + completeByDate.ToShortDateString() +
                    " [competionDate]" + completionDate + " [assignedTo]" + assignedTo.FirstName +
                    " " + assignedTo.Surname + " [wedding]" + wedding.Title);
            }
            catch (Exception) { }

            return res;
        }

    }
}
