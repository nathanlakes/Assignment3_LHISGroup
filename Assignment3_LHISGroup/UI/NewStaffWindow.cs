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
    public partial class NewStaffWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public NewStaffWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }


        private void clearNewStaffForm()
        {
            FirstNameTextBox.Text = "";
            SurnameTextBox.Text = "";
            EmailTextBox.Text = "";
            PhoneTextBox.Text = "";
            NotesTextBox.Text = "";
        }

        private bool validateNewStaffForm()
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

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (validateNewStaffForm() == true)
            {
                String fn = FirstNameTextBox.Text;
                String sn = SurnameTextBox.Text;
                String email = EmailTextBox.Text;
                String ph = PhoneTextBox.Text;
                String notes = "";
                if (NotesTextBox.Text == null)
                {
                    notes = "";
                }
                else
                {
                    notes = NotesTextBox.Text;
                }

                Support_Classes.Staff staff = new Support_Classes.Staff(fn, sn, email, ph, notes, Support_Classes.Staff.Active.active);
                //MessageBox.Show("New Staff created");
                try
                {
                    db.AddStaff(staff);
                    clearNewStaffForm();
                    mainWin.ManageStaffWindow.UpdateForm();
                    mainWin.RefreshAllWindow();
                } catch(Exception){
                    MessageBox.Show("Exception thrown");
                }               
            }          

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.clearNewStaffForm();
        }


        private void NewStaffWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
