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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm() == true)
            {
                string title = NameTextBox.Text;
                string desc = DescriptionTextBox.Text;
                int wedding_id = ((KeyValuePair<int, string>)WeddingComboBox.SelectedItem).Key;
                Support_Classes.Wedding wedding = db.FindWedding(wedding_id);
                int staff_id = ((KeyValuePair<int, string>)StaffComboBox.SelectedItem).Key;
                Support_Classes.Staff staff = db.FindStaff(staff_id);

                DateTime completeBy = CompleteByDateTimePicker.Value;
                DateTime completion = CompletionDateTimePicker.Value;

                Support_Classes.Task.Priority priority = Support_Classes.Task.Priority.low;
                if (MediumRadioButton.Checked)
                {
                    priority = Support_Classes.Task.Priority.med;
                }
                else if (HighRadioButton.Checked)
                {
                    priority = Support_Classes.Task.Priority.high;
                }

                Support_Classes.Task task = new Support_Classes.Task(title, desc, priority, completeBy, staff, wedding);

                try
                {
                    db.AddTask(task);
                    ClearForm();
                    mainWin.ManageTasksWindow.UpdateForm();
                    this.Visible = false;
                    if (!mainWin.ManageTasksWindow.Visible)
                    {
                        mainWin.ManageTasksWindow.Visible = true;

                    }
                    else
                    {
                        mainWin.ManageTasksWindow.Focus();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }
            }
        }
    }
}
