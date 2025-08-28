using EF_DB_Context.Data;
using EF_DB_Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EF_DB_Context
{
   
    internal class Program
    { 
        static AppDBContext context;
        static async Task Main(string[] args)
        {
            #region DBContext External Configuration
            //var configuration = new ConfigurationBuilder()
            // .AddJsonFile("appsettings.json")
            // .Build();

            //string connectionString = configuration.GetSection("constr").Value;

            //var optionsBuilder = new DbContextOptionsBuilder();

            //optionsBuilder.UseSqlServer(connectionString);
            //var options = optionsBuilder.Options;


            //using (var context = new AppDBContext(options))
            //{
            //    foreach (var item in context.wallets)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region Dependency Injection
            //var configuration = new ConfigurationBuilder()
            // .AddJsonFile("appsettings.json")
            // .Build();

            //string connectionString = configuration.GetSection("constr").Value!;

            //var services = new ServiceCollection();

            //services.AddDbContext<AppDBContext>(
            //    options => options.UseSqlServer(connectionString)
            //    );

            //IServiceProvider serviceProvider = services.BuildServiceProvider();

            //using (var context = serviceProvider.GetService<AppDBContext>())
            //{
            //    foreach (var item in context!.wallets)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region DBContext Factory 
            //var configuration = new ConfigurationBuilder()
            // .AddJsonFile("appsettings.json")
            // .Build();

            //string connectionString = configuration.GetSection("constr").Value!;

            //var services = new ServiceCollection();

            //services.AddDbContextFactory<AppDBContext>(
            //    options => options.UseSqlServer(connectionString)
            //    );

            //IServiceProvider serviceProvider = services.BuildServiceProvider();

            //var contextFactory = serviceProvider.GetService<IDbContextFactory<AppDBContext>>();
            //using (var context = contextFactory!.CreateDbContext())
            //{
            //    foreach (var item in context!.wallets)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region Execute Concurrently
            //var configuration = new ConfigurationBuilder()
            // .AddJsonFile("appsettings.json")
            // .Build();

            //string connectionString = configuration.GetSection("constr").Value!;

            //var services = new ServiceCollection();

            //services.AddDbContext<AppDBContext>(
            //    options => options.UseSqlServer(connectionString)
            //    );

            //IServiceProvider serviceProvider = services.BuildServiceProvider();

            //context = serviceProvider.GetRequiredService<AppDBContext>();

            //var tasks = new[]
            //{
            //    Task.Factory.StartNew(()=>Job1()),
            //    Task.Factory.StartNew(()=>Job2()),
            //};
            //await Task.WhenAll(tasks).ContinueWith(t =>
            //{
            //    Console.WriteLine("Jop1 & jop2 execute Concurrently");
            //});

            //using (var test = serviceProvider.GetService<AppDBContext>())
            //{
            //    foreach (var item in test!.wallets)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            #endregion

            #region DBContext Pooling
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();

            string connectionString = configuration.GetSection("constr").Value!;

            var services = new ServiceCollection();

            services.AddDbContextPool<AppDBContext>(
                options => options.UseSqlServer(connectionString)
                );

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDBContext>())
            {
                foreach (var item in context!.wallets)
                {
                    Console.WriteLine(item);
                }
            }
            #endregion

        }
        static async Task Job1()
        {
            var w1 = new Wallet
            {
                Holder = "NaNa",
                Balance = 900
            };
            context.wallets.Add(w1);
            await context.SaveChangesAsync();
        }
        static async Task Job2()
        {
            var w2 = new Wallet
            {
                Holder = "SoSo",
                Balance = 1999
            };
            context.wallets.Add(w2);
            await context.SaveChangesAsync();
        }
    }
}
