using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Migration.Entites
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        // one to many ( Section , Course ) 
        public ICollection<Section> Sections { get; set; } = new List<Section>();

    }
}
