using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Transactions;

namespace dapper_net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            IDbConnection db = new SqlConnection(configuration.GetSection("constr").Value);
            Console.WriteLine(db.Database);

            var walletToInsert = new Wallet
            {
                Holder = "Hany",
                Balance = 8700
            };
            var walletToUpdate = new Wallet
            {
                Holder = "Hany aiman",
                Balance = 8750,
                Id=11
            };

            #region Simple Insert
            // var insert = "INSERT INTO Wallets (Holder, Balance) VALUES "
            //       + $" (@Holder, @Balance);";
            //int rowsAffected= db.Execute(insert,
            //     new{
            //     Holder= walletToInsert.Holder,
            //     Balance= walletToInsert.Balance,
            //     });

            // if (rowsAffected > 0)
            // {
            //     Console.WriteLine($"Wallet for {walletToInsert.Holder} added successfully");
            // }
            // else
            // {
            //     Console.WriteLine("Error while inserting wallet");
            // }
            #endregion

            #region Insert Returns Identity
            //var insert = "INSERT INTO Wallets (Holder, Balance) VALUES "
            //      + $" (@Holder, @Balance);" +
            //      $"select Cast(scope_identity() as int )";
            //var parameters = new
            //{
            //    Holder = walletToInsert.Holder,
            //    Balance = walletToInsert.Balance,
            //};

            //walletToInsert.Id = db.Query<int>(insert,parameters).Single();
            //Console.WriteLine(walletToInsert);
            //if (walletToInsert.Id > 0)
            //{
            //    Console.WriteLine($"Wallet for {walletToInsert.Holder} added successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Error while inserting wallet");
            //}
            #endregion

            #region Execute update Statement
            //var update = "update  Wallets set Holder=@Holder, Balance=@Balance  "
            //      + $"Where Id=@id";
            //var parameters = new
            //{
            //    Id=walletToUpdate.Id,
            //    Holder = walletToUpdate.Holder,
            //    Balance = walletToUpdate.Balance
            //};

            //int numRowEffect =db.Execute(update, parameters);
            //Console.WriteLine(walletToInsert);
            //if (numRowEffect > 0)
            //{
            //    Console.WriteLine($"Wallet for {walletToUpdate.Holder} update successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Error while update wallet");
            //}
            #endregion

            #region Execute Delete Statement
            //string delete = "DELETE FROM Wallets WHERE Id=@Id";
            //var parameters = new
            //{
            //    Id =5,
            //};

            //int numRowEffect = db.Execute(delete, parameters);
            //if (numRowEffect > 0)
            //{
            //    Console.WriteLine($"Wallet for delete successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Error while inserting wallet");
            //}
            #endregion

            #region Execute Multiple Queries in one Batch
            //var min_max = "select Min(Balance) from wallets;" +
            //    "select Max(Balance) from wallets;" +
            //    "select Avg(Balance) from wallets";
            //var multi = db.QueryMultiple(min_max);
            ////Console.WriteLine($"min is :{multi.ReadSingle<decimal>()} " +
            ////    $"\t max is :{multi.ReadSingle<decimal>()}" +
            ////    $"\t Avg is :{multi.ReadSingle<decimal>()}");

            //Console.WriteLine(
            //    $"min is :{multi.ReadSingle<decimal>()} " +
            //   $"\t max is :{multi.Read<decimal>().Single()}" +
            //   $"\t Avg is :{multi.Read<decimal>().Single()}");
            #endregion

            #region transaction

            //decimal amountToTransfer = 145;

            //using (var TransactionScope=new TransactionScope())
            //{
            //    var walletFrom = db.QuerySingle<Wallet>
            //        ("Select * from wallets where Id=@Id ", new { Id = 8 });

            //    var walletTo = db.QuerySingle<Wallet>
            //       ("Select * from wallets where Id=@Id ", new { Id = 2 });

            //    walletFrom.Balance -= amountToTransfer;

            //    walletTo.Balance += amountToTransfer;

            //    db.Execute("update Wallets set Balance = @Balance " +
            //        "where Id=@Id",
            //        new
            //        {
            //            Id=walletFrom.Id,
            //            Balance=walletFrom.Balance
            //        }
            //    );
            //    db.Execute("update Wallets set Balance = @Balance " +
            //       "where Id=@Id",
            //       new
            //       {
            //           Id=walletTo.Id,
            //           Balance=walletTo.Balance
            //       }
            //    );

            //    TransactionScope.Complete();
            //}
            #endregion
            #region Execute Raw Sql 
            var sql = "Select * from Wallets";

            Console.WriteLine("------------------------------ using Dynamic Query--------------------------");
            var ressltAsDynamic = db.Query(sql);
            foreach (var item in ressltAsDynamic)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------ using Typre Query--------------------------");
            var wallets = db.Query<Wallet>(sql);

            foreach (var item in wallets)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
