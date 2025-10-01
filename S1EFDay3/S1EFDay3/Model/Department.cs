using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // one  to Many Relationship By Convention
        public List<Employee> Employees { get; set; } = new List<Employee>();

        //public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<DepartmentProject> DepartmentProjects { get; set; } = new List<DepartmentProject>();

    }
}
