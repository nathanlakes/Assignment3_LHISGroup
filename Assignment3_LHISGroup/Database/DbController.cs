using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Assignment3_LHISGroup.Support_Classes;
using System.Text.RegularExpressions;

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

        SqlConnection _db;   // Remove, use the using SqlConn method
        string connStr = "Data Source=(LocalDB)\\v11.0;" +
                    "AttachDbFilename=|DataDirectory|\\Database\\Model.mdf;" +
                    "Integrated Security=True";

        public DbController()
        {
            //_db = new SqlConnection(connStr);
        }

        public DbController(string myConnection)
        {
            connStr = myConnection;
            //_db = new SqlConnection(connStr);
        }

        /**
         *   Adds a given Staff Member to a task and writes to the database.
         *   Nb. Task cannot be made without it being assigned to somebody.
         *   @Param  t:  The task to add.
         */
        public bool AddTask(Support_Classes.Task t)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                // Check that staff exists in the database. Phone number used for cases where
                // Staff with the same name work together. They won't have the same phone ext. 
                // though. 
                Staff s = t.AssignedTo;
                int staffId = getStaffId(s);
                if (staffId == -1) throw new Exception("Staff must exist in Table \'Staff\', before being assigned to a task:");

                
                String query = @"INSERT INTO Task (name, description, priority, completeByDate, ";
                query += "actualCompletionDate, staffOnJob_FK, weddingID_FK)";
                query += @" VALUES(@taskname, @description, @priority, @completeByDate, @actualComplete,";
                query += @" @staffOnJob, @weddingID);";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@taskname", t.TaskName);
                myCommand.Parameters.AddWithValue("@description", t.Description);
                myCommand.Parameters.AddWithValue("@priority", t.TaskPriority.ToString());
                myCommand.Parameters.AddWithValue("@completeByDate", formatDateForDbInput(t.CompleteBy));                
                myCommand.Parameters.AddWithValue("@actualComplete", formatDateForDbInput(t.CompletionDate) );
                myCommand.Parameters.AddWithValue("@staffOnJob", staffId);

                int weddId = getWeddingId( t.Wedding );
                if (weddId == -1) throw new Exception("Task must be associated to an existing Wedding.");
                myCommand.Parameters.AddWithValue("@weddingID", weddId);

                myCommand.ExecuteNonQuery();

                _db.Close();
            }

            return true;
        }


        /**
        *   Updates an existing task with the new values provided.
        *   @Param  id: the primary key of the task to change
        *   @Param  t : the new task object with updated values
        */
        public bool UpdateTask(int id, Support_Classes.Task t)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                int staffID = getStaffId(t.AssignedTo);
                int weddId = getWeddingId(t.Wedding);

                string query = @"UPDATE Task ";
                query += @"SET name=@name, description =@description, priority=@priority, ";
                query += @"completeByDate=@completeByDate, actualCompletionDate=@actualCompDate, ";
                query += @"staffOnJob_FK=@staffOnJob, weddingID_FK=@weddId ";
                query += @"WHERE id=@id;";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@name", t.TaskName);
                myCommand.Parameters.AddWithValue("@description", t.Description);
                myCommand.Parameters.AddWithValue("@priority", t.TaskPriority);
                myCommand.Parameters.AddWithValue("@completeByDate", t.CompleteBy.ToShortDateString());
                
                try
                {
                    string date = t.CompletionDate.Value.ToShortDateString();
                    myCommand.Parameters.AddWithValue("@actualCompDate", formatDateForDbInput(date));
                }
                catch (Exception)
                {
                    myCommand.Parameters.AddWithValue("@actualCompDate", null);
                }

                myCommand.Parameters.AddWithValue("@staffOnJob", staffID);
                myCommand.Parameters.AddWithValue("@weddId", weddId);

                myCommand.Parameters.AddWithValue("@id", id);

                _db.Open();

                myCommand.ExecuteNonQuery();

                _db.Close();
            }
            return true;
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

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                String query = "UPDATE Task SET staffOnJob_FK=@staffId WHERE Id=@taskId;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@staffId", staffId);
                myCommand.Parameters.AddWithValue("@taskId", taskId);

                _db.Open();
                myCommand.ExecuteNonQuery();
                _db.Close();
            }
            return true;
        }

        /**
         *   Removes a Task from the database.
         *   @Param  id: the primary key of the task
         */
        public bool DeleteTask(int id)
        {
            int res = 0;

            this.openDb();

            String query = "DELETE FROM Task WHERE Id=@idnum;";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@idnum", id);

            res = myCommand.ExecuteNonQuery();

            this.closeDb();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Finds a task for a given ID number.
         *   Returns a Task Object.
         */
        public Support_Classes.Task FindTask(int id)
        {
            Support_Classes.Task t = new Support_Classes.Task();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();
                
                string query = @"SELECT * from Task ";
                query += @"WHERE Id=@id;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);

                using (SqlDataReader taskReader = myCommand.ExecuteReader())
                {
                    while (taskReader.Read())
                    {
                        string taskname = taskReader["name"].ToString();
                        string descr = taskReader["description"].ToString();
                        string pr = taskReader["priority"].ToString();

                        // Assign Priority
                        Support_Classes.Task.Priority prior = Support_Classes.Task.Priority.low;
                        if (pr == Support_Classes.Task.Priority.med.ToString())
                        {
                            prior = Support_Classes.Task.Priority.med;
                        }
                        else
                        {
                            prior = Support_Classes.Task.Priority.high;
                        }

                        // Assign Deadline Date
                        string temp = taskReader["completeByDate"].ToString();
                        int[] date = splitStringDate(temp);
                        DateTime completeBy = new DateTime(date[2], date[1], date[0]);

                        //
                        // Create Wedding Planner
                        //
                        int staffId = Convert.ToInt32(taskReader["staffOnJob_FK"].ToString());
                        Staff weddingPlanner = getStaffDetails(staffId);

                        //
                        // Create Wedding
                        //
                        int weddId = Convert.ToInt32(taskReader["weddingID_FK"].ToString());
                        Wedding wedding = getWeddingDetails(weddId);

                        //
                        //  Make Actual Task
                        //
                        t = new Support_Classes.Task(
                            taskname, descr, prior, completeBy, weddingPlanner, wedding);

                        try
                        {
                            t.ID = Convert.ToInt32(taskReader["Id"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        // Assign Completion Date, if not null
                        // TODO:  Fix write/read of DateTime.MinValue
                        string acd = taskReader["actualCompletionDate"].ToString();

                        temp = taskReader["actualCompletionDate"].ToString();
                        date = splitStringDate(temp);
                        DateTime actComp = new DateTime(date[2], date[1], date[0]);
                        if ( DateTime.Compare(actComp, DateTime.MinValue) != 0 )
                        {      
                            t.CompletionDate = actComp;
                        }
                    }
                }
                _db.Close();
            }
            return t;
        }


        /**
         *   Find Task Based on Composite Key of Supplied Information.
         *   TODO: Possible Error with DateTime / Date including Time in comparison.
         *   Want to compare dates only. 
         */
        public Support_Classes.Task FindTask(Support_Classes.Task task)
        {
            Support_Classes.Task t = new Support_Classes.Task();

            using(SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT * FROM Task ";
                query += @"WHERE name=@name AND completeByDate=@completeByDate AND staffOnJob_FK=@staffOnJob;";
                SqlCommand myCommand = new SqlCommand(query, _db);

                myCommand.Parameters.AddWithValue("@name", task.TaskName);
                myCommand.Parameters.AddWithValue("@completeByDate", formatDateForDbInput(task.CompleteBy));

                int staffID = getStaffId(task.AssignedTo);
                if (staffID == -1) throw new Exception("Staff Member Not Found in Staff Table");
                myCommand.Parameters.AddWithValue("@staffOnJob", staffID);


                using (SqlDataReader taskReader = myCommand.ExecuteReader())
                {
                    while (taskReader.Read())
                    {
                        string taskname = taskReader["name"].ToString();
                        string descr = taskReader["description"].ToString();
                        string pr = taskReader["priority"].ToString();

                        // Assign Priority
                        Support_Classes.Task.Priority prior = Support_Classes.Task.Priority.low;
                        if (pr == Support_Classes.Task.Priority.med.ToString())
                        {
                            prior = Support_Classes.Task.Priority.med;
                        }
                        else
                        {
                            prior = Support_Classes.Task.Priority.high;
                        }

                        // Assign Deadline Date
                        string temp = taskReader["completeBy"].ToString();
                        int[] date = splitStringDate(temp);
                        DateTime completeBy = new DateTime(date[2], date[1], date[0]);

                        //
                        // Create Wedding Planner
                        //
                        int staffId = Convert.ToInt32(taskReader["staffOnJob_FK"].ToString());
                        Staff weddingPlanner = getStaffDetails(staffId);


                        //
                        // Create Wedding
                        //
                        int weddId = Convert.ToInt32(taskReader["weddingID_FK"].ToString());
                        Wedding wedding = getWeddingDetails(weddId);


                        //
                        //  Make Actual Task
                        //
                        t = new Support_Classes.Task(
                            taskname, descr, prior, completeBy, weddingPlanner, wedding);

                        try
                        {
                            t.ID = Convert.ToInt32(taskReader["Id"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        // Assign Completion Date, if not null
                        string actComp = taskReader["actualCompletionDate"].ToString();

                        if (!(actComp == null) || !(actComp == ""))
                        {
                            temp = taskReader["actualCompletionDate"].ToString();
                            date = splitStringDate(temp);
                            t.CompletionDate = new DateTime(date[0], date[1], date[2]);
                        }
                    }
                }
                _db.Close();
            }                
            return t;
        }


        /**
         *   Adds a client to the database.
         *   @Param  c: the client to add.
         */
        public bool AddClient(Client c)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                String query = @"INSERT into Client (firstname, surname, contactPerson, address, ";
                query += @"mobile, homePhone, email, engagedTo_firstname, engagedTo_surname)";
                query += @" VALUES (@firstname, @surname, @contactPerson, @address, @mobile, @homePhone, ";
                query += @"@email, @engFn, @engSn);";

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

                myCommand.ExecuteNonQuery();

                _db.Close();
            }
            return true;
        }

        /**
         *   Updates an existing client with the values provided
         *   @Param  id: the Client to update
         *   @Param  c : the new details of client with the given id number
         */
        public bool UpdateClient(int id, Client c)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                
                string query = @"UPDATE Client ";
                query += @"SET firstname=@firstname, surname=@surname, contactPerson=@contactPerson, ";
                query += @"address=@address, mobile=@mobile, homePhone=@homePhone, email=@email, ";
                query += @"engagedTo_firstname=@engFn, engagedTo_surname=@engSn ";
                query += @"WHERE Id=@id;";

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

                _db.Open();
                myCommand.ExecuteNonQuery();
                _db.Close();
            }
            return true;
        }

        /**
         *   Deletes a client from the database
         *   @Param  id:  the client to delete
         */
        public bool DeleteClient(int id)
        {
            string query = @"DELETE FROM Client ";
            query += @"WHERE Id=@id;";
            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            this.openDb();
            res = myCommand.ExecuteNonQuery();
            this.closeDb();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Finds a client matching the given ID.
         *   Returns a single client object.
         */
        public Client FindClient(int id)
        {
            Client c = getClientsDetails(id);
            return c;
        }

        /**
         *   Given partial information of a client
         *   finds a match. Uses unique composite key rather than
         *   primary key for matching.
         */
        public Client FindClient(Client c)
        {
            int id = getClientId(c);
            Client returnClient = getClientsDetails( id );
            return returnClient;
        }

        /**
         *   Finds clients matching the pattern of s
         *   @Param name:  the partial firstname or surname to search for.
         */
        public List<Client> FindClients(string name)
        {
            List<Client> returnList = new List<Client>();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();
                string query = "SELECT * FROM Client WHERE firstname LIKE @fn OR surname LIKE @fn ";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@fn", "%" + name + "%");
                
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    Client client = new Client();
                    while (myReader.Read())
                    {
                        client = getClientsDetails(Convert.ToInt32(myReader["Id"].ToString()));
                        returnList.Add(client);
                    }
                }
                _db.Close();
            }

            return returnList;

        }

        /**
         *   Adds a Wedding to the database
         *   @Param  w: The Wedding to add
         */
        public bool AddWedding(Wedding w)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"INSERT into Wedding ";
                query += @"(title, client_1_FK, client_2_FK, startDate, EventDate, weddingPlanner_FK, description)";
                query += @"VALUES(@title, @client1, @client2, @startDate, @eventDate, @weddingPlanner, @desc);";

                SqlCommand myCommand = new SqlCommand(query, _db);

                myCommand.Parameters.AddWithValue("@title", w.Title);
                myCommand.Parameters.AddWithValue("@desc", w.Description);

                //
                //  Get Client FK details
                // 
                int clientOneFk;
                int clientTwoFk;

                clientOneFk = getClientId(w.Client1);
                if (clientOneFk == -1) throw new Exception("Client must be in database before adding wedding.");

                clientTwoFk = getClientId(w.Client2);
                if (clientTwoFk == -1) throw new Exception("Client must be in database before adding wedding.");

                myCommand.Parameters.AddWithValue("@client1", clientOneFk);
                myCommand.Parameters.AddWithValue("@client2", clientTwoFk);
                myCommand.Parameters.AddWithValue("@startDate", formatDateForDbInput(w.StartDate));
                myCommand.Parameters.AddWithValue("@eventDate", formatDateForDbInput(w.EventDate));

                int wedPlanner = getStaffId(w.WeddingPlanner);
                if (wedPlanner == -1) throw new Exception("Wedding Planner must exist in Staff Table.");
                myCommand.Parameters.AddWithValue("@weddingPlanner", wedPlanner);

                myCommand.ExecuteNonQuery();

                _db.Close();
            }

            return true;
        }

        /**
         *   Updates an existing wedding with new details
         *   @Param  id: The Wedding to update
         *   @Param   w: The new details of the wedding
         */
        public bool UpdateWedding(int id, Wedding w)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                string query = @"UPDATE Wedding ";
                query += @"SET title=@title, description=@desc, client_1_FK=@client1, client_2_FK=@client2, ";
                query += @"startDate=@startDate, eventDate=@eventDate, weddingPlanner_FK=@weddingPlanner_FK ";
                query += @"WHERE Id=@id;";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@title", w.Title);
                myCommand.Parameters.AddWithValue("@desc", w.Description);
                myCommand.Parameters.AddWithValue("@client1", getClientId(w.Client1));
                myCommand.Parameters.AddWithValue("@client2", getClientId(w.Client2));
                myCommand.Parameters.AddWithValue("@startDate", formatDateForDbInput(w.StartDate) );
                myCommand.Parameters.AddWithValue("@eventDate", formatDateForDbInput(w.EventDate) );
                myCommand.Parameters.AddWithValue("@weddingPlanner_FK", getStaffId(w.WeddingPlanner));
                myCommand.Parameters.AddWithValue("@id", id);

                _db.Open();
                myCommand.ExecuteNonQuery();
                _db.Close();
            }

            return true;            
        }

        /**
         *   Deletes a Wedding from the database
         *   @Param  id: The wedding to remove
         */
        public bool DeleteWedding(int id)
        {
            string query = @"DELETE FROM Wedding ";
            query += @"WHERE Id=@id;";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            this.openDb();
            res = myCommand.ExecuteNonQuery();
            this.closeDb();

            if (res == 1) return true;
            return false;
        }

        /**
         *   Finds a specific Wedding matching the supplied Primary Key.
         */
        public Wedding FindWedding(int id)
        {
            Wedding wed = new Wedding();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Wedding ";
                query += "WHERE Id=@id;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);
                
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        string weddTitle = myReader["title"].ToString();
                        string desc = myReader["description"].ToString();

                        //
                        // Create Client Objects
                        //
                        // Client 1               
                        Client client1 = getClientsDetails(Convert.ToInt32(myReader["client_1_FK"].ToString()));


                        // Client 2
                        Client client2 = getClientsDetails(Convert.ToInt32(myReader["client_2_FK"].ToString()));

                        // Generate DateTime for start date.
                        string temp = myReader["startDate"].ToString();
                        int[] dateArray = splitStringDate(temp);
                        DateTime startDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                        // Generate DateTime for event date.
                        temp = myReader["eventDate"].ToString();
                        dateArray = splitStringDate(temp);
                        DateTime eventDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                        // Create Staff Object
                        int wedPlanId = Convert.ToInt32(myReader["weddingPlanner_FK"].ToString());
                        Staff weddPlann = getStaffDetails(wedPlanId);


                        wed = new Wedding(weddTitle, desc, client1, client2, weddPlann, startDate, eventDate);

                        try
                        {
                            wed.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                _db.Close();
            }

            return wed;
        }

        /**
         *   Finds a specific Wedding using a composite key of Wedding
         *   attributes.
         *   TODO: Debug possible error where Date Writes to DB include time. 
         *   Need to compare date with date only.
         */
        public Wedding FindWedding(Wedding w)
        {
            Wedding wed = new Wedding();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Wedding ";
                query += "WHERE title=@title AND description=@description AND startDate=@startdate";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@title", w.Title);
                myCommand.Parameters.AddWithValue("@description", w.Description);
                myCommand.Parameters.AddWithValue("@startdate", formatDateForDbInput(w.StartDate));


                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        string weddTitle = myReader["title"].ToString();
                        string desc = myReader["description"].ToString();

                        //
                        // Create Client Objects
                        //
                        // Client 1               
                        Client client1 = getClientsDetails(Convert.ToInt32(myReader["client_1_FK"].ToString()));


                        // Client 2
                        Client client2 = getClientsDetails(Convert.ToInt32(myReader["client_2_FK"].ToString()));


                        // Generate DateTime for start date.
                        string temp = myReader["startDate"].ToString();
                        int[] dateArray = splitStringDate(temp);
                        DateTime startDate = new DateTime(dateArray[2], dateArray[1], dateArray[0]);

                        // Generate DateTime for event date.
                        temp = myReader["eventDate"].ToString();
                        dateArray = splitStringDate(temp);
                        DateTime eventDate = new DateTime(dateArray[2], dateArray[1], dateArray[0]);

                        // Create Staff Object
                        int staffId = Convert.ToInt32(myReader["weddingPlanner_FK"].ToString());
                        Staff weddPlann = getStaffDetails(staffId);

                        wed = new Wedding(weddTitle, desc, client1, client2, weddPlann, startDate, eventDate);

                        try
                        {
                            wed.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }                   
                }
                _db.Close();
            }
            return wed;
        }

        /**
         *   Finds all weddings matching a given title
         *   @Param  title: the wedding title to find matches.
         *   returns:  a list of all weddings that have a similar title.
         */
        public List<Wedding> FindWedding(string title)
        {
            List<Wedding> returnList = new List<Wedding>();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Wedding";
                query += " WHERE title LIKE @title;";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@title", "%" + title + "%");

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        Wedding w = new Wedding();
                        {
                            string weddTitle = myReader["title"].ToString();
                            string desc = myReader["description"].ToString();

                            //
                            // Create Client Objects
                            //
                            // Client 1               
                            Client client1 = getClientsDetails(Convert.ToInt32(myReader["client_1_FK"].ToString()));


                            // Client 2
                            Client client2 = getClientsDetails(Convert.ToInt32(myReader["client_2_FK"].ToString()));


                            // Generate DateTime for start date.
                            string temp = myReader["startDate"].ToString();
                            int[] dateArray = splitStringDate(temp);
                            DateTime startDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                            // Generate DateTime for event date.
                            temp = myReader["eventDate"].ToString();
                            dateArray = splitStringDate(temp);
                            DateTime eventDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                            // Create Staff Object
                            int stfId = Convert.ToInt32(myReader["weddingPlanner_FK"].ToString());
                            Staff weddPlann = getStaffDetails(stfId);

                            w = new Wedding(weddTitle, desc, client1, client2, weddPlann, startDate, eventDate);

                            try
                            {
                                w.ID = Convert.ToInt32(myReader["Id"].ToString());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        returnList.Add(w);
                    }
                }
                _db.Close();
            }
            return returnList;
        }

        /**
         *   Adds a supplier to the database
         *   @Param  s: The supplier to add.
         */
        public bool AddSupplier(Supplier s)
        {

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                String query = @"INSERT into Suppliers (CompanyName, Address, ContactPerson, Email, PhoneNumber, CreditTerms)";
                query += @" VALUES (@companyName, @address, @contactPerson, @email, @phonenumber, @creditterms);";

                SqlCommand myCommand = new SqlCommand(query, _db);

                myCommand.Parameters.AddWithValue("@companyName", s.CompanyName);
                myCommand.Parameters.AddWithValue("@address", s.Address);
                myCommand.Parameters.AddWithValue("@contactPerson", s.ContactPerson);
                myCommand.Parameters.AddWithValue("@email", s.Email);
                myCommand.Parameters.AddWithValue("@phonenumber", s.PhoneNumber);
                myCommand.Parameters.AddWithValue("@creditterms", s.CreditTerms);

                myCommand.ExecuteNonQuery();   // Run the statement.
                _db.Close();
            }
            return true;
        }

        /**
         *   Deletes a supplier from the database
         *   @Param  id: The supplier to remove.
         */
        public bool DeleteSupplier(int id)
        {
            string query = @"DELETE Suppliers ";   // RM 'FROM' keyword????
            query += "WHERE Id=@id;";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            this.openDb();
            res = myCommand.ExecuteNonQuery();
            this.closeDb();

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

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                string query = @"UPDATE Suppliers ";
                query += @"SET CompanyName=@companyname, Address=@address, ContactPerson=@contactPerson, ";
                query += @"Email=@email, PhoneNumber=@phonenumber, CreditTerms=@creditterms ";
                query += @"WHERE Id=@id;";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@companyname", s.CompanyName);
                myCommand.Parameters.AddWithValue("@address", s.Address);
                myCommand.Parameters.AddWithValue("@contactPerson", s.ContactPerson);
                myCommand.Parameters.AddWithValue("@email", s.Email);
                myCommand.Parameters.AddWithValue("@phonenumber", s.PhoneNumber);
                myCommand.Parameters.AddWithValue("@creditterms", s.CreditTerms);
                myCommand.Parameters.AddWithValue("@id", id);

                _db.Open();
                myCommand.ExecuteNonQuery();
                _db.Close();
            }                     
            return true;
        }


        /**
         *   Finds all suppliers matching the given id.
         *   @Param  name: The supplier id
         *   returns: A Supplier Object
         */
        public Supplier FindSupplier(int id)
        {
            Supplier s = new Supplier();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Suppliers ";
                query += "WHERE Id = @id;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);

                using (var myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        string coname = myReader["CompanyName"].ToString();
                        string address = myReader["Address"].ToString();
                        string contact = myReader["ContactPerson"].ToString();
                        string email = myReader["Email"].ToString();
                        string phone = myReader["PhoneNumber"].ToString();
                        int credterm = Convert.ToInt32(myReader["CreditTerms"].ToString());

                        s = new Supplier(coname, address, contact, email, phone, credterm);
                        s.ID = Convert.ToInt32(myReader["Id"].ToString());
                    }
                }
                _db.Close();
            }
            return s;
        }

        /**
         *   Finds all suppliers matching the given Supplier.
         *   @Param  s: Supplier
         *   returns: The Corresponding Supplier
         */
        public Supplier FindSupplier(Supplier find)
        {
            Supplier s = new Supplier();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Suppliers ";
                query += "WHERE CompanyName=@coname AND Email=@email";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@coname", find.CompanyName);
                myCommand.Parameters.AddWithValue("@email", find.Email);

                using (var myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        string coname = myReader["CompanyName"].ToString();
                        string address = myReader["Address"].ToString();
                        string contact = myReader["ContactPerson"].ToString();
                        string email = myReader["Email"].ToString();
                        string phone = myReader["PhoneNumber"].ToString();
                        int credterm = Convert.ToInt32(myReader["CreditTerms"].ToString());

                        s = new Supplier(coname, address, contact, email, phone, credterm);
                        s.ID = Convert.ToInt32(myReader["Id"].ToString());
                    }
                }
                _db.Close();
            }
            return s;
        }


        /**
         *   Finds all suppliers matching the given name.
         *   @Param  name: The supplier name to find matches
         *   returns: a List of all possible matches
         */
        public List<Supplier> FindSupplier(string name)
        {
            List<Supplier> returnList = new List<Supplier>();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Suppliers ";
                query += "WHERE CompanyName LIKE @name;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@name", "%" + name + "%");

                using (var myReader = myCommand.ExecuteReader() )
                {
                    Supplier s = new Supplier();
                    while (myReader.Read())
                    {
                        string coname = myReader["CompanyName"].ToString();
                        string address = myReader["Address"].ToString();
                        string contact = myReader["ContactPerson"].ToString();
                        string email = myReader["Email"].ToString();
                        string phone = myReader["PhoneNumber"].ToString();
                        int credterm = Convert.ToInt32(myReader["CreditTerms"].ToString());

                        s = new Supplier(coname, address, contact, email, phone, credterm);
                        s.ID = Convert.ToInt32(myReader["Id"].ToString());

                        returnList.Add(s);
                    }
                }
                _db.Close();
            }

            return returnList;
        }


        public bool AddStaff(Staff s)
        {
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();
                String query = @"INSERT into Staff (firstname, surname, email, phone, notes, status)";
                query += @" VALUES (@_firstname, @_surname, @_email, @_phone, @_notes, @_status);";

                SqlCommand myCommand = new SqlCommand(query, _db);

                myCommand.Parameters.AddWithValue("@_firstname", s.FirstName);
                myCommand.Parameters.AddWithValue("@_surname", s.Surname);
                myCommand.Parameters.AddWithValue("@_email", s.Email);
                myCommand.Parameters.AddWithValue("@_phone", s.Phone);
                myCommand.Parameters.AddWithValue("@_notes", s.Notes);
                myCommand.Parameters.AddWithValue("@_status", s.StatusToString());

                myCommand.ExecuteNonQuery();   // Run the statement.

                _db.Close();
            }

            return true;
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
            query += @"WHERE Id=@id;";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@firstname", s.FirstName);
            myCommand.Parameters.AddWithValue("@surname", s.Surname);
            myCommand.Parameters.AddWithValue("@email", s.Email);
            myCommand.Parameters.AddWithValue("@phone", s.Phone);
            myCommand.Parameters.AddWithValue("@notes", s.Notes);
            myCommand.Parameters.AddWithValue("@status", s.StatusToString());
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            this.openDb();
            res = myCommand.ExecuteNonQuery();
            this.closeDb();

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
            query += @"WHERE Id=@id;";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@status", a);
            myCommand.Parameters.AddWithValue("@id", id);

            int res = 0;
            this.openDb();
            res = myCommand.ExecuteNonQuery();
            this.closeDb();

            if (res == 1) return true;
            return false;
        }


        /**
         *   Finds Staff based on primary key
         */
        public Staff FindStaff(int id)
        {
            Staff s = new Staff();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = "SELECT * FROM Staff WHERE Id=@id;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
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

                        s = new Staff(firstname, surname, email, phone, notes, stat);
                        try
                        {
                            s.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
                _db.Close();
            }
            return s;
        }

        /**
         *   Finds Staff based on composite key of
         *   firstname, surname and email
         */
        public Staff FindStaff(Staff s)
        {
            Staff returnStaff = new Staff();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT * FROM Staff ";
                query += @"WHERE firstname=@firstname AND surname=@surname;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@firstname", s.FirstName);
                myCommand.Parameters.AddWithValue("@surname", s.Surname);
                
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        returnStaff = getStaffDetails(Convert.ToInt32(myReader["Id"].ToString()));
                    }
                }

                _db.Close();
            }
            return returnStaff;
              
        }


        /**
         *   Returns a List<Staff> who are currently
         *   active.
         */
        public List<Staff> AllActiveStaff()
        {
            List<Staff> returnList = new List<Staff>();

            using(SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT * FROM Staff WHERE status='active';";
                SqlCommand myCommand = new SqlCommand(query, _db);

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
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
                        try
                        {
                            s.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                        returnList.Add(s);
                    }
                }
                _db.Close();
            }
            return returnList;
        }


        /**
         *   Returns a list of all clients
         */
        public List<Client> GetAllClients()
        {
            List<Client> returnList = new List<Client>();
            
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                SqlCommand myCommand = new SqlCommand("SELECT * FROM Client;", _db);

                using (var myReader = myCommand.ExecuteReader() )
                {
                    Client c = new Client();

                    while (myReader.Read())
                    {
                        c = new Client(
                            myReader["firstname"].ToString(),
                            myReader["surname"].ToString(),
                            myReader["contactPerson"].ToString(),
                            myReader["address"].ToString(),
                            myReader["mobile"].ToString(),
                            myReader["homePhone"].ToString(),
                            myReader["email"].ToString(),
                            myReader["engagedTo_firstname"].ToString(),
                            myReader["engagedTo_surname"].ToString()
                        );

                        try
                        {
                            c.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        returnList.Add(c);
                
                    }                         
                }

                _db.Close();

            }
            
            return returnList;
        }

        /**
         *   Returns a list of all staff
         */
        public List<Staff> GetAllStaff()
        {
            List<Staff> returnList = new List<Staff>();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Staff;", _db);

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
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
                        try
                        {
                            s.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }

                        returnList.Add(s);
                    }
                }
                _db.Close();
            }

            return returnList;
        }

        /**
         *   Returns a list of all suppliers
         */
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> returnList = new List<Supplier>();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                SqlCommand myCommand = new SqlCommand("SELECT * FROM Suppliers;", _db);

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
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
                }
            }
            return returnList;
        }

        /**
         *   Returns a list of all tasks
         */
        public List<Support_Classes.Task> GetAllTasks()
        {
            
            List<Support_Classes.Task> returnList = new List<Support_Classes.Task>();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                SqlCommand myCommand = new SqlCommand("SELECT * FROM Task;", _db);
                using (SqlDataReader taskReader = myCommand.ExecuteReader())
                {
                    while (taskReader.Read())
                    {
                        string taskname = taskReader["name"].ToString();
                        string descr = taskReader["description"].ToString();

                        // Assign Task Priority
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

                        // Assign Task Completion Date
                        string st = taskReader["completeByDate"].ToString();
                        int[] temp = splitStringDate(taskReader["completeByDate"].ToString());
                        DateTime completeBy = new DateTime(temp[2], temp[1], temp[0]);

                        //
                        // Generate Staff Object tied to the Task
                        //
                        int index = Convert.ToInt32(taskReader["staffOnJob_FK"].ToString());
                        Staff staff = getStaffDetails(index);

                        //
                        // Generate Wedding Object tied to Task
                        //    
                        int wedIndex = Convert.ToInt32(taskReader["weddingID_FK"].ToString());
                        Wedding wedding = getWeddingDetails(wedIndex);


                        // Make the Task Object now all components needed exist. 
                        Support_Classes.Task t = new Support_Classes.Task(taskname, descr, priority, completeBy,
                            staff, wedding);

                        // Assign Actual Complete Date, if any.
                        try
                        {
                            temp = splitStringDate(taskReader["completeByDate"].ToString());
                            completeBy = new DateTime(temp[2], temp[1], temp[0]);
                            t.CompleteBy = completeBy;
                        }
                        catch (Exception) { }

                        t.ID = Convert.ToInt32(taskReader["Id"].ToString());  // Attach PK

                        returnList.Add(t);
                    }
                }
                _db.Close();
            }
            return returnList;
        }

        /**
         *   Returns a list of all weddings
         */
        public List<Wedding> GetAllWeddings()
        {
            List<Wedding> returnList = new List<Wedding>();

            using(SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Wedding;", _db);

                using(SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        Wedding w = new Wedding();
                        {
                            string weddTitle = myReader["title"].ToString();
                            string desc = myReader["description"].ToString();

                            //
                            // Create Client Objects
                            //
                            // Client 1               
                            Client client1 = getClientsDetails(Convert.ToInt32(myReader["client_1_FK"].ToString()));


                            // Client 2
                            Client client2 = getClientsDetails(Convert.ToInt32(myReader["client_2_FK"].ToString()));


                            // Generate DateTime for start date.
                            string temp = myReader["startDate"].ToString();
                            int[] dateArray = splitStringDate(temp);
                            DateTime startDate = new DateTime(dateArray[2], dateArray[1], dateArray[0]);

                            // Generate DateTime for event date.
                            temp = myReader["eventDate"].ToString();
                            dateArray = splitStringDate(temp);
                            DateTime eventDate = new DateTime(dateArray[2], dateArray[1], dateArray[0]);

                            // Create Staff Object
                            int index = Convert.ToInt32(myReader["weddingPlanner_FK"].ToString());
                            Staff weddPlann = getStaffDetails(index);


                            w = new Wedding(weddTitle, desc, client1, client2, weddPlann, startDate, eventDate);

                            try
                            {
                                w.ID = Convert.ToInt32(myReader["Id"].ToString());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                        returnList.Add(w);
                    }
                }
                _db.Close();
            }
            return returnList;
        }



        //\\//\\//\\//\\//\\//\\//\\//\\
        //   PRIVATE HELPER METHODS   \\
        //\\//\\//\\//\\//\\//\\//\\//\\

        /**
         *   Checks the Staff table and returns the staff ID number if they exist.
         *   Returns -1 if the staff member does not exist.
         */
        public int getStaffId(Staff s)
        {
            int id = -1;

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT id FROM Staff WHERE firstname=@firstname AND surname=@surname";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@firstname", s.FirstName);
                myCommand.Parameters.AddWithValue("@surname", s.Surname);


                using (var myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        id = Convert.ToInt32(myReader["Id"].ToString());
                    }
                }

                _db.Close();
            }            
            
            return id;
        }

        /**
         *   Checks the Supplier table and returns the Supplier ID number if they exist.
         *   Returns -1 if the staff member does not exist.
         */
        public int getSupplierId(Supplier s)
        {
            int id = -1;

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT id FROM Suppliers WHERE CompanyName=@coname AND Email=@email";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@coname", s.CompanyName);
                myCommand.Parameters.AddWithValue("@email", s.Email);


                using (var myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        id = Convert.ToInt32(myReader["Id"].ToString());
                    }
                }

                _db.Close();
            }

            return id;
        }


        /**
         *   Checks the Task table and returns the Task Id number if it exists.
         *   Returns -1 if the Task does not exist.
         */
        public int getTaskId(Support_Classes.Task t)
        {
            int id = -1;

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                SqlCommand testTask = new SqlCommand(
               "SELECT Id FROM Task WHERE name = '" + t.TaskName +
                    "' AND description = '" + t.Description + "'", _db);

                using (var myReader = testTask.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        try
                        {
                            id = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
                _db.Close();
            }
            return id;            
        }   

        /**
         *   Checks the Client table and returns the Client ID number if it exists.
         *   Returns -1 if the Client does not exsit
         */
        public int getClientId(Client c)
        {
            int id = -1;

            using(SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();
                
                string query = @"SELECT id FROM Client ";
                query += "WHERE firstname=@firstname AND surname=@surname;";

                SqlCommand myCommand = new SqlCommand(query, _db);

                myCommand.Parameters.AddWithValue("@firstname", c.Firstname);
                myCommand.Parameters.AddWithValue("@surname", c.Surname);

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        try
                        {
                            id = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show("getClientId(Client) >> " + e.ToString());
                        }
                    }
                }

            }
            
            
            return id;
        }

        
        public int getWeddingId(Wedding w)
        {
            int id = -1;
            
            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT Id FROM Wedding WHERE title=@title AND (";
                query += @"(client_1_FK=@client1 OR client_2_FK=@client1) OR ";
                query += @"(client_1_FK=@client2 OR client_2_FK=@client2) )";
                
                SqlCommand testTask = new SqlCommand(query, _db);
                testTask.Parameters.AddWithValue("@title", w.Title);
                testTask.Parameters.AddWithValue("@client1", getClientId(w.Client1));
                testTask.Parameters.AddWithValue("@client2", getClientId(w.Client2));

                using ( SqlDataReader myReader = testTask.ExecuteReader() )
                {
                    while (myReader.Read())
                    {
                        try
                        {
                            id = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }                
                }
                _db.Close();
            }
            return id;
        }


        private Staff getStaffDetails(int id)
        {
            Staff s = new Staff();

            using (SqlConnection _db = new SqlConnection(connStr) )
            {
                _db.Open();

                string query = @"SELECT * from Staff ";
                query += @"WHERE Id=@id;";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);

                using (SqlDataReader staffReader = myCommand.ExecuteReader())
                {
                    while (staffReader.Read())
                    {
                        string firstname = staffReader["firstname"].ToString();
                        string surname = staffReader["surname"].ToString();
                        string email = staffReader["email"].ToString();
                        string phone = staffReader["phone"].ToString();
                        string notes = staffReader["notes"].ToString();
                        string status = staffReader["status"].ToString();

                        Staff.Active stat = Staff.Active.inactive;
                        if (Staff.Active.active.ToString() == status)
                        {
                            stat = Staff.Active.active;
                        }

                        s = new Staff(firstname, surname, email, phone, notes, stat);
                        s.ID = Convert.ToInt32(staffReader["Id"].ToString());
                    }
                    _db.Close();
                }

            }
            return s;
        }


        private Client getClientsDetails(int id)
        {
            Client c = new Client();

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT * from Client ";
                query += @"WHERE Id=@id;";

                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);

                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        c = new Client(
                                myReader["firstname"].ToString(),
                                myReader["surname"].ToString(),
                                myReader["contactPerson"].ToString(),
                                myReader["address"].ToString(),
                                myReader["mobile"].ToString(),
                                myReader["homePhone"].ToString(),
                                myReader["email"].ToString(),
                                myReader["engagedTo_firstname"].ToString(),
                                myReader["engagedTo_surname"].ToString()
                        );

                        try
                        {
                            c.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
                _db.Close();
            }

            return c;   
        }

        private Wedding getWeddingDetails(int id)
        {
            Wedding w = new Wedding();

            using(SqlConnection _db = new SqlConnection(connStr))
            {
                _db.Open();

                string query = @"SELECT * from Wedding ";
                query += @"WHERE Id=@id;";
                SqlCommand myCommand = new SqlCommand(query, _db);
                myCommand.Parameters.AddWithValue("@id", id);
                
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        string weddTitle = myReader["title"].ToString();
                        string desc = myReader["description"].ToString();

                        //
                        // Create Client Objects
                        //
                        // Client 1               
                        Client client1 = getClientsDetails(Convert.ToInt32(myReader["client_1_FK"].ToString()));


                        // Client 2
                        Client client2 = getClientsDetails(Convert.ToInt32(myReader["client_2_FK"].ToString()));


                        // Generate DateTime for start date.
                        string temp = myReader["startDate"].ToString();
                        int[] dateArray = splitStringDate(temp);
                        DateTime startDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                        // Generate DateTime for event date.
                        temp = myReader["eventDate"].ToString();
                        dateArray = splitStringDate(temp);
                        DateTime eventDate = new DateTime(dateArray[0], dateArray[1], dateArray[2]);

                        // Create Staff Object
                        int index = Convert.ToInt32(myReader["weddingPlanner_FK"].ToString());
                        Staff weddPlann = getStaffDetails(index);

                        w = new Wedding(weddTitle, desc, client1, client2, weddPlann, startDate, eventDate);

                        try
                        {
                            w.ID = Convert.ToInt32(myReader["Id"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                _db.Close();
            }
            return w;
        }



        private string getClientsFullName(int id)
        {
            string query = @"SELECT firstname, surname FROM Client ";
            query += @"WHERE Id=@id;";
            this.openDb();
            SqlCommand myCommand = new SqlCommand(query, _db);

            string returnString = "";
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                returnString = myReader["firstname"].ToString() + " " + myReader["surname"].ToString();
            }
            this.closeDb();
            return returnString;
        }

        /**
         *   Takes a string of dd/mm/yyyy and returns an
         *   int array of { dd, mm, yyyy };
         */
        public int[] splitStringDate(string d)
        {
            string trimDate = Regex.Match(d, "^[^ ]+").Value;
            char[] delimChars = { '/', '\\', };
            string[] date = new string[2];

            date = trimDate.Split(delimChars);

            int i = 0;
            int[] returnDate = new int[5];
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
            return dt.ToString(format);
        }

        private string formatDateForDbInput(Nullable<DateTime> dt)
        {
            if (dt != null)
            {
                DateTime temp = new DateTime(dt.Value.Year, dt.Value.Month, dt.Value.Day);
                string format = "yyyy-MM-dd HH:MM:ss";
                return temp.ToString(format);;
            }
            return null;
            
        }

        private string formatDateForDbInput(string date)
        {
            int[] temp = splitStringDate(date);
            DateTime dt = new DateTime(temp[0], temp[1], temp[2]);
            string format = "yyyy-MM-dd HH:MM:ss";
            return dt.ToString(format);
        }

        /**
         *   Takes a string of the format dd/mm/YYYY
         *   and returns a DateTime object
         */
        public DateTime convertStringToDateTime(string date)
        {
            int[] temp = splitStringDate(date);
            return new DateTime(temp[0], temp[1], temp[2]);
        }


        /**                                                             
         *   Opens a connection to Database. 
         *   Throws Exceptions when open is called on an already open
         *   SqlConnection or when transaction errors occur.
         */
        private void openDb()
        {
            try
            {
                _db.Open();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The Database is already open.");
            }
            catch (SqlException)
            {
                throw new Exception("An error occurred whilst connecting with the database;");
            }
        }

        /**
         *   Closes a connection to Database. 
         *   Throws Exception when transaction errors occur.
         */
        private void closeDb()
        {
            try
            {
                _db.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}