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
            fileName = path + "\\" + reportName + DateTime.Now.Day.ToString() + "-" +
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
                    file.WriteLine("\"" + c.EngagedTo_sn + "\"");
                }
            }
        }

        /*
         *   Takes a List<Staff> and writes them to a CSV output file.
         */
        public void WriteStaffToFile(List<Staff> outputStaff)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                string[] titles = getStaffHeadings();

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
                foreach (Staff s in outputStaff)
                {
                    file.Write("\"" + s.FirstName + "\",");
                    file.Write("\"" + s.Surname + "\",");
                    file.Write("\"" + s.Email + "\",");
                    file.Write("\"" + s.Phone + "\",");
                    file.Write("\"" + s.Notes + "\",");
                    file.WriteLine("\"" + s.StaffStatus.ToString() + "\"");
                }
            }
        }


        /*
         *   Takes a List<Supplier> and writes them to a CSV output file.
         */
        public void WriteSupplierToFile(List<Supplier> outputSupplier)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                string[] titles = getSupplierHeadings();

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
                foreach (Supplier s in outputSupplier)
                {
                    file.Write("\"" + s.CompanyName + "\",");
                    file.Write("\"" + s.Address + "\",");
                    file.Write("\"" + s.ContactPerson + "\",");
                    file.Write("\"" + s.Email + "\",");
                    file.Write("\"" + s.PhoneNumber + "\",");
                    file.WriteLine("\"" + s.CreditTerms.ToString() + "\"");
                }
            }
        }


        /*
         *   Takes a List<Task> and writes them to a CSV output file.
         */
        public void WriteTasksToFile(List<Support_Classes.Task> outputTask)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                string[] titles = getTaskHeadings();

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
                foreach (Task t in outputTask)
                {
                    file.Write("\"" + t.TaskName + "\",");
                    file.Write("\"" + t.Description + "\",");
                    file.Write("\"" + t.TaskPriority.ToString() + "\",");
                    file.Write("\"" + t.CompleteBy.ToShortDateString() + "\",");
                    try
                    {
                        file.Write("\"" + t.CompletionDate.Value.ToShortDateString() + "\",");
                    } catch(Exception)
                    {
                        file.Write("\"\",");
                    }

                    file.Write("\"[" + t.ID + "] " + t.AssignedTo.FirstName + " " + t.AssignedTo.Surname + "\",");
                    file.WriteLine("\"[" + t.Wedding.ID + "] " + t.Wedding.Title + "\"");
                }
            }
        }

        /*
         *   Takes a List<Task> and writes them to a CSV output file.
         */
        public void WriteEventReportTasksToFile(List<Support_Classes.Task> outputTask)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, true))
            {
                string[] titles = getEventReportTaskHeadings();
                file.WriteLine("-----Event Tasks-----");
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
                foreach (Task t in outputTask)
                {
                    file.Write("\"" + t.TaskName + "\",");
                    file.Write("\"" + t.TaskPriority.ToString() + "\",");
                    file.Write("\"" + t.CompleteBy.ToShortDateString() + "\",");
                    try
                    {
                        file.Write("\"" + t.CompletionDate.Value.ToShortDateString() + "\",");
                    }
                    catch (Exception)
                    {
                        file.Write("\"\",");
                    }

                    file.Write("\"[" + t.ID + "] " + t.AssignedTo.FirstName + " " + t.AssignedTo.Surname + "\",");
                    file.WriteLine();
                }
            }
        }

        /*
         *   Takes a List<Wedding> and writes them to a CSV output file.
         */
        public void WriteWeddingToFile(List<Wedding> outputWedding)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
            {
                string[] titles = getWeddingHeadings();

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
                foreach (Wedding w in outputWedding)
                {
                    file.Write("\"" + w.Title + "\",");
                    file.Write("\"[" + w.Client1.ID + "] " + w.Client1.Firstname + " " + w.Client1.Surname + "\",");
                    file.Write("\"[" + w.Client2.ID + "] " + w.Client2.Firstname + " " + w.Client2.Surname + "\",");
                    file.Write("\"" + w.StartDate.ToShortDateString() + "\",");
                    file.Write("\"" + w.EventDate.ToShortDateString() + "\",");
                    file.WriteLine("\"[" + w.ID + "] " + w.WeddingPlanner.FirstName + " " + 
                        w.WeddingPlanner.Surname + "\"");
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
         *  Generates headings for Task Records within Event Report
         */
        private string[] getEventReportTaskHeadings()
        {
            string[] titles = new string[]{
                    "taskName", 
                    "priority",
                    "completeByDate",
                    "completionDate",
                    "assignedTo"
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
