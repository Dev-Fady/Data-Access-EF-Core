using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S1Ado.net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Connected Mode [Select]

            ////1 - Create SqlConnection
            //SqlConnection sqlConnection = 
            //    new SqlConnection("Server = . ; database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True  ");

            ////2-Create SqlCommand[Select, Update, Delete, Insert]
            //SqlCommand sqlCommand = new SqlCommand("select * From Wallets ",sqlConnection);

            ////3-Open Connection
            //sqlConnection.Open();

            ////4-Execute Over DataBase
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //List<Wallet> list = new List<Wallet>();
            //while (sqlDataReader.Read()) { 
            //    Wallet wallet = new Wallet();
            //    wallet.Id = (int)sqlDataReader["Id"];
            //    wallet.Holder = (string)sqlDataReader["Holder"];
            //    wallet.Balance = (decimal)sqlDataReader["Balance"];

            //    list.Add(wallet);

            //}

            ////5-Receive Result
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            ////6-Close Connection
            //sqlConnection.Close();
            #endregion

            #region Connected Mode [Insert]

            //        //1 - Create SqlConnection 
            //        SqlConnection sqlConnection =
            //            new SqlConnection("Server = . ; database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True  ");

            //        //2-Create SqlCommand[Select, Update, Delete, Insert]
            //        Wallet wallet1 = new Wallet();
            //        wallet1.Holder = "Test";
            //        wallet1.Balance = 5550;
            //        //wallet1.Id = 24;
            //        SqlCommand sqlCommand = new SqlCommand(
            //"INSERT INTO Wallets (Holder, Balance) VALUES (@Holder, @Balance)",
            //sqlConnection);

            //        //sqlCommand.Parameters.AddWithValue("@Id", wallet1.Id);
            //        sqlCommand.Parameters.AddWithValue("@Holder", wallet1.Holder);
            //        sqlCommand.Parameters.AddWithValue("@Balance", wallet1.Balance);
            //        //3-Open Connection
            //        sqlConnection.Open();

            //        //4-Execute Over DataBase

            //       int rowsAffected= sqlCommand.ExecuteNonQuery();

            //        if (rowsAffected>0)
            //        {
            //            Console.WriteLine("Record inserted successfully");

            //            SqlCommand selectCmd = new SqlCommand("SELECT * FROM Wallets", sqlConnection);
            //            SqlDataReader sqlDataReader = selectCmd.ExecuteReader();

            //            List<Wallet> list = new List<Wallet>();
            //            while (sqlDataReader.Read())
            //            {
            //                Wallet wallet = new Wallet();
            //                wallet.Id = (int)sqlDataReader["Id"];
            //                wallet.Holder = (string)sqlDataReader["Holder"];
            //                wallet.Balance = (decimal)sqlDataReader["Balance"];

            //                list.Add(wallet);

            //            }

            //            //5-Receive Result
            //            foreach (var item in list)
            //            {
            //                Console.WriteLine(item);
            //            }
            //        }

            //        //6-Close Connection
            //        sqlConnection.Close();
            #endregion

            #region Connected Mode [Update]

            ////1 - Create SqlConnection 
            //SqlConnection sqlConnection =
            //    new SqlConnection("Server = . ; database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True  ");

            ////2-Create SqlCommand[Select, Update, Delete, Insert]
            //Wallet wallet1 = new Wallet();
            //wallet1.Holder = "Test 44";
            //wallet1.Balance = 440;
            //wallet1.Id = 24;
            //SqlCommand sqlCommand = new SqlCommand(
            //    "UPDATE Wallets SET Holder = @Holder, Balance = @Balance WHERE Id = @Id", sqlConnection);

            //sqlCommand.Parameters.AddWithValue("@Id", wallet1.Id);
            //sqlCommand.Parameters.AddWithValue("@Holder", wallet1.Holder);
            //sqlCommand.Parameters.AddWithValue("@Balance", wallet1.Balance);
            ////3-Open Connection
            //sqlConnection.Open();

            ////4-Execute Over DataBase

            //int rowsAffected = sqlCommand.ExecuteNonQuery();

            //if (rowsAffected > 0)
            //{
            //    Console.WriteLine("Record inserted successfully");

            //    SqlCommand selectCmd = new SqlCommand("SELECT * FROM Wallets", sqlConnection);
            //    SqlDataReader sqlDataReader = selectCmd.ExecuteReader();

            //    List<Wallet> list = new List<Wallet>();
            //    while (sqlDataReader.Read())
            //    {
            //        Wallet wallet = new Wallet();
            //        wallet.Id = (int)sqlDataReader["Id"];
            //        wallet.Holder = (string)sqlDataReader["Holder"];
            //        wallet.Balance = (decimal)sqlDataReader["Balance"];

            //        list.Add(wallet);

            //    }

            //    //5-Receive Result
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            ////6-Close Connection
            //sqlConnection.Close();
            #endregion

            #region Connected Mode [Delete]

            ////1 - Create SqlConnection 
            //SqlConnection sqlConnection =
            //    new SqlConnection("Server = . ; database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True  ");

            ////2-Create SqlCommand[Select, Update, Delete, Insert]
            //SqlCommand sqlCommand = new SqlCommand(
            //    "Delete Wallets  WHERE Id = 23", sqlConnection);


            ////3-Open Connection
            //sqlConnection.Open();

            ////4-Execute Over DataBase

            //int rowsAffected = sqlCommand.ExecuteNonQuery();

            //if (rowsAffected > 0)
            //{
            //    Console.WriteLine("Record inserted successfully");

            //    SqlCommand selectCmd = new SqlCommand("SELECT * FROM Wallets", sqlConnection);
            //    SqlDataReader sqlDataReader = selectCmd.ExecuteReader();

            //    List<Wallet> list = new List<Wallet>();
            //    while (sqlDataReader.Read())
            //    {
            //        Wallet wallet = new Wallet();
            //        wallet.Id = (int)sqlDataReader["Id"];
            //        wallet.Holder = (string)sqlDataReader["Holder"];
            //        wallet.Balance = (decimal)sqlDataReader["Balance"];

            //        list.Add(wallet);

            //    }

            //    //5-Receive Result
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            ////6-Close Connection
            //sqlConnection.Close();
            #endregion

            #region Connected Mode [Stored Procedures]

            ////1 - Create SqlConnection
            //SqlConnection sqlConnection =
            //    new SqlConnection("Server = . ; database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True  ");

            ////2-Create SqlCommand[Select, Update, Delete, Insert]
            //SqlCommand sqlCommand = new SqlCommand("GetAllWallets", sqlConnection);

            ////3-Open Connection
            //sqlConnection.Open();

            ////4-Execute Over DataBase
            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            //List<Wallet> list = new List<Wallet>();
            //while (sqlDataReader.Read())
            //{
            //    Wallet wallet = new Wallet();
            //    wallet.Id = (int)sqlDataReader["Id"];
            //    wallet.Holder = (string)sqlDataReader["Holder"];
            //    wallet.Balance = (decimal)sqlDataReader["Balance"];

            //    list.Add(wallet);

            //}

            ////5-Receive Result
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            ////6-Close Connection
            //sqlConnection.Close();
            #endregion

            #region Disconnected Mode

            ////1-Create SqlConnection
            //SqlConnection sqlConnection =
            //    new SqlConnection("Server = . ; database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True  ");


            ////2-Create SqlCommand[Select]
            //SqlCommand sqlCommand = new SqlCommand("select * From Wallets ", sqlConnection);


            ////3-DataTable DataSet
            //DataTable dataTable = new DataTable();

            ////4-Execute SqlCommand Using SqlDataAdapter
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            ////5-SqlDataAdapter.Fill(DataTable)
            //sqlDataAdapter.Fill(dataTable);

            ////6-Convert DataTable List of Object
            //List<Wallet> list = new List<Wallet>();
            //foreach (DataRow dataRow in dataTable.Rows)
            //{
            //    Wallet wallet = new Wallet();
            //    wallet.Id = (int)dataRow["Id"];
            //    wallet.Balance = (decimal)dataRow["Balance"];
            //    wallet.Holder = (string)dataRow["Holder"];

            //    list.Add(wallet);
            //}

            //////Deleted Row
            ////foreach (DataRow item in dataTable.Rows)
            ////{
            ////    if ((int)item["Id"] == 20)
            ////    {
            ////        item.Delete();
            ////        break;
            ////    }

            ////}

            //// Add Row
            //DataRow dataRow1 = dataTable.NewRow();

            //dataRow1["Holder"] = "HOHOHO16";
            //dataRow1["Balance"] = 1470;

            ////Modified Row
            //foreach (DataRow item in dataTable.Rows)
            //{
            //    if ((int)item["Id"] == 10)
            //    {
            //        item["Holder"] = "NOOOOOOOOOOOOOUUUUUUUUUUR";
            //        item["Balance"] = 1754;
            //    }
            //}

            //dataTable.Rows.Add(dataRow1);

            //// create Insert , Update , Delete Command 

            //sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Wallets (Holder, Balance) VALUES (@Holder, @Balance)",sqlConnection);
            //sqlDataAdapter.InsertCommand.Parameters.Add("@Holder", SqlDbType.NVarChar, 100, "Holder");
            //sqlDataAdapter.InsertCommand.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");


            //sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE Wallets SET Holder = @Holder, Balance = @Balance WHERE Id = @Id",sqlConnection);
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@Holder", SqlDbType.NVarChar, 100, "Holder");
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@Balance", SqlDbType.Decimal, 0, "Balance");
            //sqlDataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");


            //sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Wallets WHERE Id = @Id", sqlConnection);
            //sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");


            ////7-Display Data
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (DataRow item in dataTable.Rows)
            //{
            //    Console.WriteLine(item.RowState);
            //}

            //// 8- Excute over DataBase  
            //sqlDataAdapter.Update(dataTable);
            #endregion
        }
    }
}
