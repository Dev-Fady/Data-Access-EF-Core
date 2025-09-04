using EF_Migration.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Name).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.Name).HasColumnType("VarChar").HasMaxLength(255).IsRequired();

            builder.ToTable("Instructors");

            builder.ToTable("Students");

            builder.HasData(LoadStudents());
        }

        private static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                 new Student() { Id = 1, Name = "Fatima Ali" },
                 new Student() { Id = 2, Name = "Noor Saleh" },
                 new Student() { Id = 3, Name = "Omar Youssef" },
                 new Student() { Id = 4, Name = "Huda Ahmed" },
                 new Student() { Id = 5, Name = "Amira Tariq" },
                 new Student() { Id = 6, Name = "Zainab Ismail" },
                 new Student() { Id = 7, Name = "Yousef Farid" },
                 new Student() { Id = 8, Name = "Layla Mustafa" },
                 new Student() { Id = 9, Name = "Mohammed Adel" },
                 new Student() { Id = 10, Name = "Samira Nabil" }
            };
        }
    }
}
