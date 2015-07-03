using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Assignment3_LHISGroup.Support_Classes;

namespace Assignment3_LHISGroup
{

    /**
     *   The controller for the SQL Database [model.mdf]. 
     *   All views in "UI" interact exclusively with DbController.cs. 
     *   They pass as arguments objects from "Support Classes" to write to the Db and 
     *   when reads are quested receive objects of those classes back.
     */
    public class DbController
    {

        SqlConnection _db;
        string connStr = "Data Source=(LocalDB)\\v11.0;" +
                    "AttachDbFilename=|DataDirectory|\\Database\\Model.mdf;" +
                    "Integrated Security=True";

        public DbController()
        {
            _db = new SqlConnection(connStr);
        }

        public DbController(string myConnection)
        {
            connStr = myConnection;
            _db = new SqlConnection(connStr);
        }

        /**
         *   Adds a given Staff Member to a task and writes to the database.
         *   Nb. Task cannot be made without it being assigned to somebody.
         *   @Param  t:  The task to add.
         */
        public bool AddTask(Support_Classes.Task t)
        {
            Staff s = t.AssignedTo;

            // Check that staff exists in the database. Phone number used for cases where
            // Staff with the same name work together. They won't have the same phone ext. 
            // though. 
            int staffId = getStaffId(s);
            if (staffId == -1) throw new Exception("Staff must exist in Db.Staff, before being assigned to a task:");

            int res = 0;

            _db.Open();
            String query = @"INSERT INTO Task(name, description, priority,completeByDate, ";
            query += "actualCompletionDate,staffOnJob_FK)";
            query += @" VALUES( @taskname, @description, @priority, @completeByDate, @actualComplete, @staffOnJob)";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@taskname", t.TaskName);
            myCommand.Parameters.AddWithValue("@description", t.Description);
            myCommand.Parameters.AddWithValue("@priority", t.TaskPriority);
            myCommand.Parameters.AddWithValue("@completeByDate", t.CompleteBy.ToShortDateString());
            try
            {
                DateTime compDate = t.CompletionDate;
                myCommand.Parameters.AddWithValue("@actualComplete", compDate.ToShortDateString());
            }
            catch (Exception)
            {
                myCommand.Parameters.AddWithValue("@actualComplete", null);
            }


            myCommand.Parameters.AddWithValue("@staffOnJob", staffId.ToString());

            res = myCommand.ExecuteNonQuery();

            _db.Close();

            if (res == 1) return true;
            return false;
        }


        /**
        *   Updates an existing task with the new values provided.
        *   @Param  id: the primary key of the task to change
        *   @Param  t : the new task object with updated values
        */
        public bool UpdateTask(int id, Support_Classes.Task t)
        {
            int staffID = getStaffId(t.AssignedTo);

            string query = @"UPDATE Task";
            query += @"SET name='@name', description ='@description', priority='@priority', ";
            query += @"completeByDate='@completeByDate', actualCompletionDate='@actualCompDate,";
            query += @"staffOnJob_FK='@staffOnJob";
            query += @"WHERE id=@id";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@name", t.TaskName);
            myCommand.Parameters.AddWithValue("@description", t.Description);
            myCommand.Parameters.AddWithValue("@priority", t.TaskPriority);
            myCommand.Parameters.AddWithValue("@completeByDate", t.CompleteBy.ToShortDateString());

            try
            {
                myCommand.Parameters.AddWithValue("@actualCompDate", t.CompletionDate.ToShortDateString());
            }
            catch (Exception)
            {
                myCommand.Parameters.AddWithValue("@actualCompDate", null);
            }

            myCommand.Parameters.AddWithValue("@staffOnJob", staffID);
            myCommand.Parameters.AddWithValue("@id", id);

            _db.Open();
            int res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }


        /**
         *   Changes the Staff member assigned to a task.
         *   @Param  t: the task to update
         *   @Param  s: the staff member to assign 't' to
         */
        public bool UpdatePersonOnTask(Support_Classes.Task t, Staff s)
        {
            // Find ID number of staff.
            int staffId = getStaffId(s);
            if (staffId == -1) throw new Exception("Staff must exist in Db.Staff, before being assigned to a task:");

            // Find ID of Task
            int taskId = getTaskId(t);
            if (taskId == -1) throw new Exception("Task does not exist.");

            int res = 0;

            String query = "UPDATE Task SET staffOnJob_FK='@staffId' WHERE Id='@taskId'";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@staffId", staffId);
            myCommand.Parameters.AddWithValue("@taskId", taskId);

            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            else return false;
        }

