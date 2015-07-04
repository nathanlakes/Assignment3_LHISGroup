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
    public partial class UpdateTaskWindow : Form
    {
        MainWindow mainWin;
        DbController db;

        List<Support_Classes.Staff> StaffList;
        List<Support_Classes.Wedding> WeddingList;
        
        public UpdateTaskWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            this.db = d;
            this.mainWin = w;

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
        }

        private void UpdateTaskWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
