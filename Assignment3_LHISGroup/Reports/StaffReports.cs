using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment3_LHISGroup.Support_Classes;
using Assignment3_LHISGroup.UI;


namespace Assignment3_LHISGroup.Reports
{
    class StaffReport
    {
        Staff currentStaff;
        List<Support_Classes.Task> assignedTaskList;
        DbController dbController = new DbController();

        public StaffReport()
        {
            assignedTaskList = new List<Support_Classes.Task>();



        }

        public List<Support_Classes.Task> FindTasksAssignedTo(Staff selectedStaff)
        {
            if (selectedStaff.StaffStatus == Staff.Active.inactive)
            {
                Console.WriteLine("Error: Staff Member is inactive");
                return new List<Support_Classes.Task>();
            }
            else
            {
                List<Support_Classes.Task> allTaskList = new List<Support_Classes.Task>();
                allTaskList = dbController.GetAllTasks();
                foreach (Support_Classes.Task task in allTaskList)
                {
                    if (task.AssignedTo.ID == selectedStaff.ID)
                    {
                        DateTime date = task.CompletionDate;
                        assignedTaskList.Add(task);
                    }
                }

                return assignedTaskList;
            }

        }


    }
}
