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
    public partial class EventProgressGraph : Form
    {
        Form myParent;
        DbController dbController = new DbController();
        public EventProgressGraph(Form parent)
        {
            myParent = parent;
            parent.Visible = false;
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
                    if (i <= 0)
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


        private void SaveToFilebtn_Click_1(object sender, EventArgs e)
        {
            saveGraphToFile();
        }

        private void EventProgressGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            myParent.Visible = true;
            this.Dispose();

        }
    }
}
