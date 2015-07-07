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

        private void ClearWindow()
        {
            CompanyNameTextBox.Text = "";
            ContactPersonTextBox.Text = "";
            EmailTextBox.Text = "";
            PhoneTextBox.Text = "";
            AddressTextBox.Text = "";
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
            else
            {
                return true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.ClearWindow();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (ValidateWindow() == true)
            {
                String name = CompanyNameTextBox.Text;
                String contact = ContactPersonTextBox.Text;
                String email = EmailTextBox.Text;
                String phone = PhoneTextBox.Text;
                String address = AddressTextBox.Text;

                Support_Classes.Supplier supplier = new Support_Classes.Supplier(name, address, contact, email, phone, 0);

                try
                {
                    db.AddSupplier(supplier);
                    ClearWindow();
                    mainWin.ManageSuppliersWindow.UpdateForm();
                    if (!mainWin.ManageSuppliersWindow.Visible)
                    {
                        mainWin.ManageSuppliersWindow.Visible = true;
                    }
                    else
                    {
                        mainWin.ManageSuppliersWindow.Focus();
                    }
                    mainWin.RefreshAllWindow();
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }
                
                
            }
        }
        private void NewSupplierWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
