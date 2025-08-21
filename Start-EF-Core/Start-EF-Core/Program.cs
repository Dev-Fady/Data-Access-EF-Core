using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Start_EF_Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context=new AppDBContext())
            {
                #region  Retrieve Single Data
                //var itemIdRetrieve = context.wallets.FirstOrDefault(c => c.Id == 2);
                //Console.WriteLine(itemIdRetrieve);
                #endregion
                #region Insert Data
                //var walletInsert = new Wallet
                //{
                //    Holder = "FoFo",
                //    Balance = 3214
                //};
                //context.wallets.Add(walletInsert);
                //context.SaveChanges();
                #endregion

                #region Update Data
                //var wallets = context.wallets.Single(x => x.Id == 2);
                //wallets.Holder = "RoRo";
                //context.SaveChanges();
                #endregion
                #region Delete Data
                //var wallets=context.wallets.Where(x=>x.Id==12).ExecuteDelete();
                //context.SaveChanges();
                #endregion

                #region Query Data
                //var wallets = context.wallets.Where(x => x.Balance > 5000);
                //Console.WriteLine("Wallets more Balanec 5000");
                //foreach (var item in wallets)
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine("end query");
                #endregion
                #region Transaction
                //using (var transaction=context.Database.BeginTransaction())
                //{
                //    var fromWallet=context.wallets.SingleOrDefault(x => x.Id == 10);

                //    var toWallet = context.wallets.SingleOrDefault(x => x.Id == 3 );

                //    var amountToTransfer = 500m;
                    
                //    fromWallet!.Balance -= amountToTransfer;
                //    toWallet!.Balance += amountToTransfer;


                //    transaction.Commit();
                //    context.SaveChanges();

                //}
                #endregion

                #region Retrieve All Data
                foreach (var item in context.wallets)
                {
                    Console.WriteLine(item);
                }
                #endregion
            }

        }
    }
}
