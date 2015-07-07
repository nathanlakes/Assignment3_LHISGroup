using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3_LHISGroup.Reports
{
    public partial class EventTaskReport : Form
    {
        private DbController dbController;
        public EventTaskReport()
        {
            InitializeComponent();
            dbController = new DbController();
            populateTaskDetailsView();
        }
        private void populateTaskDetailsView()
        {
            List<Support_Classes.Task> allTasks = dbController.GetAllTasks();
            foreach (Support_Classes.Task task in allTasks)
            {
                DataGridViewRow row = (DataGridViewRow)TaskDetailsView.Rows[0].Clone();
                row.Cells[0].Value = task.TaskName;
                row.Cells[1].Value = task.Description;
                row.Cells[2].Value = task.TaskPriority;
                row.Cells[3].Value = task.CompleteBy.Date;

                if (task.CompletionDate.HasValue)
                {
                    if (task.CompletionDate.Value.Date.Equals(DateTime.MinValue))
                    {
                        row.Cells[4].Value = "Not Complete";
                    }
                    else
                    {
                        row.Cells[4].Value = task.CompletionDate;
                    }

                }
                else
                {
                    row.Cells[4].Value = "Not Complete";
                }
                row.Cells[5].Value = task.AssignedTo.FirstName + " " + task.AssignedTo.Surname;
                row.Cells[6].Value = task.Wedding.Title;
                TaskDetailsView.Rows.Add(row);
            }
        }

        private void TaskDetailsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TaskDetailsView.Rows.Clear();
            populateTaskDetailsView();
        }
    }
}
