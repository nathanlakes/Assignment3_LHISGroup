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
    public partial class UpdateClientWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public UpdateClientWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private bool validateUpdateClientForm()
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
            else if (EngagedFirstNameTextBox.Text == "" || EngagedFirstNameTextBox.Text == null)
            {
                MessageBox.Show("Need first name");
                return false;
            }
            else if (EngagedSurnameTextBox.Text == "" || EngagedSurnameTextBox.Text == null)
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
            else if (MobilePhoneTextBox.Text == "" || MobilePhoneTextBox.Text == null)
            {
                MessageBox.Show("Need mobile phone number");
                return false;
            }
            else if (HomePhoneTextBox.Text == "" || HomePhoneTextBox.Text == null)
            {
                MessageBox.Show("Need home phone number");
                return false;
            }
            else if (AddressTextBox.Text == "" || AddressTextBox.Text == null)
            {
                MessageBox.Show("Need address");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (validateUpdateClientForm() == true)
            {
                MessageBox.Show("Successful Validation!!");
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {

        }

    }
}
