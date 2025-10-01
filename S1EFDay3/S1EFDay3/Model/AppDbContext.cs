using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<DepartmentProject> DepartmentProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);

            // 3️ Stop Tracking Over Context on livel Context
            //optionsBuilder
            //    .UseSqlServer("Connection String")
            //    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
