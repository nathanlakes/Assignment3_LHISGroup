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
         *   Adds a given Staff Member to a task and writes to the database
         */
        public bool AddPersonToTask(Support_Classes.Task t, Staff s)
        {
            // Check that staff exists in the database.
            SqlCommand testStaff = new SqlCommand(
                "SELECT firstname FROM Staff WHERE firstname = '" + s.FirstName + "' AND surname = '" +
                s.Surname + "'", db);

            int staffId;

            using (var myReader = testStaff.ExecuteReader())
            {
                if ( myReader.Read() )
                {
                    staffId = Convert.ToInt32( myReader["Id"].ToString() );

                }
                else
                {
                    throw new Exception("Add staff member to Db.Staff before assigning them to a task.");
                }
            }
           



            //String query = "INSERT INTO Task(id,username,password,email) VALUES(@id,@username,@password, @email)";
            //SqlCommand myCommand = new SqlCommand(query, db);

            return true;
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
