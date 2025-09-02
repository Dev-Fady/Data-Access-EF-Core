using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SStore.DAL
{
    public static class DatabaseHelper
    {
        static SqlConnection sqlConnection;

        static DatabaseHelper()
        {
            //1-Create SqlConnection
            sqlConnection =
               new SqlConnection("Server = . ; database = OnlineRetailDB ; Integrated Security = SSPI ; TrustServerCertificate = True  ");
        }

        public static DataTable ExecuteSelect(string query)
        {
            //2-Create SqlCommand[Select]
            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                //3-DataTable
                DataTable dataTable = new DataTable();

                //4-Execute SqlCommand Using SqlDataAdapter
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    //5-Fill DataTable
                    sqlDataAdapter.Fill(dataTable);
                }

                return dataTable;
            }
        }

        public static bool ExecuteDML(string command)
        {
            //2-Create SqlCommand[DML => Insert/Update/Delete]
            using (SqlCommand sqlCommand = new SqlCommand(command, sqlConnection))
            {
                //3-Open Connection
                sqlConnection.Open();

                //4-Execute Over Database
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                //5-Close Connection
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }
    }
}
