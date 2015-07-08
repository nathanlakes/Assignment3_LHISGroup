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
            new Database.DbTests();         // Run Nathan's Controller Tests.


            InitializeComponent();
            db = new DbController();        // Creates a DB controller to be used by the UI classes. 

            this.louiseTestDataPopulate();
            this.nathanDebug();


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

        public void RefreshAllWindow()
        {

            UpdateTaskWindow.RefreshData();

            UpdateWeddingWindow.RefreshData();
            
            ManageTasksWindow.RefreshData();

            NewTaskWindow.RefreshData();

            NewWeddingWindow.RefreshData();

        }

        private void louiseTestDataPopulate()
        {
            
            Supplier supplier_1 = new Supplier("Lotus", "565 ANZAC Highway", "Charlote Hensen", "charlotte@lotus.com", "78905634", 10);
            Supplier supplier_2 = new Supplier("CarterCaterers", "2 Main St", "Carol Carter", "carol@carter.com", "98238712", 20);

            Staff staff_1 = new Staff("Louise", "Lawrence", "llawrence@wedplan.com", "8321254", "cant work sundays", Staff.Active.active);
            Staff staff_2 = new Staff("Adam", "Jenkins", "ajenkins@wedplan.com", "98788923", "", Staff.Active.active);
            Staff staff_3 = new Staff("Jim", "Barry", "jbarry@wedplan.com", "89237834", "", Staff.Active.inactive);
            Staff staff_4 = new Staff("Daniel", "Stone", "dstone@wedplan.com", "98782389", "", Staff.Active.active);
            Staff staff_5 = new Staff("Nathan", "Lakes", "nlakes@wedplan.com", "87320932", "Always available\noften overloaded with work\ntry to avoid giving Nathan extra tasks if possible", Staff.Active.active);


            Client client_1 = new Client("Jane", "Smith", "Jane Smith", "26 Oak Avenue", "23441212", "12098776", "jan@gmail.com", "John", "James");
            Client client_2 = new Client("John", "James", "Jane Smith", "82 Pine St", "23342143", "87923423", "jj@jay.com", "Jane", "Smith");
            Client client_3 = new Client("Jim", "Brown", "Jim Brown", "861 Downtown St", "0437233892", "87323236", "bj@hotmail.com", "Belle", "Wright");
            Client client_4 = new Client("Beth", "Wright", "Jim Brown", "43 High St", "02376278", "98238723", "beth@live.com", "Jim", "Brown");


            Wedding wedding_1 = new Wedding("Wright Brown Wedding", "Small garden wedding at the Roundta", client_3, client_4, staff_2, new DateTime(2015, 5, 6), new DateTime(2015, 10, 8), Wedding.Status.InPreparation);
            Wedding wedding_2 = new Wedding("Jay & Jay", "Large wedding, with expected guest list of 500", client_1, client_2, staff_5, new DateTime(2015, 3, 14), new DateTime(2015, 11, 22), Wedding.Status.InPreparation);

            Support_Classes.Task task_1 = new Support_Classes.Task("Catering for J & J", "Need supplies from Carter's Caterers", Support_Classes.Task.Priority.med, new DateTime(2015, 10, 3), staff_1, wedding_1);

            try
            {
                db.AddSupplier(supplier_1);
                db.AddSupplier(supplier_2);

                db.AddStaff(staff_1);
                db.AddStaff(staff_2);
                db.AddStaff(staff_3);
                db.AddStaff(staff_4);
                db.AddStaff(staff_5);

                db.AddClient(client_1);
                db.AddClient(client_2);
                db.AddClient(client_3);
                db.AddClient(client_4);

                db.AddWedding(wedding_1);
                db.AddWedding(wedding_2);

                db.AddTask(task_1);
            }
            catch (Exception)
            {
                MessageBox.Show("Exception thrown");
            }


        }


        // code for Daniel to test
        private void danielTest()
        {
            UI.EventReportWindow ewin = new UI.EventReportWindow(this, db);
            ewin.Show();
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

        private void nathanDebug()
        {
      
        }
    }
}
