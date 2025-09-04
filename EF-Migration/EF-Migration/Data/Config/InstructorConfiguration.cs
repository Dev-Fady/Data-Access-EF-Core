using EF_Migration.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Name).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.Name).HasColumnType("VarChar").HasMaxLength(255).IsRequired();

            builder.ToTable("Instructors");

            builder.HasData(LoadInstructor());

            // one To one (office to Instructor)
            builder.HasOne(x => x.office)
                .WithOne(x => x.Instructor)
                .HasForeignKey<Instructor>(x => x.OfficeId)
                .IsRequired(false);
        }

        private static Instructor[] LoadInstructor()
        {
            return new Instructor[] {
                new Instructor { Id = 1, Name = "Ahmed Abdullah" ,OfficeId=1},
                new Instructor { Id = 2, Name = "Yasmeen Mohammed" ,OfficeId=2},
                new Instructor { Id = 3, Name = "Khalid Hassan" ,OfficeId=3},
                new Instructor { Id = 4, Name = "Nadia Ali",OfficeId = 4},
                new Instructor { Id = 5, Name = "Omar Ibrahim",OfficeId=5}
                };
        }
    }
}
