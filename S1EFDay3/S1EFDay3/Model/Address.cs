using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }

        public string Governament { get; set; }

        // One To one Relationship
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
