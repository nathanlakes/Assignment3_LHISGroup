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
            if (StaffDataGridView.SelectedRows.Count > 0 && StaffDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                int id = (int)StaffDataGridView.SelectedRows[0].Cells[0].Value;

                string fn = (string) StaffDataGridView.SelectedRows[0].Cells[1].Value;
                string sn = (string)StaffDataGridView.SelectedRows[0].Cells[2].Value;
                string email = (string)StaffDataGridView.SelectedRows[0].Cells[3].Value;
                string phone = (string)StaffDataGridView.SelectedRows[0].Cells[4].Value;
                string notes = (string)StaffDataGridView.SelectedRows[0].Cells[5].Value;
                string status = (string)StaffDataGridView.SelectedRows[0].Cells[6].Value;

                Support_Classes.Staff.Active active = Support_Classes.Staff.Active.active;
                if (active.ToString().ToLower().Contains("f"))
                {
                    active = Support_Classes.Staff.Active.inactive;
                }

                Support_Classes.Staff s = new Support_Classes.Staff(fn, sn, email, phone, notes, active);
                s.ID = id;

                if (!mainWin.UpdateStaffWindow.Visible)
                {
                    mainWin.UpdateStaffWindow.Visible = true;
                    mainWin.UpdateStaffWindow.PopulateForm(s);
                }
                else
                {
                    mainWin.UpdateStaffWindow.Focus();
                    mainWin.UpdateStaffWindow.PopulateForm(s);
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
    }
}
