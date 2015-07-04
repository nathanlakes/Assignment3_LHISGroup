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

        int id;
        Support_Classes.Wedding wedding;

        public UpdateWeddingWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            db = d;
            mainWin = w;

            ClientList = db.GetAllClients();
            foreach (Support_Classes.Client client in ClientList)
            {
                int keyValue = client.ID;
                string name = client.Firstname + " " + client.Surname;

                ClientComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
                EngagedComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
            }

            ClientComboBox.DisplayMember = "Value";
            ClientComboBox.ValueMember = "Key";

            EngagedComboBox.DisplayMember = "Value";
            EngagedComboBox.ValueMember = "Key";

            StaffList = db.GetAllStaff();

            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    int keyValue = staff.ID;
                    string name = staff.FirstName + " " + staff.Surname;
                    StaffComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
                }
            }

            StaffComboBox.DisplayMember = "Value";
            StaffComboBox.ValueMember = "Key";
        }

        public bool ValidateForm()
        {
            if (NameTextBox.Text == "" || NameTextBox.Text == null)
            {
                MessageBox.Show("Need name");
                return false;
            }
            else if (ClientComboBox.SelectedItem == null)
            {
                MessageBox.Show("Need client");

                if (!mainWin.NewClientWindow.Visible)
                {
                    mainWin.NewClientWindow.Show();
                }
                else
                {
                    mainWin.NewClientWindow.Focus();
                }
                return false;
            }
            else if (EngagedComboBox.SelectedItem == null)
            {
                MessageBox.Show("Need engaged to");

                if (!mainWin.NewClientWindow.Visible)
                {
                    mainWin.NewClientWindow.Show();
                }
                else
                {
                    mainWin.NewClientWindow.Focus();
                }
                return false;
            }
            else if (DescriptionTextBox.Text == "" || DescriptionTextBox.Text == null)
            {
                MessageBox.Show("Need description");
                return false;
            }
            else if (StaffComboBox.SelectedItem == null)
            {
                MessageBox.Show("Need staff");
                return false;
            }
            else if (EventDateTimePicker.Value == null)
            {
                MessageBox.Show("Need wedding date");
                return false;
            }
            else if (StartDateTimePicker.Value == null)
            {
                MessageBox.Show("Need starting date");
                return false;
            }
            else
            {
                // TODO if there is more time, add extra code for validation
                // TODO code to check that the two clients are actually engaged to each other
                // TODO the start date is before the event date
                // TODO the start date is not before the current date
                // TODO the event date is not the current date

                return true;
            }
        }

        public void PopulateDataFields(Support_Classes.Wedding w)
        {
            wedding = w;
            id = w.ID;

            NameTextBox.Text = w.Title;

            int client_ID = w.Client1.ID;
            string client_name = w.Client1.Firstname + " " + w.Client1.Surname;
            ClientComboBox.SelectedItem = ClientComboBox.Equals(new KeyValuePair<int, string>(client_ID, client_name));

            int engaged_id = w.Client2.ID;
            string engaged_name = w.Client2.Firstname + " " + w.Client2.Surname;
            EngagedComboBox.SelectedItem = EngagedComboBox.Equals(new KeyValuePair<int, string>(engaged_id, engaged_name));

            int staff_id = w.WeddingPlanner.ID;
            string staff_name = w.WeddingPlanner.FirstName + " " + w.WeddingPlanner.Surname;
            StaffComboBox.SelectedItem = StaffComboBox.Equals(new KeyValuePair<int, string>(staff_id, staff_name));


            //((KeyValuePair<int, string>)this.ClientComboBox.SelectedItem).Key = w.Client1.ID;
            //((KeyValuePair<int, string>)this.EngagedComboBox.SelectedItem).Key = w.Client2.ID;

            //ClientComboBox.ValueMember = w.Client1.Firstname + " " + w.Client1.Surname;
            //EngagedComboBox.ValueMember = w.Client2.Firstname + " " + w.Client2.Surname;


            DescriptionTextBox.Text = "";
            EventDateTimePicker.Value = w.EventDate;
            StartDateTimePicker.Value = w.StartDate;


            //StaffComboBox.ValueMember = "";
        }

        public void RefreshData()
        {
            ClientComboBox.Items.Clear();
            EngagedComboBox.Items.Clear();
            StaffComboBox.Items.Clear();

            ClientList = db.GetAllClients();
            foreach (Support_Classes.Client client in ClientList)
            {
                int keyValue = client.ID;
                string name = client.Firstname + " " + client.Surname;

                ClientComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
                EngagedComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
            }

            ClientComboBox.DisplayMember = "Value";
            ClientComboBox.ValueMember = "Key";

            EngagedComboBox.DisplayMember = "Value";
            EngagedComboBox.ValueMember = "Key";

            StaffList = db.GetAllStaff();

            foreach (Support_Classes.Staff staff in StaffList)
            {
                if (staff.StatusToString().Equals("active"))
                {
                    int keyValue = staff.ID;
                    string name = staff.FirstName + " " + staff.Surname;
                    StaffComboBox.Items.Add(new KeyValuePair<int, string>(keyValue, name));
                }
            }

            StaffComboBox.DisplayMember = "Value";
            StaffComboBox.ValueMember = "Key";
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
