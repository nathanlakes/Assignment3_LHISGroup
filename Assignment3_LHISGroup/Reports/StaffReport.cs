using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment3_LHISGroup.Support_Classes;
using Assignment3_LHISGroup.UI;
using Assignment3_LHISGroup.Support_Classes.Task;

namespace Assignment3_LHISGroup.Reports
{
    public partial class StaffReport : Form
    {
        Staff currentStaff;
        List<Support_Classes.Task> assignedTaskList;
        DbController dbController = new DbController();
        public StaffReport(Staff givenStaffMember)
        {
            assignedTaskList = new List<Support_Classes.Task>();
            currentStaff = givenStaffMember;
            InitializeComponent();

        }

        private List<Support_Classes.Task> FindTasksAssignedTo()
        {
            if (currentStaff.StaffStatus == Staff.Active.inactive)
            {
                Console.WriteLine("Error: Staff Member is inactive");
                return new List<Support_Classes.Task>();
            }
            else
            {
                List<Support_Classes.Task> allTaskList = new List<Support_Classes.Task>();
                allTaskList = dbController.GetAllTasks();


                return new List<Support_Classes.Task>();
            }
            
        }

        private void StaffReport_Load(object sender, EventArgs e)
        {

        }


    }
}
