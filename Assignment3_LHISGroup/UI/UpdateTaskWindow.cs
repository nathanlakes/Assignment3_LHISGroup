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
        bool IsCompleted; // to check if the task is completed
        
        public UpdateTaskWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            this.db = d;
            this.mainWin = w;
            this.IsCompleted = false;

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

        public void PopuluateDataFields(Support_Classes.Task t)
        {
            task = t;
            id = t.ID;

            NameTextBox.Text = t.TaskName;
            DescriptionTextBox.Text = t.Description;


            int staff_id = t.AssignedTo.ID;
            //string staff_name = t.AssignedTo.FirstName + " " + t.AssignedTo.Surname;
            //StaffComboBox.SelectedItem = StaffComboBox.Equals(new KeyValuePair<int, string>(staff_id, staff_name));
            Support_Classes.Staff staff = db.FindStaff(staff_id);
            string staff_name = staff.FirstName + " " + staff.Surname;
            StaffComboBox.SelectedIndex = StaffComboBox.Items.IndexOf(new KeyValuePair<int, string>(staff_id, staff_name));


            int wedding_id = t.Wedding.ID;
            //string wedding_name = t.Wedding.Title;
            //WeddingComboBox.SelectedItem = WeddingComboBox.Equals(new KeyValuePair<int, string>(wedding_id, wedding_name));            
            Support_Classes.Wedding wedding = db.FindWedding(wedding_id);
            string wedding_name = wedding.Title;
            WeddingComboBox.SelectedIndex = WeddingComboBox.Items.IndexOf(new KeyValuePair<int, string>(wedding_id, wedding_name));


            Support_Classes.Task.Priority priority = t.TaskPriority;
            if (priority.Equals(Support_Classes.Task.Priority.high)) {
                HighRadioButton.Checked = true;
                MediumRadioButton.Checked = false;
                LowRadioButton.Checked = false;
            } else if (priority.Equals(Support_Classes.Task.Priority.med)) {
                HighRadioButton.Checked = false;
                MediumRadioButton.Checked = true;
                LowRadioButton.Checked = false;
            } else if (priority.Equals(Support_Classes.Task.Priority.low)) {
                HighRadioButton.Checked = false;
                MediumRadioButton.Checked = false;
                LowRadioButton.Checked = true;
            }

            if (t.CompleteBy != null)
            {
                CompleteByDateTimePicker.Value = t.CompleteBy;
            }
            else
            {
                CompleteByDateTimePicker.Value = t.CompleteBy;
            }

            // Commented out code causing errors galore
//            if (t.CompletionDate != null)
//            {
//                CompletionDateTimePicker.Value = (DateTime)t.CompletionDate;
//                IsCompleted = true;
//            }
//            else
//            {
//                CompletionDateTimePicker.Value = DateTime.Now;
//            }

            
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

            StaffComboBox.DisplayMember = "Value";
            StaffComboBox.ValueMember = "Key";

            WeddingComboBox.DisplayMember = "Value";
            WeddingComboBox.ValueMember = "Key";
        }

        private void UpdateTaskWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }

        private void UpdateButton_Click(object sender, EventArgs e)
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
                    mainWin.RefreshAllWindow();
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.PopuluateDataFields(this.task);
        }
    }
}
