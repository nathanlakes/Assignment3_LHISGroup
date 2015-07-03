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
    public partial class UpdateWeddingWindow : Form
    {
        MainWindow mainWin;
        DbController db;

        List<Support_Classes.Staff> StaffList;
        List<Support_Classes.Client> ClientList;


        public UpdateWeddingWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            db = d;
            mainWin = w;

            ClientList = db.GetAllClients();
            foreach (Support_Classes.Client client in ClientList)
            {
                ClientComboBox.Items.Add(client.Firstname + " " + client.Surname);
                EngagedComboBox.Items.Add(client.Firstname + " " + client.Surname);
            }

            StaffList = db.GetAllStaff();
            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    StaffComboBox.Items.Add(staff.FirstName + " " + staff.Surname);
                }
            }
        }

        public void RefreshData()
        {
            ClientList = db.GetAllClients();
            foreach (Support_Classes.Client client in ClientList)
            {
                ClientComboBox.Items.Add(client.Firstname + " " + client.Surname);
                EngagedComboBox.Items.Add(client.Firstname + " " + client.Surname);
            }

            StaffList = db.GetAllStaff();
            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    StaffComboBox.Items.Add(staff.FirstName + " " + staff.Surname);
                }
            }
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            mainWin.EventReportWindow.Visible = true;
        }


        private void UpdateWeddingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
