using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assignment3_LHISGroup
{

    /**
     *   The controller for the SQL Database model. 
     *   All views interface with Database.cs and read
     *   write via this class
     */   
    class DbController
    {

        SqlConnection db;
        
        public DbController()
        {
            try
            {
                string connStr = "Data Source=(LocalDB)\v11.0;" + 
                    "AttachDbFilename=Assignment3_LHISGroup/Assignment3_LHISGroup/Model.mdf;" + 
                    "Integrated Security=True";
                db = new SqlConnection(connStr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error with Connection String.");
            }
            
            this.ShowData();
        }

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
            catch (Exception e) {}
            
            

        }

        
        

    }
}
