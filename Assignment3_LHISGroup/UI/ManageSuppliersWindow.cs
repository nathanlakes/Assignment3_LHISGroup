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

        private void UpdateSupplierbutton_Click(object sender, EventArgs e)
        {
            if (!mainWin.UpdateSupplierWindow.Visible)
            {
                mainWin.UpdateSupplierWindow.Visible = true;
            }
            else
            {
                mainWin.UpdateSupplierWindow.Focus();
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
    }
}
