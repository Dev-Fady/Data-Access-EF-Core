using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ado_net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetSection("constr").Value;
            Console.WriteLine(connectionString);

            var walletToInsert = new Wallet
            {
                Holder = "fares",
                Balance = 4444
            };

            var walletToUpdate = new Wallet
            {
                Holder = "fares",
                Balance = 4444,
                Id=5
            };

            var walletoToDelete = new Wallet
            {
                Id = 5,
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                #region Execute Insert Command
                //string insert = "INSERT INTO Wallets (Holder, Balance) VALUES "
                //  + $" (@Holder, @Balance);"
                //  + $"select Cast(scope_identity() as int )";
                //using (SqlCommand insertCommand = new SqlCommand(insert, conn))
                //{
                //    insertCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Holder",
                //        SqlDbType = SqlDbType.VarChar,
                //        Value = walletToInsert.Holder
                //    });

                //    insertCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Balance",
                //        SqlDbType = SqlDbType.Decimal,
                //        Value = walletToInsert.Balance
                //    });

                //    walletToInsert.Id=(int) insertCommand.ExecuteScalar();

                //    //if (insertCommand.ExecuteNonQuery() > 0)
                //    //{
                //    //    Console.WriteLine($"Wallet for {walletToInsert.Holder} added successfully");
                //    //}
                //    //else
                //    //{
                //    //    Console.WriteLine("Error while inserting wallet");
                //    //}
                //}
                #endregion

                #region Execute Store Procedure
                ////string insert = "INSERT INTO Wallets (Holder, Balance) VALUES "
                ////  + $" (@Holder, @Balance);"
                ////  + $"select Cast(scope_identity() as int )";
                //using (SqlCommand insertCommand = new SqlCommand("AddWallet", conn))
                //{
                //    insertCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Holder",
                //        SqlDbType = SqlDbType.VarChar,
                //        Value = walletToInsert.Holder
                //    });

                //    insertCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Balance",
                //        SqlDbType = SqlDbType.Decimal,
                //        Value = walletToInsert.Balance
                //    });
                //    insertCommand.CommandType = CommandType.StoredProcedure;

                //    //walletToInsert.Id = (int)insertCommand.ExecuteScalar();

                //    if (insertCommand.ExecuteNonQuery() > 0)
                //    {
                //        Console.WriteLine($"Wallet for {walletToInsert.Holder} added successfully");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Error while inserting wallet");
                //    }
                //}
                #endregion

                #region Execute Update Raw SQL
                //string update = "update  Wallets set Holder=@Holder, Balance=@Balance  "
                //  + $"Where Id=@id";
                //using (SqlCommand updateCommand = new SqlCommand(update, conn))
                //{
                //    updateCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Holder",
                //        SqlDbType = SqlDbType.VarChar,
                //        Value = walletToUpdate.Holder
                //    });

                //    updateCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Balance",
                //        SqlDbType = SqlDbType.Decimal,
                //        Value =walletToUpdate.Balance
                //    });
                //    updateCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Id",
                //        SqlDbType = SqlDbType.Int,
                //        Value =walletToUpdate.Id
                //    });
                //    //updateCommand.CommandType = CommandType.StoredProcedure;

                //    //walletToInsert.Id = (int)insertCommand.ExecuteScalar();

                //    if (updateCommand.ExecuteNonQuery() > 0)
                //    {
                //        Console.WriteLine($"Wallet with Id={walletToUpdate.Id} updated successfully");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Error while updating wallet");
                //    }
                //}
                #endregion

                #region Execute delete Raw SQL
                //string delete = "DELETE FROM Wallets WHERE Id=@Id";

                //using (SqlCommand deleteCommand = new SqlCommand(delete, conn))
                //{
                //    deleteCommand.Parameters.Add(new SqlParameter
                //    {
                //        ParameterName = "@Id",
                //        SqlDbType = SqlDbType.Int,
                //        Value = walletoToDelete.Id 
                //    });

                //    if (deleteCommand.ExecuteNonQuery() > 0)
                //    {
                //        Console.WriteLine($"Wallet with Id={walletoToDelete.Id} delete successfully");
                //    }
                //    else
                //    {
                //        Console.WriteLine("Error while updating wallet");
                //    }
                //}
                #endregion

                #region DB Transaction
                using (SqlCommand sqlCommand = conn.CreateCommand())
                {
                    //conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    sqlCommand.Transaction = transaction;

                    try
                    {
                        sqlCommand.CommandText = "UPDATE Wallets SET Balance = Balance - 1000 WHERE Id = 9";
                        sqlCommand.ExecuteNonQuery();

                        sqlCommand.CommandText = "UPDATE Wallets SET Balance = Balance + 1000 WHERE Id = 2";
                        sqlCommand.ExecuteNonQuery();

                        transaction.Commit();
                        Console.WriteLine("Transaction of transfer completed successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error during transaction: " + ex.Message);
                        try
                        {
                            transaction.Rollback();
                            Console.WriteLine("Transaction rolled back");
                        }
                        catch (Exception rollbackEx)
                        {
                            Console.WriteLine("Error in rollback: " + rollbackEx.Message);
                        }
                    }
                    finally
                    {
                        string sql = "SELECT * FROM Wallets";
                        using (SqlCommand command = new SqlCommand(sql, conn))
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var wallet = new Wallet
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Holder = reader.GetString(reader.GetOrdinal("Holder")),
                                    Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                                };
                                Console.WriteLine(wallet);
                            }
                        }
                        conn.Close();
                    }
                }
                #endregion

                #region Execute Raw SQL Select Command
                //string sql = "SELECT * FROM Wallets";
                //using (SqlCommand command = new SqlCommand(sql, conn))
                //using (SqlDataReader reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        var wallet = new Wallet
                //        {
                //            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                //            Holder = reader.GetString(reader.GetOrdinal("Holder")),
                //            Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                //        };
                //        Console.WriteLine(wallet);
                //    }
                //}
                ////conn.Close();
                #endregion
                Console.WriteLine("=======================================");
                #region Execute DataAdapter in inmemory offline access
                string sqlAdapter = "SELECT * FROM Wallets";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlAdapter, conn))
                {
                    DataTable dt=new DataTable();
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        var wallet = new Wallet
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Holder = Convert.ToString(dr["Holder"]),
                            Balance = Convert.ToDecimal(dr["Balance"])
                        };
                        Console.WriteLine(wallet);
                    }
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
