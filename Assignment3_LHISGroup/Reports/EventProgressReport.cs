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
            populateWeddingDetailsView();

            // 
            //   Make DGVs fill width, looks better.
            // 
            this.WeddingDetailsView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.WeddingDetailsView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.WeddingDetailsView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.WedTasksView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.WedTasksView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.WedTasksView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            
        }
        // Helper Method to populate the Wedding Details Grid View from database.
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
        // Helper Method to populate the Wedding Tasks Grid View from database.
        private void populateWeddingTasksView()
        {
            WedTasksView.Rows.Clear();
            Wedding selectedWedding = new Wedding();
            allWeddingList = dbController.GetAllWeddings();
            allTasksList = dbController.GetAllTasks();

            List<Support_Classes.Task> weddingTasks = new List<Support_Classes.Task>();
            int selWedID = -10;

            // Selected row is converted into a Wedding object using FindWedding by Title.
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
                
            }
            // Tasks that have been assigned to the wedding are stored in a list.
            foreach (Support_Classes.Task task in allTasksList)
            {
                if (task.Wedding.ID == selWedID)
                {
                    weddingTasks.Add(task);
                }

            }
            currentWeddingTasks = weddingTasks;
            // For each assigned task build a grid view row of the required information. 
            foreach (Support_Classes.Task task in weddingTasks)
            {
                DataGridViewRow row = (DataGridViewRow)WedTasksView.Rows[0].Clone();
                row.Cells[0].Value = task.TaskName;
                row.Cells[1].Value = task.TaskPriority;
                row.Cells[2].Value = task.CompleteBy;
                if (task.CompletionDate.HasValue)
                {
                    if (task.CompletionDate.Value.Date.CompareTo(new DateTime(2015, 1, 1, 0, 0, 0)) < 1)
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
            WedTasksView.Refresh();
            
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

        // Generates the CSV equivalent of the report for later viewing. 
        // Uses the CSVWriter helper class to handle File IO and formatting.
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

        private void WeddingDetailsView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            WedTasksView.Rows.Clear();
            populateWeddingTasksView();
        }


    }
}
