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
    public partial class UpdateWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        Support_Classes.Supplier supplier;
        int id;


        public UpdateWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        public UpdateWindow(MainWindow w, DbController d, Support_Classes.Supplier s)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
            supplier = s;
            id = supplier.ID;
        }

        public void PopulateDataFields(Support_Classes.Supplier s)
        {
            this.supplier = s;

            this.id = s.ID;

            string companyName = s.CompanyName;
            string address = s.Address;
            string contactPerson = s.ContactPerson;
            string email = s.Email;
            string phoneNumber = s.PhoneNumber;
            int creditTerms = s.CreditTerms;

            CompanyNameTextBox.Text = companyName;
            AddressTextBox.Text = address;
            ContactPersonTextBox.Text = contactPerson;
            EmailTextBox.Text = email;
            PhoneTextBox.Text = phoneNumber;
            CreditItemsTextBox.Text = creditTerms.ToString();

        }



        private bool ValidateWindow()
        {
            if (CompanyNameTextBox.Text == "" || CompanyNameTextBox.Text == null)
            {
                MessageBox.Show("Need company Name");
                return false;
            }
            else if (ContactPersonTextBox.Text == "" || ContactPersonTextBox.Text == null)
            {
                MessageBox.Show("Need contact person");
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
            else if (AddressTextBox.Text == "" || AddressTextBox.Text == null)
            {
                MessageBox.Show("Need address");
                return false;
            }
            else if (CreditItemsTextBox.Text == "" || CreditItemsTextBox.Text == null)
            {
                MessageBox.Show("Need credit items");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.PopulateDataFields(this.supplier);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (ValidateWindow() == true)
            {
                String name = CompanyNameTextBox.Text;
                String contact = ContactPersonTextBox.Text;
                String email = EmailTextBox.Text;
                String phone = PhoneTextBox.Text;
                String address = AddressTextBox.Text;
                int credit = Convert.ToInt32((String)CreditItemsTextBox.Text);

                Support_Classes.Supplier s = new Support_Classes.Supplier(name, address, contact, email, phone, credit);

                try
                {
                    //bool x = db.UpdateSupplier(id, s);
                    db.UpdateSupplier(id, s);
                    mainWin.ManageSuppliersWindow.UpdateForm();

                    if (!mainWin.ManageSuppliersWindow.Visible)
                    {
                        mainWin.ManageSuppliersWindow.Visible = true;
                    }
                    else
                    {
                        mainWin.ManageSuppliersWindow.Focus();
                    }
                    //this.Hide();
                    mainWin.RefreshAllWindow();
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }

            }
        }


        private void UpdateSupplierWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
