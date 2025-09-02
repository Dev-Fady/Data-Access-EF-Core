using SStore.DAL;
using SStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SStore.BLL
{
    public static class ProcductService
    {
        //Get All Products
        public static List<Product> GettAllProducts()
        {
            var dataTable = DatabaseHelper.ExecuteSelect("Select * From Products");
            List<Product> products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(new Product
                {
                    Id = (int)row["ProductID"],
                    Name = (String)row["ProductName"],
                    price = (decimal)row["Price"],
                    IdCategory = (int)row["CategoryID"],
                    stock= (int)row["Stock"],
                    CreatedAt = (DateTime)row["CreatedAt"]
                });
            }
            return products;
        }

        //Get Product By ID
        public static Product GetProductByID(int id)
        {
            var dataTable = DatabaseHelper.ExecuteSelect($"Select * From Products Where ProductID = {id}");
            if (dataTable.Rows.Count==0)
            {
                return null;
            }            
            var row = dataTable.Rows[0];
            return new Product
            { 
                Id = (int)row["ProductID"],
                Name = (String)row["ProductName"],
                price = (decimal)row["Price"],
                IdCategory = (int)row["CategoryID"],
                stock = (int)row["Stock"],
                CreatedAt = (DateTime)row["CreatedAt"]
            };
        }
        // Add Product 
        public static bool AddProduct(Product product)
        {
            bool Result = DatabaseHelper.ExecuteDML(
                $"INSERT INTO Products (ProductName, Price, CategoryID, Stock, CreatedAt) " +
                $"VALUES ('{product.Name}', {product.price}, {product.IdCategory}, {product.stock}, '{product.CreatedAt:yyyy-MM-dd HH:mm:ss}')"
            );
            return Result;
        }


        // Update Product
        public static bool UpdateProduct(Product product)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"UPDATE Products " +
                $"SET ProductName = '{product.Name}', " +
                $"Price = {product.price}, " +
                $"CategoryID = {product.IdCategory}, " +
                $"Stock = {product.stock}, " +
                $"CreatedAt = '{product.CreatedAt}' " +
                $"WHERE ProductID = {product.Id}"
            );
            return result;
        }

        // Delete Product
        public static bool DeleteProduct(int Id)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"DELETE FROM Products WHERE ProductID = {Id}"
            );
            return result;
        }

    }
}
