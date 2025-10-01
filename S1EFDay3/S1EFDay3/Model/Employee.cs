using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public bool IsDeleted { get; set; }

        // One To one Relationship By Convention
        public int AddressId { get; set; }
        public Address Address { get; set; }

        // one to Many Relationship By Convention
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
