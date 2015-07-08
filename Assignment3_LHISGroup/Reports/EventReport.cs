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
    public partial class EventReport : Form
    {
        DbController dbController = new DbController();
        List<Wedding> allWeddingList = new List<Wedding>();
        List<Support_Classes.Task> allTasksList = new List<Support_Classes.Task>();

        public EventReport()
        {
            InitializeComponent();

            ADDTODBFORTESTING();

            populateWeddingList();
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
        private void populateWeddingList()
        {
            allWeddingList = dbController.GetAllWeddings();
            if (allWeddingList.Count < 1)
            {
                throw new Exception("No weddings in Database");
            }
            foreach (Wedding wedding in allWeddingList)
            {
                String weddingDetails = wedding.ID + " " + wedding.Title;
                EventListBox.Items.Add(weddingDetails);
            }
        }

        private void populateWeddingDetailsView()
        {
            allWeddingList = dbController.GetAllWeddings();
            allTasksList = dbController.GetAllTasks();

            List<Support_Classes.Task> weddingTasks = new List<Support_Classes.Task>();
            int selWedID = -10;

            String selWed = EventListBox.SelectedItem.ToString();
            try
            {
                selWedID = Convert.ToInt32(selWed.Substring(0, selWed.IndexOf(" ")));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to convert Wedding ID");
            }
            
            foreach (Support_Classes.Task task in allTasksList)
            {
                if(task.Wedding.ID == selWedID)
                {
                    weddingTasks.Add(task);
                }

            }

            foreach (Support_Classes.Task task in weddingTasks)
            {
                DataGridViewRow row = (DataGridViewRow)WeddingDetailsGridView.Rows[0].Clone();
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
                row.Cells[4].Value = task.AssignedTo.FirstName + " " + task.AssignedTo.Surname;
                WeddingDetailsGridView.Rows.Add(row);
                
            }


        }

        private void EventListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WeddingDetailsGridView.Rows.Clear();
            populateWeddingDetailsView();
        }
    }
}
