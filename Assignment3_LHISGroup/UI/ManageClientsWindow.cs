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

        private Support_Classes.Client ExtractSelectedRow()
        {
            if (ClientsDataGridView.SelectedRows.Count > 0 && ClientsDataGridView.SelectedRows[0].Cells[0].Value != null)
            {
                int id = (int)ClientsDataGridView.SelectedRows[0].Cells[0].Value;

                string firstname = (string)ClientsDataGridView.SelectedRows[0].Cells[1].Value;
                string surname = (string)ClientsDataGridView.SelectedRows[0].Cells[2].Value;
                string contactPerson = (string)ClientsDataGridView.SelectedRows[0].Cells[3].Value;
                string address = (string)ClientsDataGridView.SelectedRows[0].Cells[4].Value;
                string mobile = (string)ClientsDataGridView.SelectedRows[0].Cells[5].Value;
                string homePhone = (string)ClientsDataGridView.SelectedRows[0].Cells[6].Value;
                string email = (string)ClientsDataGridView.SelectedRows[0].Cells[7].Value;
                string engagedTo_firstName = (string)ClientsDataGridView.SelectedRows[0].Cells[8].Value;
                string engagedTo_surname = (string)ClientsDataGridView.SelectedRows[0].Cells[9].Value;

                Support_Classes.Client client = new Support_Classes.Client(firstname, surname, contactPerson, address, mobile, homePhone, email, engagedTo_firstName, engagedTo_surname);
                client.ID = id;
                return client;
            }
            else
            {
                return null;
            }
        }

        private void UpdateClientButton_Click(object sender, EventArgs e)
        {
            Support_Classes.Client client = ExtractSelectedRow();
            if (client != null)
            {
                if (!mainWin.UpdateClientWindow.Visible)
                {
                    mainWin.UpdateClientWindow.Visible = true;
                    mainWin.UpdateClientWindow.PopulateForm(client);
                }
                else
                {
                    mainWin.UpdateClientWindow.Focus();
                    mainWin.UpdateClientWindow.PopulateForm(client);
                }
            }
            else
            {
                MessageBox.Show("Row not selected");
            }

            
        }

        private void ManageClientsWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.modelDataSet.Client);

        }

    }
}
