using EF_DB_Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DB_Context.Data
{
    public class AppDBContext :DbContext
    {
        public DbSet<Wallet> wallets { get; set; } =null!;

        #region DBContext External Configuration
        public AppDBContext(DbContextOptions options)
            : base(options)
        {

        }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            #region DBContext Internal Configuration
            //var configuration = new ConfigurationBuilder()
            // .AddJsonFile("appsettings.json")
            // .Build();

            //string connectionString = configuration.GetSection("constr").Value;

            //optionsBuilder.UseSqlServer(connectionString);
            #endregion
        }
    }
}
