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

        }

        private void GenerateGraphBtn_Click(object sender, EventArgs e)
        {

        }

        private void generateGraph(String weddingName)
        {
            List<Support_Classes.Wedding> actualWeddingList = dbController.FindWedding(weddingName);
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

            for (DateTime date = earliestStartDate; date.Date <= latestFinishDate.Date; date = date.AddDays(1))
            {

            }
        }
    }
}
