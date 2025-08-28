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

                //    walletToInsert.Id = (int)insertCommand.ExecuteScalar();

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
                //using (SqlCommand sqlCommand = conn.CreateCommand())
                //{
                    ////conn.Open();
                    //SqlTransaction transaction = conn.BeginTransaction();
                    //sqlCommand.Transaction = transaction;

                    //try
                    //{
                    //    sqlCommand.CommandText = "UPDATE Wallets SET Balance = Balance - 1000 WHERE Id = 9";
                    //    sqlCommand.ExecuteNonQuery();

                    //    sqlCommand.CommandText = "UPDATE Wallets SET Balance = Balance + 1000 WHERE Id = 2";
                    //    sqlCommand.ExecuteNonQuery();

                    //    transaction.Commit();
                    //    Console.WriteLine("Transaction of transfer completed successfully");
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine("Error during transaction: " + ex.Message);
                    //    try
                    //    {
                    //        transaction.Rollback();
                    //        Console.WriteLine("Transaction rolled back");
                    //    }
                    //    catch (Exception rollbackEx)
                    //    {
                    //        Console.WriteLine("Error in rollback: " + rollbackEx.Message);
                    //    }
                    //}
                    //finally
                    //{
                    //    string sql = "SELECT * FROM Wallets";
                    //    using (SqlCommand command = new SqlCommand(sql, conn))
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while (reader.Read())
                    //        {
                    //            var wallet = new Wallet
                    //            {
                    //                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    //                Holder = reader.GetString(reader.GetOrdinal("Holder")),
                    //                Balance = reader.GetDecimal(reader.GetOrdinal("Balance"))
                    //            };
                    //            Console.WriteLine(wallet);
                    //        }
                    //    }
                    //    conn.Close();
                    //}
                //}
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
                //Console.WriteLine("=======================================");
                #region Execute DataAdapter in inmemory offline access
                //string sqlAdapter = "SELECT * FROM Wallets";
                //using (SqlDataAdapter adapter = new SqlDataAdapter(sqlAdapter, conn))
                //{
                //    DataTable dt=new DataTable();
                //    adapter.Fill(dt);
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        var wallet = new Wallet
                //        {
                //            Id = Convert.ToInt32(dr["Id"]),
                //            Holder = Convert.ToString(dr["Holder"]),
                //            Balance = Convert.ToDecimal(dr["Balance"])
                //        };
                //        Console.WriteLine(wallet);
                //    }
                //}
                #endregion
            }

            #region DisConnected Mode [Select] 
            ////1-- Create SqlConnection
            //SqlConnection sqlConnection = new SqlConnection(connectionString);

            ////2-- Create SqlCommand[Select, Update, Delete, Insert]
            //SqlCommand sqlCommand = new SqlCommand("Select * From Wallets", sqlConnection);

            ////3-- DataTable , DataSet
            //DataTable dataTable = new DataTable();

            ////4-- Execute SqlCommand Using SqlDataAdapter
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            ////5-- SqlDataAdapter.Fill(DataTable)
            //sqlDataAdapter.Fill(dataTable);

            ////6-- Convert DataTable List of Object
            //List<Wallet> wallets = new List<Wallet>();
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    Wallet wallet = new Wallet();

            //    wallet.Id=(int)dataRow["ID"];
            //    wallet.Holder = (string)dataRow["Holder"];
            //    wallet.Balance = (decimal)dataRow["Balance"];

            //    wallets.Add(wallet);
            //}

            ////7-- Display Data
            //foreach (var item in wallets)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region DisConnected Mode [Insert , Update , Delete]
            //1-- Create SqlConnection
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //2-- Create SqlCommand [Select]
            SqlCommand sqlCommand = new SqlCommand("Select * From Wallets", sqlConnection);

            //3-- DataTable
            DataTable dataTable = new DataTable();

            //4-- SqlDataAdapter
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            // ✅ مهم: نربط الـ DataAdapter بالأوامر (Insert / Update / Delete)
            // أسهل طريقة: SqlCommandBuilder
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlDataAdapter);

            //5-- Fill DataTable
            sqlDataAdapter.Fill(dataTable);

            //6-- Convert DataTable to List<Wallet>
            List<Wallet> wallets = new List<Wallet>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Wallet wallet = new Wallet();

                wallet.Id = (int)dataRow["ID"];
                wallet.Holder = (string)dataRow["Holder"];
                wallet.Balance = (decimal)dataRow["Balance"];

                wallets.Add(wallet);
            }

            //7-- Display Data (قبل التعديل)
            Console.WriteLine("---- Before Update ----");
            foreach (var item in wallets)
            {
                Console.WriteLine(item);
            }

            // 🔹 Example: Modify Row
            foreach (DataRow item in dataTable.Rows)
            {
                if ((int)item["ID"] == 17)
                {
                    item["Holder"] = "Updated Holder 17";
                    item["Balance"] = 2000;
                }
            }

            // 🔹 Example: Insert New Row
            DataRow newRow = dataTable.NewRow();
            newRow["Holder"] = "New Wallet Holder";
            newRow["Balance"] = 5000;
            dataTable.Rows.Add(newRow);

            //// 🔹 Example: Delete Row
            //foreach (DataRow item in dataTable.Rows)
            //{
            //    if ((int)item["ID"] == 18)
            //    {
            //        item.Delete();
            //        break;
            //    }
            //}

            // نشوف الـ RowState (هل اتغير/اتضاف/اتمسح؟)
            //foreach (DataRow item in dataTable.Rows)
            //{
            //    Console.WriteLine($"Row ID={item["ID", DataRowVersion.Original]} - State={item.RowState}");
            //}

            // 🔹 هنا بنحفظ التغييرات للـ Database
            sqlDataAdapter.Update(dataTable);

            Console.WriteLine("Changes Saved To Database Successfully!");

            //7-- Display Data (بعد التعديل)
            wallets.Clear();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState != DataRowState.Deleted) // علشان لو الصف اتمسح
                {
                    Wallet wallet = new Wallet();
                    wallet.Id = (int)dataRow["ID"];
                    wallet.Holder = (string)dataRow["Holder"];
                    wallet.Balance = (decimal)dataRow["Balance"];
                    wallets.Add(wallet);
                }
            }

            Console.WriteLine("---- After Update ----");
            foreach (var item in wallets)
            {
                Console.WriteLine(item);
            }

            ////- Create Insert , Update , Delete Command

            //sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO PRODUCTS VALUES (@NAME , @PRICE , @QTY)", sqlConnection);
            //sqlDataAdapter.InsertCommand.Parameters.Add("@NAME", SqlDbType.NVarChar, 50, "Name");
            //sqlDataAdapter.InsertCommand.Parameters.Add("@PRICE", SqlDbType.Float, 0, "Price");
            //sqlDataAdapter.InsertCommand.Parameters.Add("@QTY", SqlDbType.Int, 0, "Qty");

            ////sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE PRODUCTS SET NAME = @NAME , PRICE = @PRICE , QTY = @QTY WHERE ID = @ID", sqlConnection);
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@NAME", SqlDbType.NVarChar, 50, "Name");
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@PRICE", SqlDbType.Float, 0, "Price");
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@QTY", SqlDbType.Int, 0, "Qty");
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            //sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM PRODUCTS WHERE ID = @ID", sqlConnection);
            //sqlDataAdapter.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            //Excute Over Database
            //sqlDataAdapter.Update(dataTable);
#endregion

            Console.ReadKey();
        }
    }
}
