using Microsoft.EntityFrameworkCore;
using S1EFDay3.Model;

namespace S1EFDay3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                if (!context.Departments.Any())
                {
                    var hr = new Department { Name = "HR" };
                    var it = new Department { Name = "IT" };

                    var p1 = new Project { Name = "ERP System" };
                    var p2 = new Project { Name = "Mobile App" };

                    var e1 = new Employee { Name = "Ahmed Ali", BirthDate = new DateTime(1990, 5, 1), Salary = 8000, Department = hr };
                    var e2 = new Employee { Name = "Sara Mohamed", BirthDate = new DateTime(1995, 7, 15), Salary = 10000, Department = it };

                    var a1 = new Address { City = "Cairo", Governament = "Cairo", Employee = e1 };
                    var a2 = new Address { City = "Alexandria", Governament = "Alex", Employee = e2 };

                    var dp1 = new DepartmentProject { Department = hr, Project = p1, CreateDate = DateTime.Now };
                    var dp2 = new DepartmentProject { Department = it, Project = p2, CreateDate = DateTime.Now };

                    context.Departments.AddRange(hr, it);
                    context.Projects.AddRange(p1, p2);
                    context.Employees.AddRange(e1, e2);
                    context.Addresses.AddRange(a1, a2);
                    context.DepartmentProjects.AddRange(dp1, dp2);

                    context.SaveChanges();
                }
            }

            //using (var context=new AppDbContext())
            //{
            //    //context.Projects.ExecuteUpdate(a=>a.SetProperty(p=>p.Name,p=>"New Project Name"));
            //    context.Projects.ExecuteDelete();

            //    context.Projects.Where(x=>x.Id==2)
            //        .ExecuteUpdate(a=>
            //        a.SetProperty(p=>p.Name,p=>"New Project Name"));

            //}

            using (var context = new AppDbContext())
            {
                context.Employees.Where(x => x.Id == 2)
                    .ExecuteUpdate(a =>
                    a.SetProperty(p => p.IsDeleted, p => true));

                // 1️ IgnoreQueryFilter

                var allEmployees = context.Employees.IgnoreQueryFilters().ToList();
                foreach (var item in allEmployees)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.Salary} - {item.IsDeleted}");
                }


                // 3️ Stop Tracking Over Context on livel Query
                var employees = context.Employees 
                    .AsNoTracking()
                    .ToList();
                foreach (var item in employees)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.Salary}");
                }
                // 4️ AsNoTrackingWithIdentityResolution
                var employees2 = context.Employees
                    .Include(e => e.Department)
                    .AsNoTrackingWithIdentityResolution()
                    .ToList();
                foreach (var item in employees2)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.Salary} - {item.Department.Name} - {item.IsDeleted}");
                }
            }
        }
    }
}
