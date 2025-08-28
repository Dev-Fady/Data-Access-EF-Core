using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Configuration.Entities
{
    public class User
    {
        // Primary key convention [Id, id , ID] , [{Class}Id]
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
