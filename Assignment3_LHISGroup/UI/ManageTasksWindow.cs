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
    }
}
