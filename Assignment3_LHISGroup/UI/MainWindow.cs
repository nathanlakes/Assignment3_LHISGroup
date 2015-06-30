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
        public MainWindow()
        {
            InitializeComponent();
            //DbController db = new DbController();


            // DEBUGGING
            try
            {
                Support_Classes.Staff s = new Support_Classes.Staff("Me", "Me", "nl@mail.com", "0888548", "goat", true);

                Support_Classes.Task t = new Support_Classes.Task("moo", "moo",
                        Support_Classes.Task.Priority.high, new DateTime(2016, 5, 20), s);

                t.CompletionDate = new DateTime(2015, 07, 20);

                Console.WriteLine( t.CompletionDate );

            }
            catch (Exception e) 
            {
                Console.WriteLine( e.ToString() ); 
            }
           

        }

        private void ManageSuppliersButton_Click(object sender, EventArgs e)
        {
            UI.ManageSuppliersWindow manageSuppliersWin = new UI.ManageSuppliersWindow();
            manageSuppliersWin.Visible = true;
        }

        private void ManageStaffButton_Click(object sender, EventArgs e)
        {
            UI.ManageStaffWindow manageStaffWin = new UI.ManageStaffWindow();
            manageStaffWin.Visible = true;
        }

        private void ManageTasksButton_Click(object sender, EventArgs e)
        {
            UI.ManageTasksWindow manageTasksWin = new UI.ManageTasksWindow();
            manageTasksWin.Visible = true;
        }

        private void ManageClientsButton_Click(object sender, EventArgs e)
        {
            UI.ManageClientsWindow manageClientsWin = new UI.ManageClientsWindow();
            manageClientsWin.Visible = true;
        }

        private void ManageWeddingsButton_Click(object sender, EventArgs e)
        {
            UI.ManageWeddingsWindow manageWeddingsWin = new UI.ManageWeddingsWindow();
            manageWeddingsWin.Visible = true;
        }

        private void NewStaffButton_Click(object sender, EventArgs e)
        {
            UI.NewStaffWindow newStaffWin = new UI.NewStaffWindow();
            newStaffWin.Visible = true;
        }
    }
}
