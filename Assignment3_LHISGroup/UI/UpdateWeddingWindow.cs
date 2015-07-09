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

            int client_id = w.Client1.ID;
            //string client_name = w.Client1.Firstname + " " + w.Client1.Surname;
            //ClientComboBox.SelectedItem = ClientComboBox.Equals(new KeyValuePair<int, string>(client_id, client_name));
            Support_Classes.Client client = db.FindClient(client_id);
            string client_name = client.Firstname + " " + client.Surname;
            ClientComboBox.SelectedIndex = ClientComboBox.Items.IndexOf(new KeyValuePair<int, string>(client_id, client_name));


            int engaged_id = w.Client2.ID;
            //string engaged_name = w.Client2.Firstname + " " + w.Client2.Surname;
            //EngagedComboBox.SelectedItem = EngagedComboBox.Equals(new KeyValuePair<int, string>(engaged_id, engaged_name));
            Support_Classes.Client engaged = db.FindClient(engaged_id);
            string engaged_name = engaged.Firstname + " " + engaged.Surname;
            EngagedComboBox.SelectedIndex = EngagedComboBox.Items.IndexOf(new KeyValuePair<int, string>(engaged_id, engaged_name));


            int staff_id = w.WeddingPlanner.ID;
            //string staff_name = w.WeddingPlanner.FirstName + " " + w.WeddingPlanner.Surname;
            //StaffComboBox.SelectedItem = StaffComboBox.Items.IndexOf(new KeyValuePair<int, string>(staff_id, staff_name));
            Support_Classes.Staff staff = db.FindStaff(staff_id);
            string staff_name = staff.FirstName + " " + staff.Surname;
            StaffComboBox.SelectedIndex = StaffComboBox.Items.IndexOf(new KeyValuePair<int, string>(staff_id, staff_name));


            DescriptionTextBox.Text = w.Description;

            if (w.EventDate != null)
            {
                //EventDateTimePicker.Value = w.EventDate.Date;
            }

            if (w.StartDate != null)
            {
                //StartDateTimePicker.Value = w.StartDate.Date;
            }
            
            

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
            if (this.ValidateForm() == true)
            {
                // text boxes

                String title = NameTextBox.Text;
                String desc = DescriptionTextBox.Text;

                // objects from combo boxes

                int client_id = ((KeyValuePair<int, string>)this.ClientComboBox.SelectedItem).Key;
                Support_Classes.Client client = db.FindClient(client_id);

                int engaged_id = ((KeyValuePair<int, string>)this.EngagedComboBox.SelectedItem).Key;
                Support_Classes.Client engaged = db.FindClient(engaged_id);

                int staff_id = ((KeyValuePair<int, string>)this.StaffComboBox.SelectedItem).Key;
                Support_Classes.Staff staff = db.FindStaff(staff_id);


                // datetime

                DateTime startDate = StartDateTimePicker.Value;
                DateTime eventDate = EventDateTimePicker.Value;


                Support_Classes.Wedding wedding = new Support_Classes.Wedding(title, desc, client, engaged, staff, startDate, eventDate, Support_Classes.Wedding.Status.InPreparation);
                wedding.ID = id;

                try
                {
                    db.UpdateWedding(id, wedding);

                    mainWin.ManageWeddingsWindow.UpdateForm();
                    this.Visible = false;
                    if (!mainWin.ManageWeddingsWindow.Visible)
                    {
                        mainWin.ManageWeddingsWindow.Visible = true;

                    }
                    else
                    {
                        mainWin.ManageWeddingsWindow.Focus();
                    }
                    mainWin.RefreshAllWindow();
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }
            }
        }
    }
}
