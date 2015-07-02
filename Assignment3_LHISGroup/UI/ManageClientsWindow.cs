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
    public partial class ManageClientsWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public ManageClientsWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        public void UpdateForm()
        {
            this.clientTableAdapter.Fill(this.modelDataSet.Client);
            ClientsDataGridView.Update();
            ClientsDataGridView.Refresh();
            this.Refresh();
        }

        private void ManageClientsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }

        private void AddClientButton_Click(object sender, EventArgs e)
        {
            if (!mainWin.NewClientWindow.Visible)
            {
                mainWin.NewClientWindow.Visible = true;
            }
            else
            {
                mainWin.NewClientWindow.Focus();
            }
            
        }

        private void UpdateClientButton_Click(object sender, EventArgs e)
        {
            if (!mainWin.UpdateClientWindow.Visible)
            {
                mainWin.UpdateClientWindow.Visible = true;
            }
            else
            {
                mainWin.UpdateClientWindow.Focus();
            }
            
        }

        private void ManageClientsWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.modelDataSet.Client);

        }
    }
}
