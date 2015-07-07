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

        

        private void populateStaffList()
        {
            List<Staff> staffList = new List<Staff>();
            staffList = dbController.GetAllStaff();
            if (staffList.Count < 1)
            {
                throw new Exception("No staff in Database");
            }
            foreach(Staff item in staffList )
            {
                if (item.StaffStatus == Staff.Active.active)
                {
                    String staffDetails = item.ID + " " + item.FirstName + " " + item.Surname;
                    StaffListBox.Items.Add(staffDetails);
                }

            }
            
        }

        private void assignedTasksListForSelectedStaff()
        {
            List<Support_Classes.Task> assignedTasksList = new List<Support_Classes.Task>();
            List<Support_Classes.Task> allTaskList = dbController.GetAllTasks();
            int selStaffID = -10;
            String selStaff = StaffListBox.SelectedItem.ToString();
            try
            {
                 selStaffID = Convert.ToInt32(selStaff.Substring(0, selStaff.IndexOf(" ")));
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to convert Staff ID");
            }
          
            
            foreach (Support_Classes.Task task in allTaskList)
            {
                
                if(task.AssignedTo.ID == selStaffID)
                {
                    assignedTasksList.Add(task);
                }
            }
           
            populateTasksGridView(assignedTasksList);
            
        }

        private void StaffReport_Load(object sender, EventArgs e)
        {

        }

        private void StaffListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TasksView.Rows.Clear();
            assignedTasksListForSelectedStaff();
        }

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

        private void TasksView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

    }
}
