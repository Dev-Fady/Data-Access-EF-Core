using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConcurrencyDemo.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server connection string
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BankDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
