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
        public NewWeddingWindow(MainWindow w, DbController d)
        {
            InitializeComponent();
            mainWin = w;
            db = d;
        }

        public void clearNewWeddingForm()
        {
            NameTextBox.Text = "";
            ClientComboBox.ValueMember = null;
            DescriptionTextBox.Text = "";
            EventDateTimePicker.ResetText();
            StartDateTimePicker.ResetText();
            StaffComboBox.ValueMember = null;
        }

        public bool validateNewWeddingForm()
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
            this.clearNewWeddingForm();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.validateNewWeddingForm() == true)
            {
                MessageBox.Show("Successfully Validated!");
            }
        }

        private void NewWeddingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true; // this cancels the close event
        }
    }
}
