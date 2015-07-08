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
    public partial class EventProgressReport : Form
    {
        DbController dbController;
        List<Wedding> allWeddingList;
        List<Support_Classes.Task> allTasksList;
        List<Support_Classes.Task> currentWeddingTasks = new List<Support_Classes.Task>();
        Form myParent;

        public EventProgressReport(Form parent)
        {
            myParent = parent;
            InitializeComponent();

            dbController = new DbController();
            ADDTODBFORTESTING();
            populateWeddingDetailsView();

            
            
            
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

        private void populateWeddingDetailsView()
        {
            allWeddingList = dbController.GetAllWeddings();
            foreach (Wedding wed in allWeddingList)
            {
                DataGridViewRow row = (DataGridViewRow)WeddingDetailsView.Rows[0].Clone();
                row.Cells[0].Value = wed.Title;
                row.Cells[1].Value = wed.StartDate;
                row.Cells[2].Value = wed.EventDate;
                WeddingDetailsView.Rows.Add(row);
            }
        }

        private void populateWeddingTasksView()
        {
            Wedding selectedWedding = new Wedding();
            allWeddingList = dbController.GetAllWeddings();
            allTasksList = dbController.GetAllTasks();

            List<Support_Classes.Task> weddingTasks = new List<Support_Classes.Task>();
            int selWedID = -10;


            try
            {
                DataGridViewRow row = WeddingDetailsView.SelectedRows[0];
                if(row.Cells.Count < 1)
                {
                    MessageBox.Show("Please Select a Wedding");
                }
                String title = row.Cells[0].Value.ToString();
                
                selectedWedding = dbController.FindWedding(title)[0];
                selWedID = selectedWedding.ID;
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to Find Wedding");
            }

            foreach (Support_Classes.Task task in allTasksList)
            {
                if (task.Wedding.ID == selWedID)
                {
                    weddingTasks.Add(task);
                }

            }
            currentWeddingTasks = weddingTasks;
            foreach (Support_Classes.Task task in weddingTasks)
            {
                DataGridViewRow row = (DataGridViewRow)WedTasksView.Rows[0].Clone();
                row.Cells[0].Value = task.TaskName;
                row.Cells[1].Value = task.TaskPriority;
                row.Cells[2].Value = task.CompleteBy;
                if (task.CompletionDate.HasValue)
                {
                    if (task.CompletionDate.Value.Date.Equals(DateTime.MinValue))
                    {
                        row.Cells[3].Value = "Not Complete";
                    }
                    else
                    {
                        row.Cells[3].Value = task.CompletionDate;
                    }

                }
                else
                {
                    row.Cells[3].Value = "Not Complete";
                }

                WedTasksView.Rows.Add(row);

            }


        }

        private void WeddingDetailsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            WedTasksView.Rows.Clear();
            populateWeddingTasksView();
           
        }

        private void GenerateEventReportButton_Click(object sender, EventArgs e)
        {
            generateEventReport();
        }

        private void generateEventReport()
        {
            CSVWriter report = new CSVWriter("EventProgressReport");
            
            try
            {
                DataGridViewRow row = WeddingDetailsView.SelectedRows[0];
                if (row.Cells.Count < 1)
                {
                    MessageBox.Show("Please Select a Wedding");
                }
                String title = row.Cells[0].Value.ToString();

                Wedding selectedWedding = dbController.FindWedding(title)[0];
                List<Wedding> wedList = new List<Wedding>();
                wedList.Add(selectedWedding);

                report.WriteEventProgressReportWeddingToFile(wedList);
                if (currentWeddingTasks.Count > 0)
                {
                    report.WriteEventProgressReportTasksToFile(currentWeddingTasks);
                }

                MessageBox.Show("Event Report Generation Successful");
            }
            catch (Exception e)
            {
                MessageBox.Show("Report Generation Failed");
            }

        }


    }
}
