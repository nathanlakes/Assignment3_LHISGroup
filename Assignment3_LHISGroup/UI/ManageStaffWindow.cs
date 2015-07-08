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

        private Support_Classes.Staff ExtractSelectedRow()
        {
            if (StaffDataGridView.SelectedRows.Count > 0 && StaffDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                int id = (int)StaffDataGridView.SelectedRows[0].Cells[0].Value;

//                string fn = (string)StaffDataGridView.SelectedRows[0].Cells[1].Value;
//                string sn = (string)StaffDataGridView.SelectedRows[0].Cells[2].Value;
//                string email = (string)StaffDataGridView.SelectedRows[0].Cells[3].Value;
//                string phone = (string)StaffDataGridView.SelectedRows[0].Cells[4].Value;
//                string notes = (string)StaffDataGridView.SelectedRows[0].Cells[5].Value;
//                string status = (string)StaffDataGridView.SelectedRows[0].Cells[6].Value;

//                Support_Classes.Staff.Active active = Support_Classes.Staff.Active.active;
//                if (active.ToString().ToLower().Contains("f"))
//                {
//                    active = Support_Classes.Staff.Active.inactive;
//                }

//               Support_Classes.Staff staff = new Support_Classes.Staff(fn, sn, email, phone, notes, active);
//                staff.ID = id;
//                return staff;

                return db.FindStaff(id);
            }
            else
            {
                return null;
            }

        }

        private void UpdateStaffButton_Click(object sender, EventArgs e)
        {
            Support_Classes.Staff staff = ExtractSelectedRow();
            if (staff != null)
            {
                mainWin.UpdateStaffWindow.PopulateForm(staff);
                if (!mainWin.UpdateStaffWindow.Visible)
                {
                    mainWin.UpdateStaffWindow.Visible = true;
                }
                else
                {
                    mainWin.UpdateStaffWindow.Focus();
                }
            }
            else
            {
                MessageBox.Show("No row selected");
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

        private void ReportButton_Click(object sender, EventArgs e)
        {
            Reports.StaffReport staffReport = new Reports.StaffReport();
            staffReport.Show();
        }
    }
}
