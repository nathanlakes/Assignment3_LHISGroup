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
    public partial class UpdateStaffWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        Support_Classes.Staff staff;

        int id;
        public UpdateStaffWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        public void PopulateForm(Support_Classes.Staff s)
        {
            staff = s;
            this.id = s.ID;

            string firstname = s.FirstName;
            string surname = s.Surname;
            string email = s.Email;
            string phone = s.Phone;
            string notes = s.Notes;
            Support_Classes.Staff.Active active = s.StaffStatus;

            FirstNameTextBox.Text = firstname;
            SurnameTextBox.Text = surname;
            EmailTextBox.Text = email;
            PhoneTextBox.Text = phone;
            NotesTextBox.Text = notes;
            if (active == Support_Classes.Staff.Active.active)
            {
                ActiveStatusCheckBox.Checked = true;
            }
            else
            {
                ActiveStatusCheckBox.Checked = false;
            }
        }


        private bool validateUpdateStaffForm()
        {
            if (FirstNameTextBox.Text == "" || FirstNameTextBox.Text == null)
            {
                MessageBox.Show("Need first name");
                return false;
            }
            else if (SurnameTextBox.Text == "" || SurnameTextBox.Text == null)
            {
                MessageBox.Show("Need surname");
                return false;
            }
            else if (EmailTextBox.Text == "" || EmailTextBox.Text == null)
            {
                MessageBox.Show("Need email address");
                return false;
            }
            else if (!EmailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Invalid email address");
                return false;
            }
            else if (PhoneTextBox.Text == "" || PhoneTextBox.Text == null)
            {
                MessageBox.Show("Need phone number");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.PopulateForm(this.staff);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (validateUpdateStaffForm() == true)
            {

                string fn = FirstNameTextBox.Text;
                string sn = SurnameTextBox.Text;
                string email = EmailTextBox.Text;
                string phone = PhoneTextBox.Text;
                string notes = NotesTextBox.Text;
                bool active = ActiveStatusCheckBox.Checked;
                Support_Classes.Staff.Active status = Support_Classes.Staff.Active.active;
                if (active == false)
                {
                    status = Support_Classes.Staff.Active.inactive;
                }

                Support_Classes.Staff s = new Support_Classes.Staff(fn, sn, email, phone, notes, status);
                
                try
                {
                    db.UpdateStaff(this.id, s);
                    mainWin.ManageStaffWindow.UpdateForm();
                    mainWin.RefreshAllWindow();
                } catch (Exception){
                    MessageBox.Show("Exception thrown");
                }


            }
        }

        private void UpdateStaffWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
