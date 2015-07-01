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
        
        public DbController()
        {
            try
            {
                string connStr = "Data Source=(LocalDB)\\v11.0;" +
                    "AttachDbFilename=|DataDirectory|\\Database\\Model.mdf;" + 
                    "Integrated Security=True";
                _db = new SqlConnection(connStr);
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Error with Connection String. " + e.ToString());
            }
            
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

            string _s = ",";

            String query = "INSERT INTO Task(name,description,priority,completeByDate, staffOnJob_FK) " +
                "VALUES(" + t.TaskName + _s + t.Description + _s + t.TaskPriority + _s + 
                t.CompleteBy.Date.ToString() + _s + staffId + ")";

            _db.Open();
            SqlCommand myCommand = new SqlCommand(query, _db);

            int res = myCommand.ExecuteNonQuery();
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

            String query = "UPDATE Task SET staffOnJob_FK='"+ staffId +"'" +
                "WHERE Id='"+ taskId +"'";

            SqlCommand myCommand = new SqlCommand(query, _db);

            int res = myCommand.ExecuteNonQuery();  // Run the statement.

            if (res == 1) return true;  // Should only update one row.
            else return false;
        }

        /**
         *   Removes a Task from the database.
         *   @Param  id: the primary key of the task
         */
        public bool DeleteTask(int id)
        {

            return false;
        }

        /**
         *   Updates an existing task with the new values provided.
         *   @Param  id: the primary key of the task to change
         *   @Param  t : the new task object with updated values
         */
        public Support_Classes.Task UpdateTask(int id, Support_Classes.Task t)
        {
            
            Support_Classes.Task tt = null;
            return tt;
        }

        /**
         *   Adds a client to the database.
         *   @Param  c: the client to add.
         */
        public bool AddClient(Client c)
        {

            return false; 
        }

        /**
         *   Updates an existing client with the values provided
         *   @Param  id: the Client to update
         *   @Param  c : the new details of client with the given id number
         */
        public bool UpdateClient(int id, Client c)
        {

            return false;
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
            try 
            {
                _db.Open();

                SqlDataReader myReader = null;
                SqlCommand myCommand= new SqlCommand("SELECT * FROM Suppliers", _db);

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Console.WriteLine(myReader["CompanyName"].ToString());
                    Console.WriteLine(myReader["ContactPerson"].ToString());
                }

                _db.Close();
            }
            catch (Exception e) { e.GetHashCode(); }
            
        }

        
        

    }
}
