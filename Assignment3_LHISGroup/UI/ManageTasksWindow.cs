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

        List<Support_Classes.Staff> StaffList;
        List<Support_Classes.Wedding> WeddingList;

        public ManageTasksWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;

            StaffList = db.GetAllStaff();
            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    int keyValue = staff.ID;
                    string name = staff.FirstName + " " + staff.Surname;
                    StaffComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
                }
            }

            WeddingList = db.GetAllWeddings();
            foreach (Support_Classes.Wedding wedding in WeddingList)
            {
                int keyValue = wedding.ID;
                string name = wedding.Title;
                WeddingComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
            }

            StaffComboBox.DisplayMember = "Value";
            StaffComboBox.ValueMember = "Key";

            WeddingComboBox.DisplayMember = "Value";
            WeddingComboBox.ValueMember = "Key";
        }

        public void RefreshData()
        {
            StaffList = db.GetAllStaff();
            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    int keyValue = staff.ID;
                    string name = staff.FirstName + " " + staff.Surname;
                    StaffComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
                }
            }

            WeddingList = db.GetAllWeddings();
            foreach (Support_Classes.Wedding wedding in WeddingList)
            {
                int keyValue = wedding.ID;
                string name = wedding.Title;
                WeddingComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
            }

            WeddingList = db.GetAllWeddings();
            foreach (Support_Classes.Wedding wedding in WeddingList)
            {
                int keyValue = wedding.ID;
                string name = wedding.Title;
                WeddingComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
            }
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
            foreach (DataGridViewRow row in TasksDataGridView.Rows)
            {
                row.Visible = true;
            }
        }

        private void SelectTasksForStaff(int id)
        {
            foreach (DataGridViewRow row in TasksDataGridView.Rows)
            {
                int index = TasksDataGridView.ColumnCount - 2;
                if (row.Cells[index].Value.ToString().Equals(""+id)){
                    row.Visible = true;
                } else {
                    row.Visible = false;
                }
            }
        }

        private void SelectTasksForStaff(Support_Classes.Staff staff)
        {
            SelectTasksForStaff(staff.ID);
        }

        private void SelectTasksForWedding(int id)
        {
            foreach (DataGridViewRow row in TasksDataGridView.Rows)
            {
                int index = TasksDataGridView.ColumnCount - 1;
                if (row.Cells[index].Value.ToString().Equals("" + id))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void SelectTasksForWedding(Support_Classes.Wedding wedding) {
            SelectTasksForWedding(wedding.ID);
        }

        private Support_Classes.Task ExtractSelectedRow()
        {
            if (TasksDataGridView.SelectedRows.Count > 0 && TasksDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                string strID = TasksDataGridView.SelectedRows[0].Cells[0].Value.ToString();
                int id = Convert.ToInt16(strID);
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
                mainWin.UpdateTaskWindow.PopuluateDataFields(task);
                if (!mainWin.UpdateTaskWindow.Visible)
                {
                    mainWin.UpdateTaskWindow.Visible = true;
                }
                else
                {
                    mainWin.UpdateTaskWindow.Focus();
                }
            }
            else
            {
                MessageBox.Show("No row selected");
            }
            
        }

        private void DeleteWeddingButton_Click(object sender, EventArgs e)
        {
            Support_Classes.Task delete = ExtractSelectedRow();
            try
            {
                db.DeleteTask(delete.ID);
                UpdateForm();
                MessageBox.Show("Task successfully deleted");
            }
            catch (Exception)
            {
                MessageBox.Show("Exception thrown");
            }
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            this.ClearFilters();
        }

        private void StaffComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ((KeyValuePair<int,string>)StaffComboBox.SelectedItem).Key;
            this.SelectTasksForStaff(id);
        }

        private void WeddingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = ((KeyValuePair<int, string>)WeddingComboBox.SelectedItem).Key;
            this.SelectTasksForWedding(id);
        }

        private void FilterStaffButton_Click(object sender, EventArgs e)
        {
            int id = ((KeyValuePair<int, string>)StaffComboBox.SelectedItem).Key;
            this.SelectTasksForStaff(id);
        }

        private void FilterWeddingButton_Click(object sender, EventArgs e)
        {
            int id = ((KeyValuePair<int, string>)WeddingComboBox.SelectedItem).Key;
            this.SelectTasksForWedding(id);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Reports.EventTaskReport tasksReport = new Reports.EventTaskReport();
            tasksReport.Show();
        }

    }
}
