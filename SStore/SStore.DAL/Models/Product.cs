using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SStore.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal price { get; set; }

        public int IdCategory { get; set; }

        public int stock { get; set; }

        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $" [{Id}] , {Name} , price {price} , stock {stock}";
        }

    }
}
