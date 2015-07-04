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
    public partial class NewWeddingWindow : Form
    {
        MainWindow mainWin;
        DbController db;

        List<Support_Classes.Staff> StaffList;
        List<Support_Classes.Client> ClientList;

        public NewWeddingWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;


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

        private void ClearForm()
        {
            NameTextBox.Text = "";
            ClientComboBox.SelectedItem = null;
            EngagedComboBox.SelectedItem = null;
            DescriptionTextBox.Text = "";

            EventDateTimePicker.Value = DateTime.Now;
            StartDateTimePicker.Value = DateTime.Now;
            StaffComboBox.SelectedItem = null;
            //RefreshData();
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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            RefreshData();
        }

        private void CreateButton_Click(object sender, EventArgs e)
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

                
                Support_Classes.Wedding wedding = new Support_Classes.Wedding(title, desc, client, engaged, staff, startDate, eventDate);

                try
                {
                    db.AddWedding(wedding);
                    ClearForm();
                    mainWin.ManageWeddingsWindow.UpdateForm();
                    if (!mainWin.ManageWeddingsWindow.Visible)
                    {
                        mainWin.ManageWeddingsWindow.Visible = true;
                    }
                    else
                    {
                        mainWin.ManageWeddingsWindow.Focus();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }
            }
            
        }

        private void NewWeddingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshData();
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }

        private void NewWeddingWindow_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.modelDataSet.Client);

        }
    }
}
