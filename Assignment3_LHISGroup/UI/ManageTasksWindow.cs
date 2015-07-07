using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3_LHISGroup.UI
{
    public partial class ManageTasksWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public ManageTasksWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        public void UpdateForm()
        {
            this.taskTableAdapter.Fill(this.modelDataSet.Task);
            TasksDataGridView.Update();
            TasksDataGridView.Refresh();
            this.Refresh();
        }

        public void RefreshComboBoxes()
        {

        }

        private void ClearFilters()
        {
            
        }

        private void SelectTasksForStaff(int id)
        {

        }

        private void SelectTasksForStaff(Support_Classes.Staff staff)
        {
            SelectTasksForStaff(staff.ID);
        }

        private void SelectTasksForWedding(int id)
        {
            
        }

        private void SelectTasksForWedding(Support_Classes.Wedding wedding) {
            SelectTasksForWedding(wedding.ID);
        }

        private Support_Classes.Task ExtractSelectedRow()
        {
            if (TasksDataGridView.SelectedRows.Count > 0 && TasksDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                int id = (int) TasksDataGridView.SelectedRows[0].Cells[0].Value;

//                string taskName = (string) TasksDataGridView.SelectedRows[0].Cells[1].Value;
//                string description = (string) TasksDataGridView.SelectedRows[0].Cells[2].Value;
//                string priority = (string) TasksDataGridView.SelectedRows[0].Cells[3].Value;
//                string completeByDate = (string) TasksDataGridView.SelectedRows[0].Cells[4].Value;
//                string completionDate = (string) TasksDataGridView.SelectedRows[0].Cells[5].Value;
//                string staff_fk = (string) TasksDataGridView.SelectedRows[0].Cells[6].Value;
//                string event_fk = (string) TasksDataGridView.SelectedRows[0].Cells[7].Value;

//                int staff_id = Convert.ToInt32(staff_fk);
//                int event_id = Convert.ToInt32(event_fk);


//                DateTime date = db.convertStringToDateTime(completeByDate); // complete by date

//                Support_Classes.Task.Priority priorityValue = Support_Classes.Task.Priority.low;
//                if (priority.Contains("m")) {
//                    priorityValue = Support_Classes.Task.Priority.med;
//                } else if (priority.Contains("h")) {
//                    priorityValue = Support_Classes.Task.Priority.high;
//                }

//                Support_Classes.Task task = new Support_Classes.Task(taskName, description, priorityValue, date, db.FindStaff(staff_id), db.FindWedding(event_id));

//                task.ID = id;

//                if (completionDate != "" || completionDate != null)
//                {
//                    task.CompletionDate = db.convertStringToDateTime(completionDate);
//                }

//                return task;

                return db.FindTask(id);
            }
            else
            {
                return null;
            }

        }

        private void ManageTasksWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Staff' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.modelDataSet.Task);

        }

        private void ManageTasksWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            if (!mainWin.NewTaskWindow.Visible)
            {
                mainWin.NewTaskWindow.Visible = true;
            }
            else
            {
                mainWin.NewTaskWindow.Focus();
            }
            
        }

        private void UpdateTaskButton_Click(object sender, EventArgs e)
        {
            Support_Classes.Task task = ExtractSelectedRow();
            if (task != null)
            {
                if (!mainWin.UpdateTaskWindow.Visible)
                {
                    mainWin.UpdateTaskWindow.Visible = true;
                    

                } 
            }



            if (!mainWin.UpdateTaskWindow.Visible)
            {
                mainWin.UpdateTaskWindow.Visible = true;
            }
            else
            {
                mainWin.UpdateTaskWindow.Focus();
            }
            
        }

        private void DeleteWeddingButton_Click(object sender, EventArgs e)
        {

        }

        private void TasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
