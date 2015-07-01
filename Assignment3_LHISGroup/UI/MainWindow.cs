using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Assignment3_LHISGroup.Support_Classes;

namespace Assignment3_LHISGroup
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //DbController db = new DbController()
            
        }

        private void ManageSuppliersButton_Click(object sender, EventArgs e)
        {
            UI.ManageSuppliersWindow win = new UI.ManageSuppliersWindow();
            win.Visible = true;
        }

        private void ManageStaffButton_Click(object sender, EventArgs e)
        {
            UI.ManageStaffWindow win = new UI.ManageStaffWindow();
            win.Visible = true;
        }

        private void ManageTasksButton_Click(object sender, EventArgs e)
        {
            UI.ManageTasksWindow win = new UI.ManageTasksWindow();
            win.Visible = true;
        }

        private void ManageClientsButton_Click(object sender, EventArgs e)
        {
            UI.ManageClientsWindow win = new UI.ManageClientsWindow();
            win.Visible = true;
        }

        private void ManageWeddingsButton_Click(object sender, EventArgs e)
        {
            UI.ManageWeddingsWindow win = new UI.ManageWeddingsWindow();
            win.Visible = true;
        }

        private void NewStaffButton_Click(object sender, EventArgs e)
        {
            UI.NewStaffWindow win = new UI.NewStaffWindow();
            win.Visible = true;
        }

        private void NewTaskButton_Click(object sender, EventArgs e)
        {
            UI.NewTaskWindow win = new UI.NewTaskWindow();
            win.Visible = true;
        }

        private void NewSupplierButton_Click(object sender, EventArgs e)
        {
            UI.NewSupplierWindow win = new UI.NewSupplierWindow();
            win.Visible = true;
        }

        private void NewWeddingButton_Click(object sender, EventArgs e)
        {
            UI.NewWeddingWindow win = new UI.NewWeddingWindow();
            win.Visible = true;
        }

        private void NewClientButton_Click(object sender, EventArgs e)
        {
            UI.NewClientWindow win = new UI.NewClientWindow();
            win.Visible = true;
        }
    }
}
