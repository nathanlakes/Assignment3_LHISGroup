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
    public partial class ManageSuppliersWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public ManageSuppliersWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            if (!mainWin.NewSupplierWindow.Visible)
            {
                mainWin.NewSupplierWindow.Visible = true;
            }
            else
            {
                mainWin.NewSupplierWindow.Focus();
            }
            
        }

        private Support_Classes.Supplier ExtractSelectedRow()
        {
            if (SuppliersDataGridView.SelectedRows.Count > 0 && SuppliersDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                int id = (int)SuppliersDataGridView.SelectedRows[0].Cells[0].Value;

                string companyName = (string)SuppliersDataGridView.SelectedRows[0].Cells[1].Value;
                string address = (string)SuppliersDataGridView.SelectedRows[0].Cells[2].Value;
                string contactPerson = (string)SuppliersDataGridView.SelectedRows[0].Cells[3].Value;
                string email = (string)SuppliersDataGridView.SelectedRows[0].Cells[4].Value;
                string phoneNumber = (string)SuppliersDataGridView.SelectedRows[0].Cells[5].Value;
                int creditTerms = (int)SuppliersDataGridView.SelectedRows[0].Cells[6].Value;

                Support_Classes.Supplier s = new Support_Classes.Supplier(companyName, address, contactPerson, email, phoneNumber, creditTerms);
            }

            return null;
        }


        private void UpdateSupplierbutton_Click(object sender, EventArgs e)
        {
            if (SuppliersDataGridView.SelectedRows.Count > 0 && SuppliersDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                
                int id = (int) SuppliersDataGridView.SelectedRows[0].Cells[0].Value;

                string companyName = (string) SuppliersDataGridView.SelectedRows[0].Cells[1].Value;
                string address = (string)SuppliersDataGridView.SelectedRows[0].Cells[2].Value;
                string contactPerson = (string)SuppliersDataGridView.SelectedRows[0].Cells[3].Value;
                string email = (string)SuppliersDataGridView.SelectedRows[0].Cells[4].Value;
                string phoneNumber = (string)SuppliersDataGridView.SelectedRows[0].Cells[5].Value;
                int creditTerms = (int)SuppliersDataGridView.SelectedRows[0].Cells[6].Value;

                Support_Classes.Supplier s = new Support_Classes.Supplier(companyName, address, contactPerson, email, phoneNumber, creditTerms);
                s.ID = id;

                if (!mainWin.UpdateSupplierWindow.Visible)
                {
                    mainWin.UpdateSupplierWindow.Visible = true;
                    mainWin.UpdateSupplierWindow.PopulateDataFields(s);
                }
                else
                {
                    mainWin.UpdateSupplierWindow.PopulateDataFields(s);
                    mainWin.UpdateSupplierWindow.Focus();
                }
            }
            else
            {
                MessageBox.Show("No row selected");
            }

           
            
        }

        public void UpdateForm()
        {
            this.suppliersTableAdapter.Fill(this.modelDataSet.Suppliers);
            SuppliersDataGridView.Update();
            SuppliersDataGridView.Refresh();
            this.Refresh();
        }

        private void ManageSuppliersWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Staff' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.modelDataSet.Suppliers);
        }

        private void ManageSuppliersWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
