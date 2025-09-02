using SStore.DAL;
using SStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace SStore.BLL
{
    public static class CustomerService
    {
        // Get All Customers
        public static List<Customer> GetAllCustomers()
        {
            var dataTable = DatabaseHelper.ExecuteSelect("SELECT * FROM Customers");
            List<Customer> customers = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                customers.Add(new Customer
                {
                    CustomerID = (int)row["CustomerID"],
                    FirstName = (string)row["FirstName"],
                    LastName = (string)row["LastName"],
                    Email = (string)row["Email"],
                    Phone = (string)row["Phone"],
                    City = row["City"] == DBNull.Value ? null : (string)row["City"],
                    StateName = row["StateName"] == DBNull.Value ? null : (string)row["StateName"],
                    ZipCode = row["ZipCode"] == DBNull.Value ? null : (string)row["ZipCode"],
                    Country = row["Country"] == DBNull.Value ? null : (string)row["Country"],
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? null : (DateTime?)row["CreatedAt"]
                });
            }

            return customers;
        }

        // Get Customer By ID
        public static Customer GetCustomerByID(int id)
        {
            var dataTable = DatabaseHelper.ExecuteSelect($"SELECT * FROM Customers WHERE CustomerID = {id}");
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            var row = dataTable.Rows[0];
            return new Customer
            {
                CustomerID = (int)row["CustomerID"],
                FirstName = (string)row["FirstName"],
                LastName = (string)row["LastName"],
                Email = (string)row["Email"],
                Phone = (string)row["Phone"],
                City = row["City"] == DBNull.Value ? null : (string)row["City"],
                StateName = row["StateName"] == DBNull.Value ? null : (string)row["StateName"],
                ZipCode = row["ZipCode"] == DBNull.Value ? null : (string)row["ZipCode"],
                Country = row["Country"] == DBNull.Value ? null : (string)row["Country"],
                CreatedAt = row["CreatedAt"] == DBNull.Value ? null : (DateTime?)row["CreatedAt"]
            };
        }

        // Add Customer
        public static bool AddCustomer(Customer customer)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"INSERT INTO Customers (FirstName, LastName, Email, Phone, City, StateName, ZipCode, Country, CreatedAt) " +
                $"VALUES ('{customer.FirstName}', '{customer.LastName}', '{customer.Email}', '{customer.Phone}', " +
                $"'{customer.City}', '{customer.StateName}', '{customer.ZipCode}', '{customer.Country}', " +
                $"'{customer.CreatedAt:yyyy-MM-dd HH:mm:ss}')"
            );
            return result;
        }

        // Update Customer
        public static bool UpdateCustomer(Customer customer)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"UPDATE Customers SET " +
                $"FirstName = '{customer.FirstName}', " +
                $"LastName = '{customer.LastName}', " +
                $"Email = '{customer.Email}', " +
                $"Phone = '{customer.Phone}', " +
                $"City = '{customer.City}', " +
                $"StateName = '{customer.StateName}', " +
                $"ZipCode = '{customer.ZipCode}', " +
                $"Country = '{customer.Country}', " +
                $"CreatedAt = '{customer.CreatedAt:yyyy-MM-dd HH:mm:ss}' " +
                $"WHERE CustomerID = {customer.CustomerID}"
            );
            return result;
        }

        // Delete Customer
        public static bool DeleteCustomer(int id)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"DELETE FROM Customers WHERE CustomerID = {id}"
            );
            return result;
        }
    }
}
