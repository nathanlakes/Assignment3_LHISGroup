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
    public partial class NewSupplierWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public NewSupplierWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private void clearNewSupplierWindow()
        {
            CompanyNameTextBox.Text = "";
            ContactPersonTextBox.Text = "";
            EmailTextBox.Text = "";
            PhoneTextBox.Text = "";
            AddressTextBox.Text = "";
        }

        private bool validateNewSupplierWindow()
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
            else
            {
                return true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.clearNewSupplierWindow();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (validateNewSupplierWindow() == true)
            {
                String name = CompanyNameTextBox.Text;
                String contact = ContactPersonTextBox.Text;
                String email = EmailTextBox.Text;
                String phone = PhoneTextBox.Text;
                String address = AddressTextBox.Text;

                Support_Classes.Supplier s = new Support_Classes.Supplier(name, address, contact, email, phone, 0);

                try
                {
                    db.AddSupplier(s);
                    clearNewSupplierWindow();
                    mainWin.ManageSuppliersWindow.UpdateForm();
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }
                
                
            }
        }
    }
}
