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
   
            ADDTODBFORTESTING();

            populateStaffList();

        }

        private void ADDTODBFORTESTING()
        {
            
            
            Staff testStaff1 = new Staff("Jim", "Bastiras", "email", "00000", "blah blah", Staff.Active.active);
            Staff testStaff2 = new Staff("Bob", "Bastiras", "email", "00340", "blah blah", Staff.Active.inactive);
            Staff testStaff3 = new Staff("Lilly", "Bastiras", "email", "10403", "blah blah", Staff.Active.inactive);
            Staff testStaff4 = new Staff("James", "Bastiras", "email", "15094", "blah blah", Staff.Active.active);

            Support_Classes.Task.Priority testPrio = Support_Classes.Task.Priority.high;

            Client testClient1 = new Client("Jimmy", "Bastiras", "kalfslasf", "aflklsafl", "00000000000", "00340602", "gmail", "Daniel", "Stone");
            Client testClient2 = new Client("Daniel", "Stone", "kalfslasf", "aflklsafl", "00000000000", "00340602", "gmail", "Jimmy", "Bastiras");

            Wedding testWedding = new Wedding("Gay Rites", "notacakewalk", testClient1, testClient2, testStaff1, new DateTime(2014, 1, 18), new DateTime(2014, 1, 22));
            Support_Classes.Task testTask = new Support_Classes.Task("testing0", "does things", testPrio, new DateTime(), testStaff1, testWedding);
            Support_Classes.Task testTask1 = new Support_Classes.Task("testing1", "WHAT EVEN things", testPrio, new DateTime(), testStaff1, testWedding);
            Support_Classes.Task testTask2 = new Support_Classes.Task("testing2", "does MOREAAAHHH THINGZZZZ things", testPrio, new DateTime(), testStaff1, testWedding);

            
            dbController.AddStaff(testStaff1);
            dbController.AddStaff(testStaff2);
            dbController.AddStaff(testStaff3);
            dbController.AddStaff(testStaff4);

            dbController.AddClient(testClient1);
            dbController.AddClient(testClient2);

            dbController.AddWedding(testWedding);

            dbController.AddTask(testTask);
            dbController.AddTask(testTask1);
            dbController.AddTask(testTask2);

            
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
          
            List<Support_Classes.Task> assignedTasksList = new List<Support_Classes.Task>();
            List<Support_Classes.Task> allTaskList = dbController.GetAllTasks();
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
