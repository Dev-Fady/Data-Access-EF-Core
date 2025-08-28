using EF_Core_Configuration.Data.Config;
using EF_Core_Configuration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Configuration.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> tblUsers { get; set; } = null!;
        public DbSet<Tweet> Tweets { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Comment>().ToTable("tblComments");
        //    modelBuilder.Entity<Comment>().Property(p=>p.Id).HasColumnName("CommentId");

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new UserConfiguration().Configure(modelBuilder.Entity<User>());
            //new TweetConfiguration().Configure(modelBuilder.Entity<Tweet>());
            //new CommentConfiguration().Configure(modelBuilder.Entity<Comment>());
          
            // or usr from Assembly 
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(UserConfiguration).Assembly);
        }
    }
}
