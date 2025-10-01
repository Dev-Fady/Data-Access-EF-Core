using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1EFDay3.Model.Config
{
    partial class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // one to one relationship by Fluent API
            builder.HasOne(e => e.Employee)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(e => e.EmployeeId);
        }
    }
}
