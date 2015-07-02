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

        public DbController db;

        // windows accessed from the main window
        public UI.ManageClientsWindow ManageClientsWindow;
        public UI.ManageStaffWindow ManageStaffWindow;
        public UI.ManageSuppliersWindow ManageSuppliersWindow;
        public UI.ManageTasksWindow ManageTasksWindow;
        public UI.ManageWeddingsWindow ManageWeddingsWindow;

        public UI.NewClientWindow NewClientWindow;
        public UI.NewStaffWindow NewStaffWindow;
        public UI.NewSupplierWindow NewSupplierWindow;
        public UI.NewTaskWindow NewTaskWindow;
        public UI.NewWeddingWindow NewWeddingWindow;


        // windows accesssed from other windows
        public UI.EventReportWindow EventReportWindow; // accessed from UpdateWeddingWindow
        public UI.UpdateClientWindow UpdateClientWindow; // accessed from ManageClientsWindow
        public UI.UpdateStaffWindow UpdateStaffWindow; // accessed from ManageStaffWindow
        public UI.UpdateSupplierWindow UpdateSupplierWindow; // accessed from ManageSuppliersWindow
        public UI.UpdateTaskWindow UpdateTaskWindow; // accessed from ManageTasksWindow
        public UI.UpdateWeddingWindow UpdateWeddingWindow; // accessed from ManageWeddingsWindow

        public MainWindow()
        {
            InitializeComponent();
            db = new DbController();        // Creates a DB controller to be used by the UI classes. 
            
            // create windows and hide them for later use
            // this saves on CPU by not recreating them every time they are needed
            EventReportWindow = new UI.EventReportWindow(this, db);
            EventReportWindow.Hide();

            UpdateClientWindow = new UI.UpdateClientWindow(this, db);
            UpdateClientWindow.Hide();

            UpdateStaffWindow = new UI.UpdateStaffWindow(this, db);
            UpdateStaffWindow.Hide();

            UpdateSupplierWindow = new UI.UpdateSupplierWindow(this, db);
            UpdateSupplierWindow.Hide();
            
            UpdateTaskWindow = new UI.UpdateTaskWindow(this, db);
            UpdateTaskWindow.Hide();

            UpdateWeddingWindow = new UI.UpdateWeddingWindow(this, db);
            UpdateWeddingWindow.Hide();
            
            ManageClientsWindow = new UI.ManageClientsWindow(this, db);
            ManageClientsWindow.Hide();

            ManageStaffWindow = new UI.ManageStaffWindow(this, db);
            ManageStaffWindow.Hide();

            ManageSuppliersWindow = new UI.ManageSuppliersWindow(this, db);
            ManageSuppliersWindow.Hide();

            ManageTasksWindow = new UI.ManageTasksWindow(this, db);
            ManageTasksWindow.Hide();

            ManageWeddingsWindow = new UI.ManageWeddingsWindow(this, db);
            ManageWeddingsWindow.Hide();

            NewClientWindow = new UI.NewClientWindow();
            NewClientWindow.Hide();

            NewStaffWindow = new UI.NewStaffWindow();
            NewStaffWindow.Hide();

            NewSupplierWindow = new UI.NewSupplierWindow();
            NewSupplierWindow.Hide();

            NewTaskWindow = new UI.NewTaskWindow();
            NewTaskWindow.Hide();

            NewWeddingWindow = new UI.NewWeddingWindow();
            NewWeddingWindow.Hide();


            this.nathanDebug();                  // Code to debug Db in dev. cycle.

            this.danielTest();   // Code for Daniel to test reports
        }

        // code for Daniel to test
        private void danielTest()
        {
            UI.EventReportWindow ewin = new UI.EventReportWindow(this, db);
            ewin.Show();
            MessageBox.Show("The testing window for reports may be behind the main window");
        }


        // Used for DB Debugging purposes, NL to clean up
        // Do not modify or worry about the class behind, work in progress. 


        private void nathanDebug()
        {            
            Staff s1 = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays",
                Staff.Active.active);

            Support_Classes.Task t1 = new Support_Classes.Task("Set table at venue", "Set 12 tables", 
                Support_Classes.Task.Priority.high, new DateTime(2015, 12, 12), s1);

            db.ShowData();   // Test the select statement. 

            try
            {
                bool result = db.AddStaff(s1);
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
            ManageSuppliersWindow.Visible = true;
        }

        private void ManageStaffButton_Click(object sender, EventArgs e)
        {
            ManageStaffWindow.Visible = true;
        }

        private void ManageTasksButton_Click(object sender, EventArgs e)
        {
            ManageTasksWindow.Visible = true;
        }

        private void ManageClientsButton_Click(object sender, EventArgs e)
        {
            ManageClientsWindow.Visible = true;
        }

        private void ManageWeddingsButton_Click(object sender, EventArgs e)
        {
            ManageWeddingsWindow.Visible = true;
        }

        private void NewStaffButton_Click(object sender, EventArgs e)
        {
            NewStaffWindow.Visible = true;
        }

        private void NewTaskButton_Click(object sender, EventArgs e)
        {
            NewTaskWindow.Visible = true;
        }

        private void NewSupplierButton_Click(object sender, EventArgs e)
        {
            NewSupplierWindow.Visible = true;
        }

        private void NewWeddingButton_Click(object sender, EventArgs e)
        {
            NewWeddingWindow.Visible = true;
        }

        private void NewClientButton_Click(object sender, EventArgs e)
        {
            NewClientWindow.Visible = true;
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            EventReportWindow.Visible = true;
        }
    }
}
