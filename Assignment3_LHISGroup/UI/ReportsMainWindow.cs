using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment3_LHISGroup.Reports;

namespace Assignment3_LHISGroup.UI
{
    public partial class ReportsMainWindow : Form
    {
        Form parent;
        public ReportsMainWindow(Form form)
        {
            InitializeComponent();
            parent = form;
            parent.Hide();
            //this.Show();
        }

        private void EventProgressGraphButton_Click(object sender, EventArgs e)
        {

        }

        private void EventProgressReportButton_Click(object sender, EventArgs e)
        {

        }

        private void EventReportButton_Click(object sender, EventArgs e)
        {

        }

        private void EventTaskReportButton_Click(object sender, EventArgs e)
        {

        }

        private void EventReportWindow_Load(object sender, EventArgs e)
        {
           
        }

        private void EventReportWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
            this.Dispose();
        }

        private void StaffReportButton_Click(object sender, EventArgs e)
        {
            StaffReportWindow win = new StaffReportWindow(this);
            win.Visible = true; 
        }

       
    }
}
