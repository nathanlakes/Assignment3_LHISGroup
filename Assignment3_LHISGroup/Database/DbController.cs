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

        SqlConnection db;
        
        public DbController()
        {
            try
            {
                string connStr = "Data Source=(LocalDB)\\v11.0;" +
                    "AttachDbFilename=|DataDirectory|\\Database\\Model.mdf;" + 
                    "Integrated Security=True";
                db = new SqlConnection(connStr);
            }
            catch (Exception e)
            {
                e.GetHashCode();
                Console.WriteLine("Error with Connection String.");
            }
            
            this.ShowData();
        }

        /**
         *   Adds a given Staff Member to a task and writes to the database.
         *   Nb. Task cannot be made without it being assigned to somebody.
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

            SqlCommand myCommand = new SqlCommand(query, db);

            int res = myCommand.ExecuteNonQuery();
            if (res == 1) return true;  //Should only update one row

            return false;
        }

        /**
         *   Changes the Staff member assigned to a task.
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

            SqlCommand myCommand = new SqlCommand(query, db);

            int res = myCommand.ExecuteNonQuery();  // Run the statement.

            if (res == 1) return true;  // Should only update one row.
            else return false;
        }


        public bool DeleteTask(Support_Classes.Task t)
        {

            return false;
        }

        public Support_Classes.Task UpdateTask(int id)
        {
            
            Support_Classes.Task t = null;
            return t;
        }


        public bool AddClient(Client c)
        {

            return false; 
        }

        public bool UpdateClient(int id)
        {

            return false;
        }

        public bool DeleteClient(int id)
        {

            return false;
        }

        public List<Client> FindClients(string s)
        {

            return new List<Client>();
        }

        public bool AddWedding(Wedding w)
        {

            return false;
        }

        public bool UpdateWedding(Wedding w)
        {

            return false;
        }

        public bool DeleteWedding(Wedding w)
        {
        
            return false;
        }

        public List<Wedding> FindWedding(string title)
        {

            return new List<Wedding>();
        }


        public bool AddSupplier(Supplier s)
        {

            return false;
        }

        
        public bool DeleteSupplier(int id)
        {

            return false;
        }


        public bool UpdateSupplier(int id)
        {

            return false;
        }

        public List<Supplier> FindSupplier(string name)
        {

            return new List<Supplier>();
        }


        public bool AddStaff(Staff s)
        {

            return false;
        }

        /**
         *   @Param__id = staff member to update
         *   @Param__s  = new staff details to update
         */
        public bool EditStaff(int id, Staff s)
        {

            return false;
        }

        
        public bool ChangeStaffActiveStatus(int id, Staff.Active a)
        {

            return false;
        }

        public List<Client> GetAllClients()
        {

            return new List<Client>();
        }


        public List<Staff> GetAllStaff()
        {

            return new List<Staff>();
        }

        public List<Supplier> GetAllSuppliers()
        {

            return new List<Supplier>();
        }

        public List<Support_Classes.Task> GetAllTasks()
        {

            return new List<Support_Classes.Task>();
        }

        public List<Wedding> GetAllWeddings()
        {

            return new List<Wedding>();
        }



        //\\//\\//\\//\\//\\/
        // PRIVATE METHODS \\
        //\\//\\//\\//\\//\\/

        /**
         *   Checks the Staff table and returns the staff ID number if they exist.
         *   Returns -1 if the staff member does not exist.
         */   
        private int getStaffId(Staff s)
        {
            SqlCommand testStaff = new SqlCommand(
               "SELECT firstname FROM Staff WHERE firstname = '" + s.FirstName + "' AND surname = '" +
               s.Surname + "' AND phone = '" + s.Phone + "'", db);

            using (var myReader = testStaff.ExecuteReader())
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

        /**
         *   Checks the Task table and returns the Task Id number if it exists.
         *   Returns -1 if the Task does not exist.
         */
        private int getTaskId(Support_Classes.Task t)
        {
            SqlCommand testTask = new SqlCommand(
               "SELECT Id FROM Task WHERE name = '" + t.TaskName + 
                    "' AND description = '" + t.Description + "'", db);

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


        /**
         *   Used for debugging purposes
         */   
        public void ShowData()
        {
            try 
            {
                db.Open();

                SqlDataReader myReader = null;
                SqlCommand myCommand= new SqlCommand("SELECT * FROM Suppliers", db);

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Console.WriteLine(myReader["CompanyName"].ToString());
                    Console.WriteLine(myReader["ContactPerson"].ToString());
                }

                db.Close();
            }
            catch (Exception e) { e.GetHashCode(); }
            
            

        }

        
        

    }
}