        /**
         *   Removes a Task from the database.
         *   @Param  id: the primary key of the task
         */
        public bool DeleteTask(int id)
        {
            int res = 0;

            String query = "DELETE FROM Task WHERE Id=@idnum";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@idnum", id);

            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Adds a client to the database.
         *   @Param  c: the client to add.
         */
        public bool AddClient(Client c)
        {
            String query = @"INSERT into Client (firstname, surname, contactPerson, address, ";
            query += @"mobile, homePhone, email, engagedTo_firstname, engagedTo_surname)";
            query += @" VALUES (@firstname, @surname, @contactPerson, @address, @mobile, @homePhone, ";
            query += @"@email, @engFn, @engSn)";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@firstname", c.Firstname);
            myCommand.Parameters.AddWithValue("@surname", c.Surname);
            myCommand.Parameters.AddWithValue("@contactPerson", c.ContactPerson);
            myCommand.Parameters.AddWithValue("@address", c.Address);
            myCommand.Parameters.AddWithValue("@mobile", c.Mobile);
            myCommand.Parameters.AddWithValue("@homePhone", c.HomePhone);
            myCommand.Parameters.AddWithValue("@email", c.Email);
            myCommand.Parameters.AddWithValue("@engFn", c.EngagedTo_fn);
            myCommand.Parameters.AddWithValue("@engSn", c.EngagedTo_sn);


            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            else return false;
        }

        /**
         *   Updates an existing client with the values provided
         *   @Param  id: the Client to update
         *   @Param  c : the new details of client with the given id number
         */
        public bool UpdateClient(int id, Client c)
        {
            string query = @"UPDATE Client";
            query += @"SET firstname='@firstname', surname='@surname', contactPerson='@contactPerson', address='@address', ";
            query += @"mobile=@'mobile', homePhone='@homePhone', email='@email', ";
            query += @"engagedTo_firstname='@engFn', engagedTo_surname='@engSn'";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@firstname", c.Firstname);
            myCommand.Parameters.AddWithValue("@surname", c.Surname);
            myCommand.Parameters.AddWithValue("@contactPerson", c.ContactPerson);
            myCommand.Parameters.AddWithValue("@address", c.Address);
            myCommand.Parameters.AddWithValue("@mobile", c.Mobile);
            myCommand.Parameters.AddWithValue("@homePhone", c.HomePhone);
            myCommand.Parameters.AddWithValue("@email", c.Email);
            myCommand.Parameters.AddWithValue("@engFn", c.EngagedTo_fn);
            myCommand.Parameters.AddWithValue("@engSn", c.EngagedTo_sn);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            else return false;
        }

        /**
         *   Deletes a client from the database
         *   @Param  id:  the client to delete
         */
        public bool DeleteClient(int id)
        {
            string query = @"DELETE FROM Client";
            query += @"WHERE id='@id'";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Finds clients matching the pattern of s
         *   @Param name:  the partial firstname or surname to search for.
         */
        public List<Client> FindClients(string name)
        {
            List<Client> returnList = new List<Client>();

            string query = "SELECT * FROM Clients";
            query += "WHERE firstname LIKE '%@fn%' OR surname LIKE '%@sn%'";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@fn", name);
            myCommand.Parameters.AddWithValue("@sn", name);

            _db.Open();
            SqlDataReader myReader = myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                string firstname = myReader["firstname"].ToString();
                string surname = myReader["surname"].ToString();
                string contact = myReader["contactPerson"].ToString();
                string address = myReader["address"].ToString();
                string mobile = myReader["mobile"].ToString();
                string homephone = myReader["homephone"].ToString();
                string email = myReader["email"].ToString();
                string engaged_fn = myReader["engagedTo_firstname"].ToString();
                string engaged_sn = myReader["engagedTo_surname"].ToString();

                Client c = new Client(firstname, surname, contact, address, mobile, homephone, email, engaged_fn, engaged_sn);
                c.ID = Convert.ToInt32(myReader["id"].ToString());

                returnList.Add(c);
            }
            _db.Close();

            return returnList;
        }

        /**
         *   Adds a Wedding to the database
         *   @Param  w: The Wedding to add
         */
        public bool AddWedding(Wedding w)
        {
            string query = @"INSERT into Wedding";
            query += @"(title, client_1_FK, client_2_FK, startDate, EventDate, weddingPlanner_FK)";
            query += @"VALUES(@title, @client1, @client2, @startDate, @eventDate, @weddingPlanner)";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@title", w.Title.ToString());

            int clientOneFk;
            int clientTwoFk;
 
            clientOneFk = getClientId(w.Client1);
            if (clientOneFk == -1) throw new Exception("Client must be in database before adding wedding.");

            clientTwoFk = getClientId(w.Client2);
            if (clientTwoFk == -1) throw new Exception("Client must be in database before adding wedding.");

            myCommand.Parameters.AddWithValue("@client1", clientOneFk);
            myCommand.Parameters.AddWithValue("@client2", clientTwoFk);
            myCommand.Parameters.AddWithValue("@startDate", formatDateForDbInput(w.StartDate) );
            myCommand.Parameters.AddWithValue("@eventDate", formatDateForDbInput(w.EventDate));
            
            int wedPlanner = getStaffId(w.WeddingPlanner);
            if (wedPlanner == -1) throw new Exception("Wedding Planner must exist in Staff Table.");
            myCommand.Parameters.AddWithValue("@weddingPlanner", wedPlanner);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Updates an existing wedding with new details
         *   @Param  id: The Wedding to update
         *   @Param   w: The new details of the wedding
         */
        public bool UpdateWedding(int id, Wedding w)
        {
            string query = @"UPDATE Wedding";
            query += @"SET title='@title', client_1_FK='@client1', client_2_FK='@client2', startDate='@startDate', ";
            query += @"eventDate='@eventDate', weddingPlanner_FK='@weddingPlanner_FK'";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@title", w.Title);
            myCommand.Parameters.AddWithValue("@client1", w.Client1.Firstname + " " + w.Client1.Surname);
            myCommand.Parameters.AddWithValue("@client2", w.Client2.Firstname + " " + w.Client2.Surname);
            myCommand.Parameters.AddWithValue("@startDate", w.StartDate.ToShortDateString());
            myCommand.Parameters.AddWithValue("@eventDate", w.EventDate.ToShortDateString());
            myCommand.Parameters.AddWithValue("@weddingPlanner_FK", getStaffId(w.WeddingPlanner));
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Deletes a Wedding from the database
         *   @Param  id: The wedding to remove
         */
        public bool DeleteWedding(int id)
        {
            string query = @"DELETE FROM Wedding";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Finds all weddings matching a given title
         *   @Param  title: the wedding title to find matches.
         *   returns:  a list of all weddings that have a similar title.
         */
        public List<Wedding> FindWedding(string title)
        {
            List<Wedding> returnList = new List<Wedding>();

            string query = "SELECT * FROM Wedding";
            query += "WHERE title LIKE '%@title%'";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@title", title);

            _db.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                string weddTitle = myReader["title"].ToString();

                //
                // Create Client Objects
                //
                // Client 1               
                SqlDataReader c1 = getClientsDetails(Convert.ToInt32(myReader["client_1_fk"].ToString()));
                Client client1 = new Client(
                    c1["firstname"].ToString(),
                    c1["surname"].ToString(),
                    c1["contact"].ToString(),
                    c1["address"].ToString(),
                    c1["mobile"].ToString(),
                    c1["homePhone"].ToString(),
                    c1["email"].ToString(),
                    c1["engagedTo_firsname"].ToString(),
                    c1["engagedTo_surname"].ToString()
                );

                // Client 2
                SqlDataReader c2 = getClientsDetails(Convert.ToInt32(myReader["client_2_fk"].ToString()));
                Client client2 = new Client(
                    c2["firstname"].ToString(),
                    c2["surname"].ToString(),
                    c2["contact"].ToString(),
                    c2["address"].ToString(),
                    c2["mobile"].ToString(),
                    c2["homePhone"].ToString(),
                    c2["email"].ToString(),
                    c2["engagedTo_firsname"].ToString(),
                    c2["engagedTo_surname"].ToString()
                );

                // Generate DateTime for start date.
                string temp = myReader["startDate"].ToString();
                int[] dateArray = splitStringDate(temp);
                DateTime startDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                // Generate DateTime for event date.
                temp = myReader["eventDate"].ToString();
                dateArray = splitStringDate(temp);
                DateTime eventDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                // Create Staff Object
                SqlDataReader stf = getStaffDetails(Convert.ToInt32(myReader["weddingPlanner_FK"].ToString()));
                string status = stf["status"].ToString();
                Staff.Active a;
                if ( status == Staff.Active.active.ToString() )
                {
                    a = Staff.Active.active;
                }
                else { a = Staff.Active.inactive; }
                Staff weddPlann = new Staff(
                    stf["firstname"].ToString(),
                    stf["surname"].ToString(),
                    stf["email"].ToString(),
                    stf["phone"].ToString(),
                    stf["notes"].ToString(),
                    a
                );

                Wedding returnWedding = new Wedding(weddTitle, client1, client2, weddPlann, startDate, eventDate);
                returnWedding.ID = Convert.ToInt32( myReader["ID"].ToString() );

                returnList.Add( returnWedding );
            }
            _db.Close();

            return returnList;
        }

        /**
         *   Adds a supplier to the database
         *   @Param  s: The supplier to add.
         */
        public bool AddSupplier(Supplier s)
        {
            String query = @"INSERT into Suppliers (companyName, Address, contactPerson, Email, PhoneNumber, CreditTerms)";
            query += @" VALUES (@companyName, @address, @contactPerson, @email, @phonenumber, @creditterms)";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@companyName", s.CompanyName);
            myCommand.Parameters.AddWithValue("@address", s.Address);
            myCommand.Parameters.AddWithValue("@contactPerson", s.ContactPerson);
            myCommand.Parameters.AddWithValue("@email", s.Email);
            myCommand.Parameters.AddWithValue("@phonenumber", s.PhoneNumber);
            myCommand.Parameters.AddWithValue("@creditterms", s.CreditTerms);

            int res = 0;

            _db.Open();
            res = myCommand.ExecuteNonQuery();   // Run the statement.
            _db.Close();            

            if (res == 1) return true;           // Should only update one row.
            else return false;
        }

        /**
         *   Deletes a supplier from the database
         *   @Param  id: The supplier to remove.
         */
        public bool DeleteSupplier(int id)
        {
            string query = @"DELETE FROM Supplier ";
            query += "WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }


        /**
         *   Updates an existing supplier in the database.
         *   @Param  id: The supplier to update
         *   @Param   s: The updated supplier details
         */
        public bool UpdateSupplier(int id, Supplier s)
        {

            string query = @"UPDATE Suppliers";
            query += @"SET companyName='@companyname', address='@address', contactPerson='@contactPerson', ";
            query += @"Email='@email', PhoneNumber='@phonenumber', CreditTerms='@creditterms'";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@companyname", s.CompanyName);
            myCommand.Parameters.AddWithValue("@address", s.Address);
            myCommand.Parameters.AddWithValue("@contactPerson", s.ContactPerson);
            myCommand.Parameters.AddWithValue("@email", s.Email);
            myCommand.Parameters.AddWithValue("@phonenumber", s.PhoneNumber);
            myCommand.Parameters.AddWithValue("@creditterms", s.CreditTerms);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Finds all suppliers matching the given name.
         *   @Param  name: The supplier name to find matches
         *   returns: a List of all possible matches
         */
        public List<Supplier> FindSupplier(string name)
        {
            List<Supplier> returnList = new List<Supplier>();

            string query = "SELECT * FROM Suppliers";
            query += "WHERE CompanyName LIKE '%@name%'";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@name", name);

            _db.Open();
            SqlDataReader myReader = myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                string coname = myReader["CompanyName"].ToString();
                string address = myReader["Address"].ToString();
                string contact = myReader["ContactPerson"].ToString();
                string email = myReader["Email"].ToString();
                string phone = myReader["PhoneNumber"].ToString();
                int credterm = Convert.ToInt32( myReader["CreditTerms"].ToString() );

                Supplier s = new Supplier(coname, address, contact, email, phone, credterm);
                returnList.Add(s);
            }
            _db.Close();

            return returnList;
        }


        public bool AddStaff(Staff s)
        {

            String query = @"INSERT into Staff (firstname, surname, email, phone, notes, status)";
            query += @" VALUES (@_firstname, @_surname, @_email, @_phone, @_notes, @_status)";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@_firstname", s.FirstName);
            myCommand.Parameters.AddWithValue("@_surname", s.Surname);
            myCommand.Parameters.AddWithValue("@_email", s.Email);
            myCommand.Parameters.AddWithValue("@_phone", s.Phone);
            myCommand.Parameters.AddWithValue("@_notes", s.Notes);
            myCommand.Parameters.AddWithValue("@_status", s.StatusToString());

            int res = 0;

            _db.Open();
            res = myCommand.ExecuteNonQuery();   // Run the statement.
            _db.Close();           

            if (res == 1) return true;           // Should only update one row.
            else return false;
        }

        /**
         *   Edits an existing staff member. 
         *   @Param  id: staff member to update
         *   @Param   s: the updated staff detrails
         */
        public bool UpdateStaff(int id, Staff s)
        {
            string query = @"UPDATE Staff";
            query += @"SET firstname='@firstname', surname='@surname', email='@email', ";
            query += @"phone='@phone', notes='@notes', status='@status'";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@firstname", s.FirstName);
            myCommand.Parameters.AddWithValue("@surname", s.Surname);
            myCommand.Parameters.AddWithValue("@email", s.Email);
            myCommand.Parameters.AddWithValue("@phone", s.Phone);
            myCommand.Parameters.AddWithValue("@notes", s.Notes);
            myCommand.Parameters.AddWithValue("@status", s.StatusToString());
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Changes the ActiveStatus of a staff member
         *   @Param  id: The staff member to update
         *   @param   a: The active status
         */
        public bool ChangeStaffActiveStatus(int id, Staff.Active a)
        {
            string query = @"UPDATE Staff";
            query += @"SET status='@status'";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@status", a);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();
            _db.Close();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Returns a list of all clients
         */
        public List<Client> GetAllClients()
        {
            List<Client> returnList = new List<Client>();
            
            _db.Open();

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Client", _db);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                string firstname = myReader["firstname"].ToString();
                string surname = myReader["surname"].ToString();
                string contactPerson = myReader["contactPerson"].ToString();
                string address = myReader["address"].ToString();
                string mobile = myReader["mobile"].ToString();
                string homephone = myReader["homePhone"].ToString();
                string email = myReader["email"].ToString();
                string engToFN = myReader["engagedTo_firstname"].ToString();
                string engToSN = myReader["engagedTo_surname"].ToString();
                Client c = new Client(firstname, surname, contactPerson, address, mobile, 
                    homephone, email, engToFN, engToSN);
                returnList.Add(c);
            }
            _db.Close();

            return returnList;
        }

        /**
         *   Returns a list of all staff
         */
        public List<Staff> GetAllStaff()
        {
            List<Staff> returnList = new List<Staff>();

            _db.Open();

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Staff", _db);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                string firstname = myReader["firstname"].ToString();
                string surname = myReader["surname"].ToString();
                string email = myReader["email"].ToString();
                string phone = myReader["phone"].ToString();
                string notes = myReader["notes"].ToString();
                string status = myReader["status"].ToString();

                Staff.Active stat = Staff.Active.inactive;
                if (Staff.Active.active.ToString() == status)
                {
                    stat = Staff.Active.active;
                }

                Staff s = new Staff(firstname, surname, email, phone, notes, stat);
                s.ID = Convert.ToInt32(myReader["Id"].ToString());

                returnList.Add(s);
            }
            _db.Close();

            return returnList;
        }

        /**
         *   Returns a list of all suppliers
         */
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> returnList = new List<Supplier>();

            _db.Open();

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Suppliers", _db);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                string coname = myReader["CompanyName"].ToString();
                string address = myReader["Address"].ToString();
                string contact = myReader["ContactPerson"].ToString();
                string email = myReader["Email"].ToString();
                string phone = myReader["PhoneNumber"].ToString();
                int credterm = Convert.ToInt32(myReader["CreditTerms"].ToString());

                Supplier s = new Supplier(coname, address, contact, email, phone, credterm);
                s.ID = Convert.ToInt32(myReader["Id"].ToString());

                returnList.Add(s);
            }
            _db.Close();

            return returnList;
        }

        /**
         *   Returns a list of all tasks
         */
        public List<Support_Classes.Task> GetAllTasks()
        {
            List<Support_Classes.Task> returnList = new List<Support_Classes.Task>();

            _db.Open();

            SqlDataReader taskReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Task", _db);

            taskReader = myCommand.ExecuteReader();

            while (taskReader.Read())
            {
                string taskname = taskReader["name"].ToString();
                string descr = taskReader["description"].ToString();
                
                // Assign Priority
                string pr = taskReader["priority"].ToString();
                Support_Classes.Task.Priority priority = Support_Classes.Task.Priority.low;
                if (pr == Support_Classes.Task.Priority.med.ToString())
                {
                    priority = Support_Classes.Task.Priority.med;
                }
                else
                {
                    priority = Support_Classes.Task.Priority.high;
                }

                int[] temp = splitStringDate(taskReader["completeByDate"].ToString());
                DateTime completeBy = new DateTime(temp[0], temp[1], temp[2]);

                    // Generate Staff object
                    SqlDataReader staffReader = getStaffDetails(
                        Convert.ToInt32( taskReader["staffOnJob_FK"].ToString() )
                    );
                    Staff.Active a = Staff.Active.active;
                    if (staffReader["status"].ToString() == Staff.Active.inactive.ToString())
                    {
                        a = Staff.Active.inactive;
                    }
                    Staff staff = new Staff(
                        staffReader["firstname"].ToString(),
                        staffReader["surname"].ToString(),
                        staffReader["email"].ToString(),
                        staffReader["phone"].ToString(),
                        staffReader["notes"].ToString(),
                        a
                    );

                    // Generate Wedding Object
                    SqlDataReader weddingReader = getWeddingDetails(Convert.ToInt32(taskReader["weddingID_FK"].ToString()));

                    string title = staffReader["title"].ToString();
                
                    // Get Client one
                    SqlDataReader tempCli = getClientDetails(Convert.ToInt32(weddingReader["client_1_FK"].ToString()));
                    Client c1 = new Client(
                        tempCli["firstname"].ToString(),
                        tempCli["surname"].ToString(),
                        tempCli["contact"].ToString(),
                        tempCli["address"].ToString(),
                        tempCli["mobile"].ToString(),
                        tempCli["homePhone"].ToString(),
                        tempCli["email"].ToString(),
                        tempCli["engagedTo_firstname"].ToString(),
                        tempCli["engagedTo_surname"].ToString()
                    );

                    // Get Client two
                    tempCli = getClientDetails(Convert.ToInt32(weddingReader["client_2_FK"].ToString()));
                    Client c2 = new Client(
                        tempCli["firstname"].ToString(),
                        tempCli["surname"].ToString(),
                        tempCli["contact"].ToString(),
                        tempCli["address"].ToString(),
                        tempCli["mobile"].ToString(),
                        tempCli["homePhone"].ToString(),
                        tempCli["email"].ToString(),
                        tempCli["engagedTo_firstname"].ToString(),
                        tempCli["engagedTo_surname"].ToString()
                    );

                    temp = splitStringDate(weddingReader["startDate"].ToString());
                    DateTime startDate = new DateTime(temp[0], temp[1], temp[2]);

                    temp = splitStringDate(weddingReader["eventDate"].ToString());
                    DateTime eventDate = new DateTime(temp[0], temp[1], temp[2]);

                    Wedding wedding = new Wedding(title, c1, c2, staff, startDate, eventDate);
                

                // Back to making the task now all objects compelted necessary. 
                Support_Classes.Task t = new Support_Classes.Task(taskname, descr, priority, completeBy, 
                    staff, wedding);

                // Assign Actual Complete Date, if any.
                try
                {
                    temp = splitStringDate(taskReader["completeByDate"].ToString());
                    completeBy = new DateTime(temp[0], temp[1], temp[2]);
                    t.CompleteBy = completeBy;
                }
                catch (Exception) { }
                t.ID = Convert.ToInt32(taskReader["Id"].ToString());

                returnList.Add( t );
            }

            _db.Close();

            return returnList;
        }

        /**
         *   Returns a list of all weddings
         */
        public List<Wedding> GetAllWeddings()
        {
            List<Wedding> returnList = new List<Wedding>();

            _db.Open();

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("SELECT * FROM Wedding", _db);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                string title = myReader["title"].ToString();

                // 
                // Make Client 1
                //
                Client client1;
                {
                    int clientId = Convert.ToInt32(myReader["client_1_fk"].ToString());
                    SqlDataReader clientOneReader = getClientDetails(clientId);
                    string name = clientOneReader["firstname"].ToString();
                    string surname = clientOneReader["surname"].ToString();
                    string contact = clientOneReader["contactPerson"].ToString();
                    string address = clientOneReader["address"].ToString();
                    string mobile = clientOneReader["mobile"].ToString();
                    string homeph = clientOneReader["homePhone"].ToString();
                    string email = clientOneReader["email"].ToString();
                    string engFn = clientOneReader["engagedTo_firstname"].ToString();
                    string engSn = clientOneReader["engagedTo_surname"].ToString();
                    client1 = new Client(name, surname, contact, address, mobile, homeph, email, engFn, engSn);
                }              
                
                //
                // Make Client 2
                //
                Client client2;
                {
                    int clientId = Convert.ToInt32(myReader["client_1_fk"].ToString());
                    SqlDataReader clientTwoReader = getClientDetails(clientId);
                    string name = clientTwoReader["firstname"].ToString();
                    string surname = clientTwoReader["surname"].ToString();
                    string contact = clientTwoReader["contactPerson"].ToString();
                    string address = clientTwoReader["address"].ToString();
                    string mobile = clientTwoReader["mobile"].ToString();
                    string homeph = clientTwoReader["homePhone"].ToString();
                    string email = clientTwoReader["email"].ToString();
                    string engFn = clientTwoReader["engagedTo_firstname"].ToString();
                    string engSn = clientTwoReader["engagedTo_surname"].ToString();
                    client2 = new Client(name, surname, contact, address, mobile, homeph, email, engFn, engSn);
                }
                
                //
                // Make Staff
                //
                Staff staff;
                {
                    int staffId = Convert.ToInt32(myReader["weddingPlanner_FK"].ToString());
                    SqlDataReader staffReader = getStaffDetails(staffId);
                    string firstname = staffReader["firstname"].ToString();
                    string surname = staffReader["surname"].ToString();
                    string email = staffReader["email"].ToString();
                    string phone = staffReader["phone"].ToString();
                    string notes = staffReader["notes"].ToString();
                    string active = staffReader["status"].ToString();
                    Staff.Active isActive;
                    if (active == Staff.Active.active.ToString())
                    {
                        isActive = Staff.Active.active;
                    }
                    else
                    {
                        isActive = Staff.Active.inactive;
                    }
                    staff = new Staff(firstname, surname, email, phone, notes, isActive);
                }

                //
                // Create Dates
                //
                int[] tempDate = splitStringDate(myReader["startDate"].ToString());
                DateTime startDate = new DateTime(tempDate[0], tempDate[1], tempDate[2]);

                tempDate = splitStringDate(myReader["eventDate"].ToString());
                DateTime eventDate = new DateTime(tempDate[0], tempDate[1], tempDate[2]);


                //
                // Create Wedding Object
                //
                Wedding w = new Wedding(title, client1, client2, staff, startDate, eventDate);
                w.ID = Convert.ToInt32(myReader["Id"].ToString());

                returnList.Add(w);
            }
            _db.Close();

            return returnList;
        }



        //\\//\\//\\//\\//\\//\\
        //  PRIVATE  METHODS  \\
        //\\//\\//\\//\\//\\//\\

        /**
         *   Checks the Staff table and returns the staff ID number if they exist.
         *   Returns -1 if the staff member does not exist.
         */
        private int getStaffId(Staff s)
        {
            SqlCommand testStaff = new SqlCommand(
               "SELECT id FROM Staff WHERE firstname = '" + s.FirstName + "' AND surname = '" +
               s.Surname + "' AND phone = '" + s.Phone + "'", _db);

            _db.Open();
            int id = -1;
            try
            {
                var myReader = testStaff.ExecuteReader();
                
                if (myReader.Read())
                {
                    id = Convert.ToInt32(myReader["Id"].ToString());
                }
            }
            catch (Exception) { }

            _db.Close();
            return id;
        }

        /**
         *   Checks the Task table and returns the Task Id number if it exists.
         *   Returns -1 if the Task does not exist.
         */
        private int getTaskId(Support_Classes.Task t)
        {
            SqlCommand testTask = new SqlCommand(
               "SELECT Id FROM Task WHERE name = '" + t.TaskName +
                    "' AND description = '" + t.Description + "'", _db);

            _db.Open();
            var myReader = testTask.ExecuteReader();

            int id = -1;
            if (myReader.Read())
            {
                id = Convert.ToInt32(myReader["Id"].ToString());
            }
            return id;
            
        }   // NL UPTO HERE.

        /**
         *   Checks the Client table and returns the Client ID number if it exists.
         *   Returns -1 if the Client does not exsit
         */
        private int getClientId(Client c)
        {
            SqlCommand testTask = new SqlCommand(
               "SELECT Id FROM Client WHERE firstname = '" + c.Firstname +
                    "' AND surname = '" + c.Surname + "' AND homePhone ='" + c.HomePhone + "'", _db);
            _db.Open();
            var myReader = testTask.ExecuteReader();
            int fk = -1;

            if (myReader.Read())
            {
                fk = Convert.ToInt32(myReader["Id"].ToString());
            }

            _db.Close();
            return fk;            
        }


        private SqlDataReader getStaffDetails(int id)
        {
            string query = @"SELECT from Staff ";
            query += @"WHERE id='@id'";
            _db.Open();
            SqlCommand myCommand = new SqlCommand(query, _db);
            SqlDataReader myReader = myCommand.ExecuteReader();
            _db.Close();
            return myReader;
        }

        private SqlDataReader getClientsDetails(int id)
        {
            string query = @"SELECT from Client ";
            query += @"WHERE id=@'id'";
            _db.Open();
            SqlCommand myCommand = new SqlCommand(query, _db);
            SqlDataReader myReader = myCommand.ExecuteReader();
            _db.Close();
            return myReader;
        }

        private SqlDataReader getWeddingDetails(int id)
        {
            string query = @"SELECT from Wedding ";
            query += @"WHERE id=@'id'";
            _db.Open();
            SqlCommand myCommand = new SqlCommand(query, _db);
            SqlDataReader myReader = myCommand.ExecuteReader();
            _db.Close();
            return myReader;
        }

        private SqlDataReader getClientDetails(int id)
        {
            string query = @"SELECT from Client ";
            query += @"WHERE id=@'id'";
            _db.Open();
            SqlCommand myCommand = new SqlCommand(query, _db);
            SqlDataReader myReader = myCommand.ExecuteReader();
            _db.Close();
            return myReader;
        }


        /**
         *   Used for debugging purposes.
         *   TODO: DELETE AFTERWARDS!!!!
         */
        public void ShowData()
        {
            try
            {
                _db.Open();

                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Suppliers", _db);

                myReader = myCommand.ExecuteReader();

                Console.WriteLine("Cmd:  SELECT * FROM Suppliers");
                while (myReader.Read())
                {
                    Console.Write(myReader["CompanyName"].ToString());
                    Console.Write(",  ");
                    Console.Write(myReader["ContactPerson"].ToString() + "\n");
                }

                _db.Close();
            }
            catch (Exception e) { e.GetHashCode(); }

        }

        private string getClientsFullName(int id)
        {
            string query = @"SELECT firstname, surname FROM Client";
            query += @"WHERE id='@id'";
            _db.Open();
            SqlCommand myCommand = new SqlCommand(query, _db);
            SqlDataReader myReader = myCommand.ExecuteReader();
            _db.Close();
            return (myReader["firstname"].ToString() + " " + myReader["surname"].ToString());
        }

        /**
         *   Takes a string of dd/mm/yyyy and returns an
         *   int array of { dd, mm, yyyy };
         */
        public int[] splitStringDate(string d)
        {
            char[] delimChars = { '/', '\\' };
            string[] date = new string[3];
            date = d.Split(delimChars);

            int i = 0;
            int[] returnDate = new int[3];
            foreach (string s in date)
            {
                returnDate[i] = Convert.ToInt32(s);
                i++;
            }

            return returnDate;
        }

        /**
         *   Formats .NET DateTime to SQLServer friendly format
         */ 
        private string formatDateForDbInput(DateTime dt)
        {
            string format = "yyyy-MM-dd HH:MM:ss";
            string dbSafeDate = dt.ToString(format);
            return dbSafeDate;
        }
    }
}