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
        public UI.UpdateWindow UpdateSupplierWindow; // accessed from ManageSuppliersWindow
        public UI.UpdateTaskWindow UpdateTaskWindow; // accessed from ManageTasksWindow
        public UI.UpdateWeddingWindow UpdateWeddingWindow; // accessed from ManageWeddingsWindow

        public MainWindow()
        {
            InitializeComponent();
            db = new DbController();        // Creates a DB controller to be used by the UI classes. 
            this.nathanDebug();                  // Code to debug Db in dev. cycle.

            // create windows and hide them for later use
            // this saves on CPU by not recreating them every time they are needed
            EventReportWindow = new UI.EventReportWindow(this, db);
            EventReportWindow.Hide();

            UpdateClientWindow = new UI.UpdateClientWindow(this, db);
            UpdateClientWindow.Hide();

            UpdateStaffWindow = new UI.UpdateStaffWindow(this, db);
            UpdateStaffWindow.Hide();

            UpdateSupplierWindow = new UI.UpdateWindow(this, db);
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

            NewClientWindow = new UI.NewClientWindow(this, db);
            NewClientWindow.Hide();

            NewStaffWindow = new UI.NewStaffWindow(this, db);
            NewStaffWindow.Hide();

            NewSupplierWindow = new UI.NewSupplierWindow(this, db);
            NewSupplierWindow.Hide();

            NewTaskWindow = new UI.NewTaskWindow(this, db);
            NewTaskWindow.Hide();

            NewWeddingWindow = new UI.NewWeddingWindow(this, db);
            NewWeddingWindow.Hide();




            //this.danielTest();   // Code for Daniel to test reports
        }

        private void louiseTestDataPopulate()
        {
            
        }


        // code for Daniel to test
        private void danielTest()
        {
            UI.EventReportWindow ewin = new UI.EventReportWindow(this, db);
            ewin.Show();
        }


        // Used for DB Debugging purposes, NL to clean up
        // Do not modify or worry about the class behind, work in progress. 


        private void nathanDebug()
        {
            Supplier flowers = new Supplier("Flowers Are Us", "21 Louloudi St", "Glenda Smithe",
                "glenda@flowersrus.com.au", "08 8335 4121", 30);

            db.AddSupplier(flowers);


            Staff nate = new Staff("Nathan", "Lakes", "nate@weddingsRUs.com", "0401745241", "Bitter and Divorced", 
                Staff.Active.active);

            db.AddStaff(nate);

            Client wendy = new Client("Wendy", "Testaburger", "Wendy Testaburger", "100 Smith Street", "040444555",
                "0883321454", "wendy@wendymail.com", "Stan", "Marsh");

            Client stan = new Client("Stan", "Marsh", "Kyle", "101 Smith Street", "0404533222",
                "0883324454", "stan@stanmail.com", "Wendy", "Testaburger");

            db.AddClient(wendy);
            db.AddClient(stan);

            DateTime start = new DateTime(2015, 11, 10);
            DateTime eventDate = new DateTime(2015, 12, 20);

            Wedding w = new Wedding("Wedding of Stan and Wendy", "Beach theme", stan, wendy, nate, start, eventDate);

            try
            {
                db.AddWedding(w);
            }
            catch (Exception e)
            {
                MessageBox.Show("AddWedding(Wedding) >> " + e.ToString() );
            }
            

            DateTime completeBy = new DateTime(2015, 12, 18);

            Support_Classes.Task t1 = new Support_Classes.Task("Set Tables", "Add table cloth to 20 tables",
                Support_Classes.Task.Priority.high, completeBy, nate, w);

            try
            {
                db.AddTask(t1);
            }
            catch (Exception e)
            {
                MessageBox.Show("AddTask(Task) >> " + e.ToString());
            }

            // Test Get Alls
            var res = db.GetAllClients();
            string output = "";
            foreach (var v in res)
            {
                output += v.ToString() + "\n";
            }
            MessageBox.Show(output);

        }


        // Code for Buttons
        // DO NOT REMOVE unless you don't want the buttons to do anything
        private void ManageSuppliersButton_Click(object sender, EventArgs e)
        {
            if (!ManageSuppliersWindow.Visible)
            {
                ManageSuppliersWindow.Visible = true;
            }
            else
            {
                ManageSuppliersWindow.Focus();
            }
        }

        private void ManageStaffButton_Click(object sender, EventArgs e)
        {
            if (!ManageStaffWindow.Visible)
            {
                ManageStaffWindow.Visible = true;
            }
            else
            {
                ManageStaffWindow.Focus();
            } 
        }

        private void ManageTasksButton_Click(object sender, EventArgs e)
        {
            if (!ManageTasksWindow.Visible)
            {
                ManageTasksWindow.Visible = true;
            }
            else
            {
                ManageTasksWindow.Focus();
            }
        }

        private void ManageClientsButton_Click(object sender, EventArgs e)
        {
            if (!ManageClientsWindow.Visible)
            {
                ManageClientsWindow.Visible = true;
            }
            else
            {
                ManageClientsWindow.Focus();
            }
        }

        private void ManageWeddingsButton_Click(object sender, EventArgs e)
        {
            if (!ManageWeddingsWindow.Visible)
            {
                ManageWeddingsWindow.Visible = true;
            }
            else
            {
                ManageWeddingsWindow.Focus();
            }
        }

        private void NewStaffButton_Click(object sender, EventArgs e)
        {
            if (!NewStaffWindow.Visible)
            {
                NewStaffWindow.Visible = true;
            }
            else
            {
                NewStaffWindow.Focus();
            }
        }

        private void NewTaskButton_Click(object sender, EventArgs e)
        {
            if (!NewTaskWindow.Visible)
            {
                NewTaskWindow.Visible = true;
            }
            else
            {
                NewTaskWindow.Focus();
            }
        }

        private void NewSupplierButton_Click(object sender, EventArgs e)
        {
            if (!NewStaffWindow.Visible)
            {
                NewSupplierWindow.Visible = true;
            }
            else
            {
                NewSupplierWindow.Focus();
            }            
        }

        private void NewWeddingButton_Click(object sender, EventArgs e)
        {
            if (!NewWeddingWindow.Visible)
            {
                NewWeddingWindow.Visible = true;
            }
            else
            {
                NewWeddingWindow.Focus();
            }
        }

        private void NewClientButton_Click(object sender, EventArgs e)
        {
            if (!NewClientWindow.Visible)
            {
                NewClientWindow.Visible = true;
            }
            else
            {
                NewClientWindow.Focus();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // dispose of all windows.
            ManageClientsWindow.Dispose();
            ManageStaffWindow.Dispose();
            ManageSuppliersWindow.Dispose();
            ManageTasksWindow.Dispose();
            ManageWeddingsWindow.Dispose();
            NewClientWindow.Dispose();
            NewStaffWindow.Dispose();
            NewSupplierWindow.Dispose();
            NewTaskWindow.Dispose();
            NewWeddingWindow.Dispose();
            EventReportWindow.Dispose();
            UpdateClientWindow.Dispose();
            UpdateStaffWindow.Dispose();
            UpdateSupplierWindow.Dispose();
            UpdateTaskWindow.Dispose();
            UpdateWeddingWindow.Dispose();
            this.Dispose();
        }
    }
}
