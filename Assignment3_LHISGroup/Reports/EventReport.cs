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
        private DbController dbController = new DbController();
        private List<Wedding> allWeddingList = new List<Wedding>();
        private List<Support_Classes.Task> allTasksList = new List<Support_Classes.Task>();
        private List<Support_Classes.Task> currentWeddingTasks = new List<Support_Classes.Task>();

        public EventReport()
        {
            InitializeComponent();

            //ADDTODBFORTESTING();

            populateWeddingList();
            
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

            
            try
            {
                String selWed = EventListBox.SelectedItem.ToString();
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
            currentWeddingTasks = weddingTasks;
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
        private void generateEventReport()
        {
            CSVWriter report = new CSVWriter("EventReport");
            int selWedID = -10;
            try
            {
                String selWed = EventListBox.SelectedItem.ToString();
                selWedID = Convert.ToInt32(selWed.Substring(0, selWed.IndexOf(" ")));

                List<Wedding> wedList = new List<Wedding>();
                wedList.Add(dbController.FindWedding(selWedID));
                
                report.WriteWeddingToFile(wedList);
                if (currentWeddingTasks.Count > 0)
                {
                    report.WriteEventReportTasksToFile(currentWeddingTasks);
                }

                MessageBox.Show("Event Report Generation Successful");
            }
            catch (Exception e)
            {
                MessageBox.Show("Report Generation Failed");
            }
            
        }

        private void GenerateEventReportButton_Click(object sender, EventArgs e)
        {
            generateEventReport();
        }

        
    }
}
