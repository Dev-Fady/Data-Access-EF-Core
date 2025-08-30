using Entity_Types_Mapping.Data;
using Entity_Types_Mapping.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entity_Types_Mapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var context = new AppDbContext();

            var ItemsInOrders = context.OrderDetails.Where(x => x.OrderId == 1);
            Console.WriteLine(ItemsInOrders.Count());

            //foreach (var item in context.Products)
            //{
            //    Console.WriteLine(item.Name+"\t"+item.Id +"\t"+
            //        item.UnitPrice+"\t" + item.Description+
            //        "\t"+"*********"+"\n"+item.Snapshot.Version+" "+
            //        item.Snapshot.LoadeAt+"*********");
            //}

            var OrderDetailsView = context.orderWithDetails;
            foreach (var item in OrderDetailsView)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=======================");

            var orderBillDetails = new AppDbContext().Set<OrderBill>()
                .FromSqlInterpolated($"Select * From GetOrderBill({1}) ").ToList();
            foreach (var item in orderBillDetails)
            {
                Console.WriteLine(item);
            }
        }
    }
}
