using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment3_LHISGroup.Support_Classes;
using System.Windows.Forms;


namespace Assignment3_LHISGroup.Database
{
    /**
     *   Tests to check the integrity of the DbController.
     *   Writen in conjunction with development of the class.
     */
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

            Wedding w = new Wedding("Wedding of Stan and Wendy", "Beach theme", stan, wendy, nate, start, eventDate, 
                Wedding.Status.InPreparation);

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

            //t1.CompletionDate = new DateTime(2015, 07, 5);  // Set the completion date, test GetAllTasks()

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
                MessageBox.Show(output, "GetAllClients()");
            }

            {
                var res = db.GetAllStaff();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output, "GetAllStaff()");
            }

            {
                var res = db.GetAllSuppliers();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output, "GetAllSuppliers()");
            }

            {
                var res = db.GetAllTasks();
                var output = "";
                foreach (var v in res)
                {
                    output += v.ToString() + "\n";
                }
                MessageBox.Show(output, "GetAllTasks()");
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
                MessageBox.Show(t.ToString(), "Task #6 is:");  // Show empty for comp date.??

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
                Staff dan = new Staff("Daniel", "Stone", "ds@wedmail.com", "123345", "Ginger", Staff.Active.inactive);
                db.AddStaff(dan);
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
                db.UpdateClient(db.GetClientId(wendy), temp);
                MessageBox.Show(db.FindClient(temp).ToString(), "Has Wendy been updated?");
            }


            //
            //   Update Wedding
            //
            {
                Wedding wedd = db.FindWedding(w);
                wedd.Title = "Wedding of Some People";
                wedd.EventDate = new DateTime(2017, 12, 12);
                db.UpdateWedding(db.GetWeddingId(w), wedd);
                MessageBox.Show(db.FindWedding(wedd).ToString(), "Have Wedding Details been changed?");

            }

            //
            //   Update Supplier
            //
            {
                Supplier supp = db.FindSupplier(flowers);
                supp.CompanyName = "Flowers By Irene";
                db.UpdateSupplier(db.GetSupplierId(flowers), supp);
                MessageBox.Show(db.FindSupplier(supp).ToString(), "Have Supplier Details been changed?");
            }

            //
            //   Update Staff
            //
            {
                Staff s = db.FindStaff(nate);
                s.FirstName = "Nathaniel";
                s.Surname = "Theodoroulakis";
                db.UpdateStaff(db.GetStaffId(nate), s);
                MessageBox.Show(db.FindStaff(s).ToString(), "Have Staff Details been changed?");
            }

            //
            //   Change Staff Active Status
            //
            Staff harry = new Staff("Harry", "Lloyd", "hazza@weddingsRUs.com", "045245454", "Works Wednesday",
                Staff.Active.active);

            db.AddStaff(harry);
            int pk = db.GetStaffId(harry);

            db.ChangeStaffActiveStatus(pk, Staff.Active.inactive);
            MessageBox.Show(db.FindStaff(pk).ToString(), "Is Harry now Inactive?");

            //
            //   Test Delete Task
            //
            Support_Classes.Task tempTask = db.FindTask(6);
            db.DeleteTask(6);
            try
            {
                Support_Classes.Task tempTask2 = db.FindTask(6);
                MessageBox.Show(tempTask2.ToString(), "Try to display deleted task");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


            //
            //   Test Delete Wedding
            //
            {
                Staff paul = new Staff("Paul", "Lincoln", "paul@weddingsRUs.com", "0401745241", "Way too happy",
                Staff.Active.active);

                db.AddStaff(paul);

                Client vern = new Client("Vern", "Gordge", "Vern", "10 Test st", "04155434", "08", "i@me.com", "Burn", "Hauly");
                Client burn = new Client("Burn", "Hauly", "Burn", "10 Test st", "04155432", "08", "me@i.com", "Vern", "Gordge");

                db.AddClient(vern);
                db.AddClient(burn);

                Wedding testWed = new Wedding("Wedding of a and b", "blah", vern, burn, paul,
                    new DateTime(2016, 5, 5), new DateTime(2015, 5, 10), Wedding.Status.OnHold);

                db.AddWedding(testWed);

                Support_Classes.Task t3 = new Support_Classes.Task("Hire Dancing Bear", "Can we get those?",
                    Support_Classes.Task.Priority.high, completeBy, paul, db.FindWedding(2));

                db.AddTask(t3);

                    Support_Classes.Task t4 = new Support_Classes.Task("Set More Tables", "Add table cloth to 20 tables",
                        Support_Classes.Task.Priority.high, completeBy, paul, db.FindWedding(1));

                    db.AddTask(t4);

                // Show all weddings and tasks, all task/wedd relating to stan and wendy should be gone
                db.DeleteWedding(1);

                List<Support_Classes.Task> tlist = db.GetAllTasks();
                foreach (var t in tlist)
                {
                    MessageBox.Show(t.ToString(), "Remaining Tasks");
                }
                List<Wedding> wlist = db.GetAllWeddings();
                foreach (var t in wlist)
                {
                    MessageBox.Show(t.ToString(), "Remaining Weddings");
                }
            }
      
            //
            //   Test Delete Supplier
            //
            db.DeleteSupplier(1); // Delete NathanCorp
            List<Supplier> slist = db.GetAllSuppliers();
            foreach (var s in slist)
            {
                MessageBox.Show(s.ToString(), "Remaining Suppliers after deleting NatoCorp");
            }

            //
            //   Test Duplicate Adds
            //
            {
                //
                //  Add Duplicate Client
                //
                Client hervard = new Client("Hervard", "Brakes", "Gary", "100 Smith St", "040343433", "088332141",
                    "Nate@natemail.com", "My", "Cat");

                bool firstAdd = db.AddClient(hervard);
                bool secondAdd = db.AddClient(hervard);

                MessageBox.Show("firstAdd= " + firstAdd + "\n" + "secondAdd= " + secondAdd,
                    "Test Second Add FALSE for AddClient()");

                List<Client> clist = db.GetAllClients();
                int i = 1;
                foreach (var v in clist)
                {                    
                    MessageBox.Show(v.ToString(), "Client's in Database " + i);
                    i++;
                }
            }

            {
                //
                //  Add Duplicate Supplier
                //
                Staff myStaff1 = new Staff("Henry", "Kissinger", "Hkiss@NixonMail.com", "911",
                    "Do not trust", Staff.Active.inactive);

                bool firstAdd = db.AddStaff(myStaff1);
                bool secondAdd = db.AddStaff(myStaff1);

                MessageBox.Show("firstAdd= " + firstAdd + "\n" + "secondAdd= " + secondAdd, 
                    "Test 2nd Add False for AddStaff()");

                List<Staff> stfList = db.GetAllStaff();
                int i = 1;
                foreach (var v in stfList)
                {
                    MessageBox.Show(v.ToString(), "Staff in Database " + i);
                    i++;
                }
            }

        }
    }
}
