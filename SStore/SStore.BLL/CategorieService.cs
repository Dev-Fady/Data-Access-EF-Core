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
    public class CategorieService
    {
        // Get All Categories
        public static List<Categorie> GetAllCategories()
        {
            var dataTable = DatabaseHelper.ExecuteSelect("SELECT * FROM Categories");
            List<Categorie> categories = new List<Categorie>();

            foreach (DataRow row in dataTable.Rows)
            {
                categories.Add(new Categorie
                {
                    Id = (int)row["CategoryID"],
                    Name = (string)row["CategoryName"],
                    Description = (string)row["DescriptionCat"]
                });
            }

            return categories;
        }

        // Get Category By ID
        public static Categorie GetCategoryByID(int id)
        {
            var dataTable = DatabaseHelper.ExecuteSelect($"SELECT * FROM Categories WHERE CategoryID = {id}");
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            var row = dataTable.Rows[0];
            return new Categorie
            {
                Id = (int)row["CategoryID"],
                Name = (string)row["CategoryName"],
                Description = (string)row["DescriptionCat"]
            };
        }

        // Add Category
        public static bool AddCategory(Categorie category)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"INSERT INTO Categories (CategoryName, DescriptionCat) " +
                $"VALUES ('{category.Name}', '{category.Description}')"
            );
            return result;
        }

        // Update Category
        public static bool UpdateCategory(Categorie category)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"UPDATE Categories " +
                $"SET CategoryName = '{category.Name}', " +
                $"DescriptionCat = '{category.Description}' " +
                $"WHERE CategoryID = {category.Id}"
            );
            return result;
        }

        // Delete Category
        public static bool DeleteCategory(int id)
        {
            bool result = DatabaseHelper.ExecuteDML(
                $"DELETE FROM Categories WHERE CategoryID = {id}"
            );
            return result;
        }
    }
}
