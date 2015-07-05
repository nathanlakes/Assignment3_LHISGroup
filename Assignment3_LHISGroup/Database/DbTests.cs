using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment3_LHISGroup.Support_Classes;
using System.Windows.Forms;


namespace Assignment3_LHISGroup.Database
{
    class DbTests
    {

        DbController db;

        public DbTests()
        {
            db = new DbController();
            runTests();
        }

        private void runTests()
        {
            //
            // Test Add
            //
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
                MessageBox.Show("AddWedding(Wedding) >> " + e.ToString());
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

            //
            // Test Get Alls
            //
            {
                var res = db.GetAllClients();
                string output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output);
            }

            {
                var res = db.GetAllStaff();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output);
            }

            {
                var res = db.GetAllSuppliers();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output);
            }

            {
                var res = db.GetAllTasks();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output);
            }

            {
                var res = db.GetAllWeddings();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output);
            }

            //
            //  Test Find on Clients
            //
            {
                // Find Client ID = 1 (Wendy)
                Client c1 = db.FindClient(1);
                MessageBox.Show(c1.ToString(), "Find Wendy?");

                // Find Stan
                Client c2 = db.FindClient(stan);
                MessageBox.Show(c2.ToString(), "Find Stan?");

                // Find Stan via partial match
                List<Client> c3 = db.FindClients("Wen");
                foreach (var i in c3)
                {
                    MessageBox.Show(i.ToString(), "Searching 'Wen', matches:");
                }
            }

            //
            //   Test Find on Suppliers
            //
            {
                List<Supplier> s = db.FindSupplier("Nat");
                foreach (var i in s)
                {
                    MessageBox.Show(i.ToString(), "Suppliers matching 'Nat'");
                }

                Supplier s2 = db.FindSupplier(2);
                MessageBox.Show(s2.ToString(), "Supplier #2 is:");

                Supplier s3 = db.FindSupplier(flowers);
                MessageBox.Show(s3.ToString(), "Supplier 'flowers' is:");
            }

            //
            //   Test Find on Tasks
            //
            {
                Support_Classes.Task t = db.FindTask(6);
                MessageBox.Show(t.ToString(), "Task #6 is:");

                Support_Classes.Task t2 = db.FindTask(t);
                MessageBox.Show(t.ToString(), "Task 't' returns");
            }

            //
            //   Test Find Staff
            //
            {
                Staff s = db.FindStaff(4);
                MessageBox.Show( s.ToString(), "Test Find Staff on id #4" );

                Staff s2 = db.FindStaff(nate);
                MessageBox.Show(s2.ToString(), "Try to find 'nate' from obj.");
            }


            //
            //   Test Find Wedding
            //
            {
                Wedding wedd = db.FindWedding(1);
                MessageBox.Show(wedd.ToString(), "Find Wedding #1");

                Wedding wedd1 = db.FindWedding(w);
                MessageBox.Show(wedd1.ToString(), "Find on Wedding obj 'w'");

                List<Wedding> wedd2 = db.FindWedding("Wend");
                foreach (var z in wedd2)
                {
                    MessageBox.Show(z.ToString(), "Weddings matching title 'Wend'");
                }
            }

            //
            //   Test All Active Staff
            //
            {
                List<Staff> allAct = db.AllActiveStaff();
                foreach (var s in allAct)
                {
                    MessageBox.Show(s.ToString(), "All Active Staff");
                }
            }


            //
            //   Test Updates
            //
            {
                MessageBox.Show(t1.ToString(), "OLD TASK");

                Support_Classes.Task t2 = new Support_Classes.Task("Hang Paintings", "Art",
                    Support_Classes.Task.Priority.high, new DateTime(2017, 5, 5), nate, w);

                db.UpdateTask(6, t2);

                MessageBox.Show(db.FindTask(6).ToString(), "UPDATED TASK");

                //
                // Update Person on Task.
                //
                Staff jim = new Staff("Jim", "Fish", "jfish@weddrus.com", "0883354545", "Pagan Weddings",
                    Staff.Active.inactive);

                db.AddStaff(jim);

                db.UpdatePersonOnTask(db.FindTask(6), jim);

                MessageBox.Show(db.FindTask(6).ToString(), "Person on Task was Nate, should now be Jim");
            }


            //
            //   Update Client
            //
            {
                Client temp = db.FindClient(wendy);
                temp.ContactPerson = "Arson East";
                temp.Surname = "Harlson";
                temp.EngagedTo_sn = "marsh";
                db.UpdateClient(db.getClientId(wendy), temp);
                MessageBox.Show(db.FindClient(temp).ToString(), "Has Wendy been updated?");
            }


            //
            //   Update Wedding
            //
            {
                Wedding wedd = db.FindWedding(w);
                wedd.Title = "Wedding of Some People";
                wedd.EventDate = new DateTime(2017, 12, 12);
                db.UpdateWedding(db.getWeddingId(w), wedd);
                MessageBox.Show(db.FindWedding(wedd).ToString(), "Have Wedding Details been changed?");

            }

            //
            //   Update Supplier
            //
            {
                Supplier supp = db.FindSupplier(flowers);
                supp.CompanyName = "Flowers By Irene";
                db.UpdateSupplier(db.getSupplierId(flowers), supp);
                MessageBox.Show(db.FindSupplier(supp).ToString(), "Have Supplier Details been changed?");
            }

            //
            //   Update Staff
            //
            {
                Staff s = db.FindStaff(nate);
                s.FirstName = "Nathaniel";
                s.Surname = "Theodoroulakis";
                db.UpdateStaff(db.getStaffId(nate), s);
                MessageBox.Show(db.FindStaff(s).ToString(), "Have Staff Details been changed?");
            }
        }
    }
}
