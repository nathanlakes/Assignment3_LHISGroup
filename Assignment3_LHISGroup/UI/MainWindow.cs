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

namespace Assignment3_LHISGroup
{
    public partial class MainWindow : Form
    {

        public DbController DB;

        private UI.EventReportWindow EventReportWindow;

        private UI.ManageClientsWindow ManageClientsWindow;
        private UI.ManageStaffWindow ManageStaffWindow;
        private UI.ManageSuppliersWindow ManageSuppliersWindow;
        private UI.ManageTasksWindow ManageTasksWindow;
        private UI.ManageWeddingsWindow ManageWeddingsWindow;

        private UI.NewClientWindow NewClientWindow;
        private UI.NewStaffWindow NewStaffWindow;
        private UI.NewSupplierWindow NewSupplierWindow;
        private UI.NewTaskWindow NewTaskWindow;
        private UI.NewWeddingWindow NewWeddingWindow;



        public MainWindow()
        {
            InitializeComponent();
            DB = new DbController();        // Creates a DB controller to be used by the UI classes. 
            
            // create windows
            EventReportWindow = new UI.EventReportWindow(this);
            EventReportWindow.Hide();
            ManageClientsWindow = new UI.ManageClientsWindow();


            this.nathanDebug();                  // Code to debug Db in dev. cycle.
            
        }

        // Used for DB Debugging purposes, NL to clean up
        // Do not modify or worry about the class behind, work in progress. 
        private void nathanDebug()
        {            
            Staff s1 = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays",
                Staff.Active.active);

            Support_Classes.Task t1 = new Support_Classes.Task("Set table at venue", "Set 12 tables", 
                Support_Classes.Task.Priority.high, new DateTime(2015, 12, 12), s1);

            DB.ShowData();   // Test the select statement. 

            try
            {
                bool result = DB.AddStaff(s1);
                //db.AddTask(t1);
                Console.WriteLine("s1 Added to Staff?  " + result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }    

        }

        private void ManageSuppliersButton_Click(object sender, EventArgs e)
        {
            UI.ManageSuppliersWindow win = new UI.ManageSuppliersWindow();
            win.Visible = true;
        }

        private void ManageStaffButton_Click(object sender, EventArgs e)
        {
            UI.ManageStaffWindow win = new UI.ManageStaffWindow();
            win.Visible = true;
        }

        private void ManageTasksButton_Click(object sender, EventArgs e)
        {
            UI.ManageTasksWindow win = new UI.ManageTasksWindow();
            win.Visible = true;
        }

        private void ManageClientsButton_Click(object sender, EventArgs e)
        {
            UI.ManageClientsWindow win = new UI.ManageClientsWindow();
            win.Visible = true;
        }

        private void ManageWeddingsButton_Click(object sender, EventArgs e)
        {
            UI.ManageWeddingsWindow win = new UI.ManageWeddingsWindow();
            win.Visible = true;
        }

        private void NewStaffButton_Click(object sender, EventArgs e)
        {
            UI.NewStaffWindow win = new UI.NewStaffWindow();
            win.Visible = true;
        }

        private void NewTaskButton_Click(object sender, EventArgs e)
        {
            UI.NewTaskWindow win = new UI.NewTaskWindow();
            win.Visible = true;
        }

        private void NewSupplierButton_Click(object sender, EventArgs e)
        {
            UI.NewSupplierWindow win = new UI.NewSupplierWindow();
            win.Visible = true;
        }

        private void NewWeddingButton_Click(object sender, EventArgs e)
        {
            UI.NewWeddingWindow win = new UI.NewWeddingWindow();
            win.Visible = true;
        }

        private void NewClientButton_Click(object sender, EventArgs e)
        {
            UI.NewClientWindow win = new UI.NewClientWindow();
            win.Visible = true;
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            UI.EventReportWindow win = new UI.EventReportWindow(this);
            win.Visible = true;
        }
    }
}
