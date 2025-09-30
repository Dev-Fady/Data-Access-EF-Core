using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using S1EFDay2.Models;

namespace S1EFDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OnlineRetailDBContext context = new OnlineRetailDBContext();
            #region EagerLoading
            //var dept = context.Orders
            //    .Include(o => o.Customer)
            //    .Include(o => o.OrderItems)
            //        .ThenInclude(oi => oi.Product)
            //    .SelectMany(o => o.OrderItems.Select(oi => new
            //    {
            //        o.OrderId,
            //        CustomerName = o.Customer.FirstName,
            //        oi.Product.ProductName,
            //        oi.Quantity,
            //        oi.Price
            //    }))
            //    .ToList();
            //foreach (var order in dept)
            //    Console.WriteLine(order);
            #endregion

            #region NoTracking
            //var emps1 = context.Products.Select(a => new { a.ProductName, a.ProductId }).First(a => a.ProductId == 3);//NoTracking
            ////var emps1 = context.Products.Select(a => new { a.ProductName, a.ProductId, a.Price }).First(a => a.ProductId == 3);//NoTracking

            ////var emps2 = context.Products.Select(a => new { a.ProductName, a.ProductId}).First(a => a.ProductId == 3);
            //Console.WriteLine(context.Entry(emps2).State);

            //var emps3 = context.Products.AsNoTracking().Select(a => a).First(a => a.ProductId == 3);//NoTracking
            //Console.WriteLine(context.Entry(emps3).State);

            //var emps4 = context.Products.Select(a => a).First(a => a.ProductId == 3);//Tracking
            //Console.WriteLine(context.Entry(emps4).State);


            #endregion

            #region  Lazy Loading N + 1 Problem [Solved With Eager Loading]
            //var categories = context.Categories.ToList(); // 1 + N [Number Of Categories]

            //foreach (var category in categories)
            //{
            //    Console.WriteLine($"{category.CategoryId} - {category.CategoryName}");
            //    Console.WriteLine("--------------------------------------");

            //    foreach (var product in category.Products)
            //    {
            //        Console.WriteLine($"\t {product.ProductId} - {product.ProductName} - {product.Price}");
            //    }

            //    Console.WriteLine("--------------------------------------");
            //}
            #endregion

            #region Sol  Lazy Loading N + 1 Problem [Solved With Eager Loading]
            //var categories = context.Categories
            //    .Include(c => c.Products)
            //    .ToList();

            //foreach (var category in categories)
            //{
            //    Console.WriteLine($"{category.CategoryId} - {category.CategoryName}");
            //    Console.WriteLine("--------------------------------------");

            //    foreach (var product in category.Products)
            //    {
            //        Console.WriteLine($"\t {product.ProductId} - {product.ProductName} - {product.Price}");
            //    }

            //    Console.WriteLine("--------------------------------------");
            //}
            #endregion
        }
    }
}
