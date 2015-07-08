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

namespace Assignment3_LHISGroup.Reports
{
    public partial class EventTaskReport : Form
    {
        private DbController dbController;
        public EventTaskReport()
        {
            InitializeComponent();
            dbController = new DbController();
            ADDTODBFORTESTING();
            
            populateTaskDetailsView();
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

            Wedding testWedding = new Wedding("Gay Rites", "notacakewalk", testClient1, testClient2, testStaff1, new DateTime(2014, 1, 18), new DateTime(2014, 1, 22), Wedding.Status.InPreparation);
            Support_Classes.Task testTask = new Support_Classes.Task("testing0", "does things", testPrio, new DateTime(2014, 1, 18), testStaff1, testWedding);
            Support_Classes.Task testTask1 = new Support_Classes.Task("testing1", "WHAT EVEN things", testPrio, new DateTime(2014, 1, 18), testStaff1, testWedding);
            Support_Classes.Task testTask2 = new Support_Classes.Task("testing2", "does MOREAAAHHH THINGZZZZ things", testPrio, new DateTime(2014, 1, 18), testStaff1, testWedding);



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

        private void populateTaskDetailsView()
        {
            List<Support_Classes.Task> allTasks = dbController.GetAllTasks();
            foreach (Support_Classes.Task task in allTasks)
            {
                DataGridViewRow row = (DataGridViewRow)TaskDetailsView.Rows[0].Clone();
                row.Cells[0].Value = task.TaskName;
                row.Cells[1].Value = task.Description;
                row.Cells[2].Value = task.TaskPriority;
                row.Cells[3].Value = task.CompleteBy.Date;

                if (task.CompletionDate.HasValue)
                {
                    if (task.CompletionDate.Value.Date.Equals(DateTime.MinValue))
                    {
                        row.Cells[4].Value = "Not Complete";
                    }
                    else
                    {
                        row.Cells[4].Value = task.CompletionDate;
                    }

                }
                else
                {
                    row.Cells[4].Value = "Not Complete";
                }
                row.Cells[5].Value = task.AssignedTo.FirstName + " " + task.AssignedTo.Surname;
                row.Cells[6].Value = task.Wedding.Title;
                TaskDetailsView.Rows.Add(row);
            }
        }

        private void TaskDetailsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TaskDetailsView.Rows.Clear();
            populateTaskDetailsView();
        }
        private void generateEventTaskReport()
        {
            CSVWriter report = new CSVWriter("EventTaskReport");
            report.WriteTasksToFile(dbController.GetAllTasks());
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {

            generateEventTaskReport();
            MessageBox.Show("Report Created on Desktop Successfully");
        }
    }
}
