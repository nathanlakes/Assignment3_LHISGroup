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
    public partial class StaffReport : Form
    {
        
       
        DbController dbController = new DbController();

        public StaffReport()
        {
            InitializeComponent();
            populateStaffList();

        }

        // Helper method that populates a list of all active staff
        private void populateStaffList()
        {
            // Constructs a list of all staff from database.
            List<Staff> staffList = new List<Staff>();
            staffList = dbController.GetAllStaff();
            // Checks to ensure staff exist. 
            if (staffList.Count < 1)
            {
                MessageBox.Show("No staff in Database");
            }
            else
            {
                // for each staff, only active staff are added to the staffDetails list.
                foreach (Staff item in staffList)
                {
                    if (item.StaffStatus == Staff.Active.active)
                    {
                        String staffDetails = item.ID + " " + item.FirstName + " " + item.Surname;
                        StaffListBox.Items.Add(staffDetails);
                    }

                }
            }
                      
        }

        // Helper method popualtes assigned Tasks list.
        private void assignedTasksListForSelectedStaff()
        {
            // Generates the complete staff and task list from database. 
            List<Support_Classes.Task> assignedTasksList = new List<Support_Classes.Task>();
            List<Support_Classes.Task> allTaskList = dbController.GetAllTasks();

            int selStaffID = -10;
            String selStaff = StaffListBox.SelectedItem.ToString();

            // Staff ID is retrieved from the substring of the selected listbox row.
            try
            {
                 selStaffID = Convert.ToInt32(selStaff.Substring(0, selStaff.IndexOf(" ")));
            }
            catch(Exception e)
            {
                
            }

            foreach (Support_Classes.Task task in allTaskList)
            {
                // for each task that is assigned to the current staff member, add it to assigned tasks list. 
                if(task.AssignedTo.ID == selStaffID)
                {
                    assignedTasksList.Add(task);
                }
            }
            // call to populateTasksview with assignedTasks list just created.  
            populateTasksGridView(assignedTasksList);
            
        }

        

        private void StaffListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TasksView.Rows.Clear();
            assignedTasksListForSelectedStaff();
        }
        
        // helper method that converts the assigned task list given into a gridview row with the 
        // required information. 
        private void populateTasksGridView(List<Support_Classes.Task> assignedTasks)
        {
            foreach(Support_Classes.Task task in assignedTasks)
            {
                DataGridViewRow row = (DataGridViewRow)TasksView.Rows[0].Clone();
                row.Cells[0].Value = task.TaskName;
                row.Cells[1].Value = task.Description;
                row.Cells[2].Value = task.CompleteBy;
                TasksView.Rows.Add(row);
            }
            
        }

        

    }
}
