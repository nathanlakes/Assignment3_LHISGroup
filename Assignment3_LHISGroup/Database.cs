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
    class Database
    {

        SqlConnection db;


        public Database(string username, string password, string serverurl, 
                        string trustConn, string dbb, int timeOut)
        {

            try
            {
                db = new SqlConnection("user id=" + username + ";" +
                                    "password=" + password + ";" +
                                    "server=" + serverurl + ";" +
                                    "Trusted_Connection=" + trustConn + ";" +
                                    "database=" + dbb + ";" +
                                    "connection timeout=" + timeOut);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connecting to the database.");
            }
            
        }

        
        

    }
}
