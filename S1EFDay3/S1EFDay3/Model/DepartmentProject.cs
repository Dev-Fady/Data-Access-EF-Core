using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model
{
    public class DepartmentProject
    {
        public int DepartmentId { get; set; } 
        public Department Department { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;


    }
}
