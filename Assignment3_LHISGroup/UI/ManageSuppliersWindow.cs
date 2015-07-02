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
            mainWin.NewSupplierWindow.Visible = true;
        }

        private void UpdateSupplierbutton_Click(object sender, EventArgs e)
        {
            mainWin.UpdateSupplierWindow.Visible = true;
        }

     
    }
}
