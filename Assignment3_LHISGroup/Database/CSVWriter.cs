using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_LHISGroup
{
    /*
     *   
     *   
     */


    
    class CSVWriter
    {
        public CSVWriter()
        {

        }

        /*
         * Generates headings for the CSV
         */
        private string[] getSuppliersHeadings()
        {
            string[] titles = new string[]{
                    "id", 
                    "CompanyName",
                    "Address",
                    "ContactPerson",
                    "Email",
                    "PhoneNumber",
                    "CreditTerms"
                };

            return titles;
        }

       
        
        
        
        /*
         * Extracts the data from a given quotation and returns
         * a string array of the relevent data for writing to the
         * outfile
         */
       
        /*
        private string[] getData(Quotation q)
        {
            string[] data = new string[]{
                        q.State.ToString(),
                        q.CompleteDate,
                        q.Name,
                        q.Address,
                        q.PhoneNumber,
                        q.TotalCost.ToString(),
                        q.Date,
                        q.QuoteType,
                        q.CalloutFee.ToString(),
                        q.PriorityFee.ToString(),
                        q.Inspection.ToString(),
                        q.OsUpdate.ToString(),
                        q.SoftwareInstall.ToString(),
                        q.AntiVirus.ToString(),
                        q.MemoryUpgrade.ToString(),
                        q.HdUpgrade.ToString(),
                        q.Other.ToString(),
                        q.Discount.ToString()
                    };

            return data;
        }
        */


        /*
         * Writes all quotations in the database to an output file. 
         * isExport = true: Writes to the Desk
         * isExport = false: Writes to My Documents, thus storing the database
         */
        /*
        public void WriteAllToCSV(Database db, Boolean isExport)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (isExport)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            List<Quotation> records = db.GetQuoteRecords();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + "\\db_outfile.csv", false))
            {
                string[] titles = getHeadings();

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


                foreach (Quotation q in records)
                {
                    string[] data = getData(q);

                    // Write the various values seperated by ',' 
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (i < data.Length - 1)
                        {
                            file.Write(data[i] + ",");
                        }
                        else
                        {
                            file.WriteLine(data[i]);
                        }
                    }
                }
            } // Close StreamWriter

        }
        */



        /*
         * Writes a quote to a CSV on the desktop
         */

        /*
        public void WriteRecordToCSV(Quotation quote)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dir = path + "\\quote-" + quote.Name + " " + DateTime.Now.Day.ToString() + "-" +
                DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + ".csv";
            Console.WriteLine(dir);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(dir))
            {
                string[] headings = getHeadings();
                for (int i = 0; i < headings.Length; i++)
                {
                    if (i < headings.Length - 1)
                    {
                        file.Write(headings[i] + ",");
                    }
                    else
                    {
                        file.Write(headings[i] + "\n");
                    }
                }

                string[] data = getData(quote);
                for (int i = 0; i < data.Length; i++)
                {
                    if (i < data.Length - 1)
                    {
                        file.Write(data[i] + ",");
                    }
                    else
                    {
                        file.Write(data[i] + "\n");
                    }
                }
            }
        }
        */



        /*
         * Will take a list of Quotation objects and write them
         * to a CSV
         */
        /*
        public void WriteListToCSV(List<Quotation> list)
        {
            Database db = new Database(list);
            WriteAllToCSV(db, true);
        }
        */
    }
}
