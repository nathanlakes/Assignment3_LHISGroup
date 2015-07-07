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
                row.Cells[3].Value = task.CompletionDate;
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
