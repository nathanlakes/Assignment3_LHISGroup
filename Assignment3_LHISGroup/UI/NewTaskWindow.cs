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
    public partial class NewTaskWindow : Form
    {
        MainWindow mainWin;
        DbController db;

        List<Support_Classes.Staff> StaffList;
        List<Support_Classes.Wedding> WeddingList;

        public NewTaskWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;

            StaffList = db.GetAllStaff();
            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    StaffComboBox.Items.Add(staff.FirstName + " " + staff.Surname);
                }
            }

            WeddingList = db.GetAllWeddings();
            foreach (Support_Classes.Wedding wedding in WeddingList)
            {
                WeddingComboBox.Items.Add(wedding.Title);
            }

        }

        private bool ValidateForm()
        {
            if (NameTextBox.Text == "" || NameTextBox.Text == null)
            {
                MessageBox.Show("Need name");
                return false;
            }
            else if (DescriptionTextBox.Text == "" || DescriptionTextBox.Text == null)
            {
                MessageBox.Show("Need description");
                return false;
            }
            else if (StaffComboBox.SelectedValue == null)
            {
                MessageBox.Show("Need staff");
                return false;
            }
            else if (WeddingComboBox.SelectedItem == null)
            {
                MessageBox.Show("Need wedding");
                return false;
            }
            else if (CompleteByDateTimePicker.Value == null)
            {
                MessageBox.Show("Need complete by date");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearForm()
        {
            NameTextBox.Text = "";
            DescriptionTextBox.Text = "";

            WeddingComboBox.SelectedItem = null;
            StaffComboBox.SelectedItem = null;

            CompleteByDateTimePicker.Value = DateTime.Now;
            CompletionDateTimePicker.Value = DateTime.Now;
        }

        public void RefreshData()
        {
            StaffList = db.GetAllStaff();
            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    StaffComboBox.Items.Add(staff.FirstName + " " + staff.Surname);
                }
            }

            WeddingList = db.GetAllWeddings();
            foreach (Support_Classes.Wedding wedding in WeddingList)
            {
                WeddingComboBox.Items.Add(wedding.Title);
            }
        }

        private void NewTaskWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
