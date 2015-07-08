using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment3_LHISGroup.Support_Classes;

namespace Assignment3_LHISGroup.Reports
{
    public partial class EventProgress : Form
    {
        DbController dbController = new DbController();
        public EventProgress()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void EventProgress_Load(object sender, EventArgs e)
        {
            updateWeddingsList();
        }
        private void updateWeddingsList()
        {
            List<Support_Classes.Wedding> allWeddings = dbController.GetAllWeddings();
            if (allWeddings.Count == 0)
            {
                AllWeddingslbl.Text = "No Weddings In Database!";
            }
            else
            {
                AllWeddingslbl.Text = "";
                foreach (Support_Classes.Wedding wedding in allWeddings)
                {
                    AllWeddingslbl.Text += wedding.Title + "\n";
                }
            }
        }
        private void GenerateGraphBtn_Click(object sender, EventArgs e)
        {
            SaveToFilebtn.Enabled = true;
            EPChart.Series["ExpectedOutstanding"].Points.Clear();
            EPChart.Series["ActualOutstanding"].Points.Clear();
            
            Support_Classes.Client testClient1 = new Client("Jim", "Bastiras", "Daniel Stone", "1 Cherry Lane", "555-666", "555-666", "JimmyBoy@gmail.com", "Nathan", "Lakes");
            Support_Classes.Client testClient2 = new Client("Nathan", "Lakes", "Daniel Stone", "2 Cherry Lane", "555-777", "555-777", "N.Lakes@gmail.com", "Jim", "Bastiras");
            Support_Classes.Staff testStaff = new Staff("Daniel", "Stone", "daniel.Stone@gmail.com", "555-888", "Furiously Jealous", Support_Classes.Staff.Active.active);
            Support_Classes.Wedding testWedding = new Wedding("MARRIAGE", "controversial", testClient1, testClient2, testStaff, new DateTime(2015, 8, 1),
                new DateTime(2015, 8, 30),  Support_Classes.Wedding.Status.InPreparation);
            dbController.AddClient(testClient1);
            dbController.AddClient(testClient2);
            dbController.AddStaff(testStaff);
            dbController.AddWedding(testWedding);

            Support_Classes.Task testTask1 = new Support_Classes.Task("Task 1", "Help 1", Support_Classes.Task.Priority.low, new DateTime(2015,8, 2), testStaff, testWedding);
            Support_Classes.Task testTask2 = new Support_Classes.Task("Task 2", "Help 2", Support_Classes.Task.Priority.low, new DateTime(2015, 8, 4), testStaff, testWedding);
            Support_Classes.Task testTask3 = new Support_Classes.Task("Task 3", "Help 3", Support_Classes.Task.Priority.low, new DateTime(2015, 8, 15), testStaff, testWedding);
            Support_Classes.Task testTask4 = new Support_Classes.Task("Task 4", "Help 4", Support_Classes.Task.Priority.low, new DateTime(2015, 8, 17), testStaff, testWedding);
            Support_Classes.Task testTask5 = new Support_Classes.Task("Task 5", "Help 5", Support_Classes.Task.Priority.low, new DateTime(2015, 8, 20), testStaff, testWedding);

            dbController.AddTask(testTask1);
            dbController.AddTask(testTask2);
            dbController.AddTask(testTask3);
            dbController.AddTask(testTask4);
            dbController.AddTask(testTask5);
            if (WeddingNameTxtBx.Text == "")
            {
                MessageBox.Show("Must enter a string name for wedding");
                return;
            }
            generateGraph(WeddingNameTxtBx.Text);
            updateWeddingsList();

        }
        private void saveGraphToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = path + "\\" + WeddingNameTxtBx.Text + ".png";
            this.EPChart.SaveImage(fileName, System.Drawing.Imaging.ImageFormat.Png);
        }
        private void generateGraph(String weddingName)
        {
            List<Support_Classes.Wedding> actualWeddingList = dbController.FindWedding(weddingName);
            if (actualWeddingList.Count == 0)
            {
                MessageBox.Show("No wedding found with this title.");
                return;
            }
            Support_Classes.Wedding actualWedding = actualWeddingList.First();
            List<Support_Classes.Task> allTasks = dbController.GetAllTasks();
            List<Support_Classes.Task> relatedTasks = new List<Support_Classes.Task>();
            DateTime earliestStartDate = actualWedding.StartDate;
            DateTime latestFinishDate = actualWedding.EventDate;
            foreach (Support_Classes.Task thing in allTasks)
            {
                if (thing.Wedding.Title == weddingName)
                {
                    relatedTasks.Add(thing);
                }
            }
            int expectedTasks = 0;
            int actualTasks = 0;
            for (DateTime date = earliestStartDate; date.Date <= latestFinishDate.Date; date = date.AddDays(1))
            {
                foreach (Support_Classes.Task thing in relatedTasks)
                {
                    int i = DateTime.Compare(date, thing.CompleteBy);
                    if ( i <= 0)
                    {
                        expectedTasks += 1;
                    }
                    if (thing.CompletionDate == new DateTime())
                    {
                        actualTasks += 1;
                    }
                }
                EPChart.Series["ExpectedOutstanding"].Points.AddXY(date, expectedTasks);
                EPChart.Series["ActualOutstanding"].Points.AddXY(date, actualTasks);
                expectedTasks = 0;
                actualTasks = 0;
            }
        }

        private void SaveToFilebtn_Click(object sender, EventArgs e)
        {
            saveGraphToFile();
        }
    }
}
