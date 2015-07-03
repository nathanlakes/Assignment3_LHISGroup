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
        public UpdateStaffWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private void resetUpdateStaffForm()
        {
            //mainWin.ManageStaffWindow
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
            resetUpdateStaffForm();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (validateUpdateStaffForm() == true)
            {
                MessageBox.Show("Validation works!");
            }
        }

        private void UpdateStaffWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
