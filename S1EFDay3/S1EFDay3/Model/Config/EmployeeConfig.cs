using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            // one to one relationship by Fluent API
            builder.HasOne(e => e.Address)
                .WithOne(a => a.Employee)
                .HasForeignKey<Employee>(e => e.AddressId);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            // 5️ Index Self
            builder.HasIndex(e => e.Name);

            //1️ HasQueryFilter
            builder.HasQueryFilter(e=>!e.IsDeleted);
        }
    }
}
