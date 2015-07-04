﻿using System;
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

        public void ClearForm()
        {
            NameTextBox.Text = "";
            ClientComboBox.ValueMember = "";
            EngagedComboBox.ValueMember = "";
            DescriptionTextBox.Text = "";
            EventDateTimePicker.ResetText();
            StartDateTimePicker.ResetText();
            StaffComboBox.ValueMember = "";
            RefreshData();
        }

        public bool ValidateForm()
        {
            if (NameTextBox.Text == "" || NameTextBox.Text == null)
            {
                MessageBox.Show("Need name");
                return false;
            }
            else if (ClientComboBox.ValueMember == null)
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
            else if (DescriptionTextBox.Text == "" || DescriptionTextBox.Text == null)
            {
                MessageBox.Show("Need description");
                return false;
            }
            else if (StaffComboBox.ValueMember == null)
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
                String title = NameTextBox.Text;

                string clientId = ClientComboBox.SelectedItem.ToString();
                MessageBox.Show(clientId);
                string engagedId = EngagedComboBox.SelectedItem.ToString();
                MessageBox.Show(engagedId);

                string desc = DescriptionTextBox.Text;

                EventDateTimePicker.ResetText();
                StartDateTimePicker.ResetText();
                StaffComboBox.ValueMember = "";




                //Support_Classes.Wedding wedding = new Support_Classes.Wedding();

                try
                {
                    //db.AddWedding(wedding);


                }
                catch
                {


                }
                //MessageBox.Show("Successfully Validated!");
            }
            else
            {

            }
            RefreshData();
        }

        private void NewWeddingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshData();
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
