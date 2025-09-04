using EF_Migration.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Name).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.Name).HasColumnType("VarChar").HasMaxLength(50).IsRequired();

            builder.Property(x => x.Location).HasColumnType("VarChar").HasMaxLength(50).IsRequired();


            builder.HasData(LoadOffices());

            builder.ToTable("Offices");

        }

        private static Office[] LoadOffices()
        {
            return new Office[] {
                new Office { Id = 1, Name = "Off_05", Location = "building A" },
                new Office { Id = 2, Name = "Off_12", Location = "building B" },
                new Office { Id = 3, Name = "Off_32", Location = "Adminstration" },
                new Office { Id = 4, Name = "Off_44", Location = "IT Department" },
                new Office { Id = 5, Name = "Off_43", Location = "IT Department" }
                };
        }
    }
}
