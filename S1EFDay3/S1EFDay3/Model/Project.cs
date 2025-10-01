using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Department> Departments { get; set; } = new List<Department>();

        // Many to Many Relationship with Payload
        public ICollection<DepartmentProject> DepartmentProjects { get; set; } = new List<DepartmentProject>();

    }
}
