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
    public partial class ManageStaffWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public ManageStaffWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private void AddStaffButton_Click(object sender, EventArgs e)
        {
            if (!mainWin.NewStaffWindow.Visible)
            {
                mainWin.NewStaffWindow.Visible = true;
            }
            else
            {
                mainWin.NewStaffWindow.Focus();
            }
        }

        private void UpdateStaffButton_Click(object sender, EventArgs e)
        {
            if (!mainWin.UpdateStaffWindow.Visible)
            {
                mainWin.UpdateStaffWindow.Visible = true;
            }
            else
            {
                mainWin.UpdateStaffWindow.Focus();
            }
        }

        public void UpdateForm()
        {
            this.staffTableAdapter.Fill(this.modelDataSet.Staff);
            StaffDataGridView.Update();
            StaffDataGridView.Refresh();
            this.Refresh();
        }

        private void ManageStaffWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.modelDataSet.Staff);

        }

        private void ManageStaffWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
