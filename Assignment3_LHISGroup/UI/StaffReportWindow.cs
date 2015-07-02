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

            
            
        }

        private void populateTasks()
        {
            // TODO
            //staffRep.FindTasksAssignedTo();
        }

        private void StaffTasksListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
