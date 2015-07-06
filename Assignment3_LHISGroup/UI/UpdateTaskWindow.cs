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

        Support_Classes.Task task;
        int id;
        
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

        public void PopuluateDataFields(Support_Classes.Task t)
        {
            task = t;
            id = t.ID;



            NameTextBox.Text = t.TaskName;
            DescriptionTextBox.Text = t.Description;


            int staff_id = t.AssignedTo.ID;
            string staff_name = t.AssignedTo.FirstName + " " + t.AssignedTo.Surname;
            StaffComboBox.SelectedItem = StaffComboBox.Equals(new KeyValuePair<int, string>(staff_id, staff_name));

            int wedding_id = t.Wedding.ID;
            string wedding_name = t.Wedding.Title;

            WeddingComboBox.SelectedItem = WeddingComboBox.Equals(new KeyValuePair<int, string>(wedding_id, wedding_name));            

            CompleteByDateTimePicker.Value = t.CompleteBy;

            if (t.CompletionDate != null)
            {
                CompletionDateTimePicker.Value = (DateTime)t.CompletionDate;
            }
            else
            {
                CompletionDateTimePicker.Value = DateTime.Now;
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {

        }
    }
}
