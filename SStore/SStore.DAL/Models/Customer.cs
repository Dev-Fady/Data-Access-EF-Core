using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SStore.DAL.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }   // PK, not null
        public string FirstName { get; set; } // not null
        public string LastName { get; set; }  // not null
        public string Email { get; set; }     // not null
        public string Phone { get; set; }     // not null

        public string City { get; set; }      // nullable
        public string StateName { get; set; } // nullable
        public string ZipCode { get; set; }   // nullable
        public string Country { get; set; }   // nullable
        public DateTime? CreatedAt { get; set; } // nullable

        public override string ToString()
        {
            return $"{CustomerID} - {FirstName} {LastName} | {Email} | {Phone} | {City}, {Country}";
        }
    }
}
