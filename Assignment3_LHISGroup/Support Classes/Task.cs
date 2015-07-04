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
        private DateTime completionDate;
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
         *    TODO: Possible conflict, as DateTime does not allow null 
         *    cannot test if not been set like Java. 
         *    Find work around, if needed. Existing method may well perform
         *    sufficiently, although it's not pretty.
         *    -- Nathan
         */
        public DateTime CompletionDate
        {
            get 
            {   
                int v = DateTime.Compare(new DateTime(), completionDate);
                if (v == 0)
                {
                    throw new Exception("No Completion Date has been set");
                }
                return completionDate.Date; 
            }
            set
            {
                DateTime today = DateTime.Now.Date;

                int v = DateTime.Compare(value.Date, today);
                if (v < 0)
                {
                    throw new Exception("Cannot Mark Job as completed earlier than today.");
                }
                else
                {
                    completionDate = value.Date;
                }
            }
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

    }
}
