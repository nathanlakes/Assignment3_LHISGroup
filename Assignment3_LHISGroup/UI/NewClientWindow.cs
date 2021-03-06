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
    public partial class NewClientWindow : Form
    {
        MainWindow mainWin;
        DbController db;
        public NewClientWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        private bool ValidateForm()
        {
            if (FirstNameTextBox.Text == "" || FirstNameTextBox.Text == null)
            {
                MessageBox.Show("Need first name");
                return false;
            }
            else if (SurnameTextBox.Text == "" || SurnameTextBox.Text == null)
            {
                MessageBox.Show("Need surname");
                return false;
            }
            else if (EngagedFirstNameTextBox.Text == "" || EngagedFirstNameTextBox.Text == null)
            {
                MessageBox.Show("Need first name");
                return false;
            }
            else if (EngagedSurnameTextBox.Text == "" || EngagedSurnameTextBox.Text == null)
            {
                MessageBox.Show("Need surname");
                return false;
            }
            else if (EmailTextBox.Text == "" || EmailTextBox.Text == null)
            {
                MessageBox.Show("Need email address");
                return false;
            }
            else if (!EmailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Invalid email address");
                return false;
            }
            else if (MobilePhoneTextBox.Text == "" || MobilePhoneTextBox.Text == null)
            {
                MessageBox.Show("Need mobile phone number");
                return false;
            }
            else if (HomePhoneTextBox.Text == "" || HomePhoneTextBox.Text == null)
            {
                MessageBox.Show("Need home phone number");
                return false;
            }
            else if (AddressTextBox.Text == "" || AddressTextBox.Text == null)
            {
                MessageBox.Show("Need address");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClearForm()
        {
            FirstNameTextBox.Text = "";
            SurnameTextBox.Text = "";
            EngagedFirstNameTextBox.Text = "";
            EngagedSurnameTextBox.Text = "";
            EmailTextBox.Text = "";
            MobilePhoneTextBox.Text = "";
            HomePhoneTextBox.Text = "";
            AddressTextBox.Text = "";
            ContactCheckBox.Checked = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm() == true)
            {
                String n = FirstNameTextBox.Text;
                String sn = SurnameTextBox.Text;
                String e_n = EngagedFirstNameTextBox.Text;
                String e_sn = EngagedSurnameTextBox.Text;
                String email = EmailTextBox.Text;
                String mobile = MobilePhoneTextBox.Text;
                String phone = HomePhoneTextBox.Text;
                String address = AddressTextBox.Text;

                String contact = "";
                if (ContactCheckBox.Checked == true)
                {
                    contact = n + " " + sn;
                }
                else
                {
                    contact = e_n + " " + e_sn;
                }

                Support_Classes.Client client1 = new Support_Classes.Client(n, sn, contact, address, mobile, phone, email, e_n, e_sn);

                Support_Classes.Client client2 = new Support_Classes.Client(e_n, e_sn, contact, address, mobile, phone, email, n, sn);

                try
                {
                    db.AddClient(client1);
                    
                    ClearForm();
                    mainWin.ManageClientsWindow.UpdateForm();

                    db.AddClient(client2);
                    mainWin.UpdateClientWindow.PopulateForm(client2);
                    //if (!mainWin.UpdateClientWindow.Visible)
                    //{
                    //    mainWin.UpdateClientWindow.Visible = true;
                    //}
                    //else
                    //{
                    //    mainWin.UpdateClientWindow.Focus();
                    //}
                    mainWin.RefreshAllWindow();
                    this.Visible = false;
                }
                catch (Exception)
                {
                    MessageBox.Show("Exception thrown");
                }


            }
        }

        private void NewClientWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
