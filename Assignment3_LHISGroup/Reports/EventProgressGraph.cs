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

        private void GenerateGraphBtn_Click(object sender, EventArgs e)
        {
            SaveToFilebtn.Enabled = true;
            EPChart.Series["ExpectedOutstanding"].Points.Clear();
            EPChart.Series["ActualOutstanding"].Points.Clear();

 
            generateGraph();


        }
        
        private void generateGraph()
        {
            Wedding selectedWedding = new Wedding();
            int ID = -10;
            try
            {
                DataGridViewRow row = WeddingDetailsView.SelectedRows[0];
                if(row.Cells.Count < 1)
                {
                    MessageBox.Show("Please Select a Wedding");
                }
                ID = (int)row.Cells[0].Value;
                Console.WriteLine("ARE WE GETTING HERE");
                selectedWedding = dbController.FindWedding(ID);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Failed to Find Wedding");
            }
            Wedding actualWedding = selectedWedding;
            List<Support_Classes.Task> allTasks = dbController.GetAllTasks();
            List<Support_Classes.Task> relatedTasks = new List<Support_Classes.Task>();
            DateTime earliestStartDate = actualWedding.StartDate;
            DateTime latestFinishDate = actualWedding.EventDate;
            foreach (Support_Classes.Task thing in allTasks)
            {
                if (thing.Wedding.ID == ID)
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

        private void saveGraphToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = path + "\\" +  "WeddingGraph.png";
            this.EPChart.SaveImage(fileName, System.Drawing.Imaging.ImageFormat.Png);
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
