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

        int id;
        Support_Classes.Client client;

        public UpdateClientWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }


        public void PopulateForm(Support_Classes.Client c)
        {
            client = c;
            id = c.ID;

            string firstname = c.Firstname;
            string surname = c.Surname;
            string contactPerson = c.ContactPerson;
            string address = c.Address;
            string mobile = c.Mobile;
            string homePhone = c.HomePhone;
            string email = c.Email;
            string engagedTo_firstName = c.EngagedTo_fn;
            string engagedTo_surname = c.EngagedTo_sn;

            FirstNameTextBox.Text = firstname;
            SurnameTextBox.Text = surname;
            AddressTextBox.Text = address;
            MobilePhoneTextBox.Text = mobile;
            HomePhoneTextBox.Text = homePhone;
            EmailTextBox.Text = email;
            EngagedFirstNameTextBox.Text = engagedTo_firstName;
            EngagedSurnameTextBox.Text = engagedTo_surname;

            if (contactPerson.Equals(firstname + " " + surname))
            {
                ContactCheckBox.Checked = true;
            }
            else
            {
                ContactCheckBox.Checked = false;
            }

        }

        private bool ValidateForm()
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
            if (ValidateForm() == true)
            {
                String fn = FirstNameTextBox.Text;
                String sn = SurnameTextBox.Text;
                String contact = fn + " " + sn;
                String address = AddressTextBox.Text;
                String mobile = MobilePhoneTextBox.Text;
                String homePhone = HomePhoneTextBox.Text;
                String email = EmailTextBox.Text;
                String e_fn = EngagedFirstNameTextBox.Text;
                String e_sn = EngagedSurnameTextBox.Text;
                if (ContactCheckBox.Checked == false)
                {
                    contact = e_fn + " " + e_sn;
                }

                Support_Classes.Client c = new Support_Classes.Client(fn, sn, contact, address, mobile, homePhone, email, e_fn, e_sn);

                try
                {
                    db.UpdateClient(this.id, c);
                    mainWin.ManageClientsWindow.UpdateForm();
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }

            }
            else
            {

            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            PopulateForm(this.client);
        }

        private void UpdateClientWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
