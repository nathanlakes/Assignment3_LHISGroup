using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3_LHISGroup.Support_Classes
{

        public class Supplier
        {
            private int id;                 // Do not set this attribute, handled by DBMS
            private string companyName;
            private string address;
            private string contactPerson;
            private string email;
            private string phoneNumber;
            private int creditTerms;

            public Supplier()
            {
                companyName = null;
            }

            public Supplier(string name, string addr, string cont, string email, string phNum, int creditTerms)
            {
                this.companyName = name;
                this.address = addr;
                this.contactPerson = cont;
                this.email = email;
                this.phoneNumber = phNum;
                this.creditTerms = creditTerms;
            }

            public int ID
            {
                get { return id; }
                set { id = value; }
            }

            public string CompanyName
            {
                get { return companyName; }
                set { this.companyName = value; }
            }

            public string Address
            {
                get { return address; }
                set { this.address = value; }
            }

            public string ContactPerson
            {
                get { return contactPerson; }
                set { this.contactPerson = value; }
            }

            public string Email
            {
                get { return email; }
                set { this.email = value; }
            }
        
            public string PhoneNumber
            {
                get { return phoneNumber; }
                set { this.phoneNumber = value; }
            }

            public int CreditTerms
            {
                get { return this.creditTerms; }
                set
                {
                    if (value < 0)
                    {
                        throw new Exception("Credit Terms must be 0 or more days.");
                    }
                    else
                    {
                        this.creditTerms = value;
                    }
                }
            }
     
        }
}
