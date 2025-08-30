using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Types_Mapping.Entities
{
    [NotMapped]
    public class Snapshot
    {
        public DateTime LoadeAt => DateTime.UtcNow;

        public string Version => Guid.NewGuid().ToString().Substring(0, 8);
    }
}
