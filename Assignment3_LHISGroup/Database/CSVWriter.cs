using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment3_LHISGroup.Support_Classes;


namespace Assignment3_LHISGroup
{
    /*
     *    Takes a List<Support_Class> and outputs them to
     *    a CSV file on the Desktop
     */
    class CSVWriter
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName;


        /*
         *   Create an instance of the writer for each report you want, do not reuse.
         *   As each CSVWriter object is bound to a reportName
         */
        public CSVWriter(string reportName)
        {
            fileName = path + "\\reportName " + DateTime.Now.Day.ToString() + "-" +
            DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".csv";
        }

        
        /*
         *   Takes a List<Client> and writes them to a CSV output file.
         */
        public void WriteClientsToFile(List<Client> outputClients)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                string[] titles = getClientHeadings();

                // Write the headings to output file.
                for (int i = 0; i < titles.Length; i++)
                {
                    if (i < titles.Length - 1)
                    {
                        file.Write(titles[i] + ",");
                    }
                    else
                    {
                        file.WriteLine(titles[i]);
                    }
                }

                // Write the data to the outfile.
                // Quotations " " prevent commas in text fields from breaking
                // CSV formatting
                foreach (Client c in outputClients)
                {
                    file.Write("\"" + c.Firstname + "\",");
                    file.Write("\"" + c.Surname + "\",");
                    file.Write("\"" + c.ContactPerson + "\",");
                    file.Write("\"" + c.Address + "\",");
                    file.Write("\"" + c.Mobile + "\",");
                    file.Write("\"" + c.HomePhone + "\",");
                    file.Write("\"" + c.Email + "\",");
                    file.Write("\"" + c.EngagedTo_fn + "\",");
                    file.WriteLine("\"" + c.EngagedTo_sn);
                }
            }
        }


        /*
         *  Generates headings for Client Records
         */
        private string[] getClientHeadings()
        {
            string[] titles = new string[]{
                    "firstname", 
                    "surname",
                    "contactPerson",
                    "address",
                    "mobile",
                    "homePhone",
                    "email",
                    "engagedTo_firstname",
                    "engagedTo_surname"
                };

            return titles;
        }

        /*
         *  Generates headings for Staff Records
         */
        private string[] getStaffHeadings()
        {
            string[] titles = new string[]{
                    "firstname", 
                    "surname",
                    "email",
                    "phone",
                    "notes",
                    "active"
            };

            return titles;
        }


        /*
         *  Generates headings for Supplier Records
         */
        private string[] getSupplierHeadings()
        {
            string[] titles = new string[]{
                    "companyName", 
                    "address",
                    "contactPerson",
                    "email",
                    "phoneNumber",
                    "creditTerms"
            };

            return titles;
        }


        /*
         *  Generates headings for Task Records
         */
        private string[] getTaskHeadings()
        {
            string[] titles = new string[]{
                    "taskName", 
                    "description",
                    "priority",
                    "completeByDate",
                    "completionDate",
                    "assignedTo",
                    "relatedWedding"
            };

            return titles;
        }


        /*
         *  Generates headings for Wedding Records
         */
        private string[] getWeddingHeadings()
        {
            string[] titles = new string[]{
                    "title", 
                    "client_1",
                    "client_2",
                    "startDate",
                    "eventDate",
                    "weddingPlanner"
            };

            return titles;
        }

    }
}
