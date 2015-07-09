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

        // Helper method to populate the Wedding Detials view from database. 
        private void populateWeddingDetailsView()
        {
            List<Wedding> allWeddingList = dbController.GetAllWeddings();
            foreach (Wedding wed in allWeddingList)
            {
                DataGridViewRow row = (DataGridViewRow)WeddingDetailsView.Rows[0].Clone();
                row.Cells[0].Value = wed.ID;
                row.Cells[1].Value = wed.Title;
                row.Cells[2].Value = wed.Client1.ID;
                row.Cells[3].Value = wed.Client2.ID;
                WeddingDetailsView.Rows.Add(row);
            }
        }

        private void EventProgress_Load(object sender, EventArgs e)
        {
            
            populateWeddingDetailsView();
        }

        // Event handler for GraphBtn that generates the graph after clearing existing points.
        private void GenerateGraphBtn_Click(object sender, EventArgs e)
        {
            SaveToFilebtn.Enabled = true;
            EPChart.Series["ExpectedOutstanding"].Points.Clear();
            EPChart.Series["ActualOutstanding"].Points.Clear();

 
            generateGraph();


        }
        
        // Method responsible for graph creation and rendering. 
        private void generateGraph()
        {
            Wedding selectedWedding = new Wedding();
            int ID = -10;

            // ID is found from selectedRow in weddingDetailsView.
            try
            {
                DataGridViewRow row = WeddingDetailsView.SelectedRows[0];
                if(row.Cells.Count < 1)
                {
                    MessageBox.Show("Please Select a Wedding");
                }
                // ID is cast from the first cell value in the selected row.
                ID = (int)row.Cells[0].Value;
                selectedWedding = dbController.FindWedding(ID);
                
            }
            catch (Exception e)
            {
               MessageBox.Show("Failed to Find Wedding");
            }
            Wedding actualWedding = selectedWedding;

            List<Support_Classes.Task> allTasks = dbController.GetAllTasks();
            List<Support_Classes.Task> relatedTasks = new List<Support_Classes.Task>();
            DateTime earliestStartDate = actualWedding.StartDate;
            DateTime latestFinishDate = actualWedding.EventDate;

            // for each Task in all tasks, find tasks related to selected Wedding. 
            foreach (Support_Classes.Task tasks in allTasks)
            {
                if (tasks.Wedding.ID == ID)
                {
                    relatedTasks.Add(tasks);
                }
            }

            // Initialize axis variables. 
            int expectedTasks = 0;
            int actualTasks = 0;
            for (DateTime date = earliestStartDate; date.Date <= latestFinishDate.Date; date = date.AddDays(1))
            {
                foreach (Support_Classes.Task task in relatedTasks)
                {
                    int i = DateTime.Compare(date, task.CompleteBy);
                    if (i <= 0)
                    {
                        expectedTasks += 1;
                    }
                    if (task.CompletionDate == new DateTime())
                    {
                        actualTasks += 1;
                    }
                }

                // Add points to the EPChart in the form of date on X axis and expected/actual tasks on Y.
                if (expectedTasks != Single.NaN)
                {
                    EPChart.Series["ExpectedOutstanding"].Points.AddXY(date, expectedTasks);
                }
                if (actualTasks != Single.NaN)
                {
                    EPChart.Series["ActualOutstanding"].Points.AddXY(date, actualTasks);
                }
                // Reset task variables.
                expectedTasks = 0;
                actualTasks = 0;
            }
        }

        // Helper method that saves graph to file using the EPChart SaveImage method. 
        private void saveGraphToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = path + "\\" +  "WeddingGraph.png";
            this.EPChart.SaveImage(fileName, System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("Event Progress Graph Saved Successfully");
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
