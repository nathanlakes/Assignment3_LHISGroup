﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup.Support_Classes
{
    public class Task
    {
        public enum Priority { low, med, high };
        
        private string taskName;
        private string description;
        private Priority priority;
        private DateTime completeByDate;
        private DateTime completionDate;
        private Staff assignedTo;


        public Task(string task, string desc, Priority prior, DateTime compBy, Staff assigned)
        {
            taskName = task;
            description = desc;
            priority = prior;
            completeByDate = compBy;
            completionDate = new DateTime();
            assignedTo = assigned;
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

    }
}
