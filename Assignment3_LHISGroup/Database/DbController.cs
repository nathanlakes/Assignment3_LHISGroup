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
     *   The controller for the SQL Database model. 
     *   All views interface with Database.cs and read
     *   write via this class
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
            String query = @"INSERT INTO Task(name,description,priority,completeByDate, staffOnJob_FK) ";
            query += @" VALUES( @taskname, @description, @priority, @completeByDate, @staffOnJob)";

            SqlCommand myCommand = new SqlCommand(query, _db);
            myCommand.Parameters.AddWithValue("@taskname", t.TaskName);
            myCommand.Parameters.AddWithValue("@description", t.Description);
            myCommand.Parameters.AddWithValue("@priority", t.TaskPriority);
            myCommand.Parameters.AddWithValue("@completeByDate", t.CompleteBy.ToShortDateString() );
            myCommand.Parameters.AddWithValue("@staffOnJob", staffId.ToString() );

            res = myCommand.ExecuteNonQuery();
                
            _db.Close();
            
            
            if (res == 1) return true;  //Should only update one row
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
            res = myCommand.ExecuteNonQuery();  // Run the statement.
            _db.Close();
            
            if (res == 1) return true;  // Should only update one row.
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
            res = myCommand.ExecuteNonQuery();  // Run the statement.
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
            int staffID = getStaffId( t.AssignedTo );
            
            string query = @"UPDATE Task";
            query +=       @"SET name='@name', description ='@description', priority='@priority', ";
            query +=       @"completeByDate='@completeByDate', actualCompletionDate='@actualCompDate,";
            query +=       @"staffOnJob_FK='@staffOnJob";
            query +=       @"WHERE id=@id";

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
            int res = myCommand.ExecuteNonQuery();  // Run the statement.
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
            query += @"mobile, homePhone, email, engagedTo)";
            query += @" VALUES (@firstname, @surname, @contactPerson, @address, @mobile, @homePhone, @email, @engagedTo)";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@firstname", c.Firstname );
            myCommand.Parameters.AddWithValue("@surname", c.Surname);
            myCommand.Parameters.AddWithValue("@contactPerson", c.ContactPerson);
            myCommand.Parameters.AddWithValue("@address", c.Address);
            myCommand.Parameters.AddWithValue("@mobile", c.Mobile);
            myCommand.Parameters.AddWithValue("@homePhone", c.HomePhone);
            myCommand.Parameters.AddWithValue("@email", c.Email);
            myCommand.Parameters.AddWithValue("@engagedTo", c.EngagedTo);

            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();   // Run the statement.
            _db.Close();            

            if (res == 1) return true;           // Should only update one row.
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
            query += @"mobile=@'mobile', homePhone='@homePhone', email='@email', engagedTo='@engagedTo'";
            query += @"WHERE id='@id'";

            SqlCommand myCommand = new SqlCommand(query, _db);

            myCommand.Parameters.AddWithValue("@firstname", c.Firstname);
            myCommand.Parameters.AddWithValue("@surname", c.Surname);
            myCommand.Parameters.AddWithValue("@contactPerson", c.ContactPerson);
            myCommand.Parameters.AddWithValue("@address", c.Address);
            myCommand.Parameters.AddWithValue("@mobile", c.Mobile);
            myCommand.Parameters.AddWithValue("@homePhone", c.HomePhone);
            myCommand.Parameters.AddWithValue("@email", c.Email);
            myCommand.Parameters.AddWithValue("@engagedTo", c.EngagedTo);
            myCommand.Parameters.AddWithValue("@id", id);
            
            int res = 0;
            _db.Open();
            res = myCommand.ExecuteNonQuery();   // Run the statement.
            _db.Close();

            if (res == 1) return true;           // Should only update one row.
            else return false;
        }

        /**
         *   Deletes a client from the database
         *   @Param  id:  the client to delete
         */
        public bool DeleteClient(int id)
        {

            return false;
        }

        /**
         *   Finds clients matching the pattern of s
         *   @Param name:  the partial firstname or surname to search for.
         */
        public List<Client> FindClients(string name)
        {

            return new List<Client>();
        }

        /**
         *   Adds a Wedding to the database
         *   @Param  w: The Wedding to add
         */
        public bool AddWedding(Wedding w)
        {

            return false;
        }

        /**
         *   Updates an existing wedding with new details
         *   @Param  id: The Wedding to update
         *   @Param   w: The new details of the wedding
         */
        public bool UpdateWedding(int id, Wedding w)
        {

            return false;
        }

        /**
         *   Deletes a Wedding from the database
         *   @Param  id: The wedding to remove
         */
        public bool DeleteWedding(int id)
        {
        
            return false;
        }

        /**
         *   Finds all weddings matching a given title
         *   @Param  title: the wedding title to find matches.
         *   returns:  a list of all weddings that have a similar title.
         */
        public List<Wedding> FindWedding(string title)
        {

            return new List<Wedding>();
        }

        /**
         *   Adds a supplier to the database
         *   @Param  s: The supplier to add.
         */
        public bool AddSupplier(Supplier s)
        {

            return false;
        }

        /**
         *   Deletes a supplier from the database
         *   @Param  id: The supplier to remove.
         */
        public bool DeleteSupplier(int id)
        {

            return false;
        }

        /**
         *   Updates an existing supplier in the database.
         *   @Param  id: The supplier to update
         *   @Param   s: The updated supplier details
         */
        public bool UpdateSupplier(int id, Supplier s)
        {

            return false;
        }

        /**
         *   Finds all suppliers matching the given name.
         *   @Param  name: The supplier name to find matches
         *   returns: a List of all possible matches
         */
        public List<Supplier> FindSupplier(string name)
        {

            return new List<Supplier>();
        }


        public bool AddStaff(Staff s)
        {

            String query = @"INSERT into Staff (firstname, surname, email, phone, notes, status)";
            query +=       @" VALUES (@_firstname, @_surname, @_email, @_phone, @_notes, @_status)";


            SqlCommand myCommand = new SqlCommand(query);

            myCommand.Parameters.AddWithValue("@_firstname", s.FirstName);
            myCommand.Parameters.AddWithValue("@_surname", s.Surname);
            myCommand.Parameters.AddWithValue("@_email", s.Email);
            myCommand.Parameters.AddWithValue("@_phone", s.Phone);
            myCommand.Parameters.AddWithValue("@_notes", s.Notes);
            myCommand.Parameters.AddWithValue("@_status", s.StatusToString());

            int res = 0;

            using (SqlConnection _db = new SqlConnection(connStr))
            {
                myCommand.Connection = _db;

                _db.Open();
                res = myCommand.ExecuteNonQuery();   // Run the statement.
                _db.Close();
            }
            
            if (res == 1) return true;           // Should only update one row.
            else return false;
        }

        /**
         *   Edits an existing staff member. 
         *   @Param  id: staff member to update
         *   @Param   s: the updated staff detrails
         */
        public bool EditStaff(int id, Staff s)
        {

            return false;
        }

        /**
         *   Changes the ActiveStatus of a staff member
         *   @Param  id: The staff member to update
         *   @param   a: The active status
         */
        public bool ChangeStaffActiveStatus(int id, Staff.Active a)
        {

            return false;
        }

        /**
         *   Returns a list of all clients
         */
        public List<Client> GetAllClients()
        {

            return new List<Client>();
        }

        /**
         *   Returns a list of all staff
         */
        public List<Staff> GetAllStaff()
        {

            return new List<Staff>();
        }

        /**
         *   Returns a list of all suppliers
         */
        public List<Supplier> GetAllSuppliers()
        {

            return new List<Supplier>();
        }

        /**
         *   Returns a list of all tasks
         */
        public List<Support_Classes.Task> GetAllTasks()
        {

            return new List<Support_Classes.Task>();
        }

        /**
         *   Returns a list of all weddings
         */
        public List<Wedding> GetAllWeddings()
        {

            return new List<Wedding>();
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
            SqlConnection _db = new SqlConnection(connStr);

            SqlCommand testStaff = new SqlCommand(
               "SELECT firstname FROM Staff WHERE firstname = '" + s.FirstName + "' AND surname = '" +
               s.Surname + "' AND phone = '" + s.Phone + "'", _db);

            try
            {
                using (var myReader = testStaff.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        return Convert.ToInt32(myReader["Id"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return -1;
        }

        /**
         *   Checks the Task table and returns the Task Id number if it exists.
         *   Returns -1 if the Task does not exist.
         */
        private int getTaskId(Support_Classes.Task t)
        {
            SqlConnection _db = new SqlConnection(connStr);

            SqlCommand testTask = new SqlCommand(
               "SELECT Id FROM Task WHERE name = '" + t.TaskName + 
                    "' AND description = '" + t.Description + "'", _db);

            using (var myReader = testTask.ExecuteReader())
            {
                if (myReader.Read())
                {
                    return Convert.ToInt32(myReader["Id"].ToString());
                }
                else
                {
                    return -1;
                }
            }
        }

        private int getWeddingId(int id)
        {
            return -1;
        }


        /**
         *   Used for debugging purposes.
         *   TODO: DELETE AFTERWARDS!!!!
         */   
        public void ShowData()
        {
            SqlConnection _db = new SqlConnection(connStr);
            try 
            {
                _db.Open();

                SqlDataReader myReader = null;
                SqlCommand myCommand= new SqlCommand("SELECT * FROM Suppliers", _db);

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

        
        

    }
}
