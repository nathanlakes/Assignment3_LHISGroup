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
    public partial class StaffReportWindow : Form
    {
        StaffReport staffRep;
        Form parent;
        public StaffReportWindow(Form parentForm)
        {
            InitializeComponent();
            parent = parentForm;
            parent.Hide();

            staffRep = new StaffReport();
            StaffTasksListView.Columns.Add("Task Name", 15, HorizontalAlignment.Left);
            StaffTasksListView.Columns.Add("Task Description", 30, HorizontalAlignment.Left);
            StaffTasksListView.Columns.Add("Complete By Date", 30, HorizontalAlignment.Left);
            
        }

        
    }
}
