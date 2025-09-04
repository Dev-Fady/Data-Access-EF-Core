using EF_Migration.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Migration.Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Name).HasMaxLength(255); // nvarchar(255)
            builder.Property(x=>x.Name).HasColumnType("VarChar").HasMaxLength(255).IsRequired();

            builder.Property(x => x.Price).HasPrecision(15, 2);

            builder.HasData(LoadCourses());

            builder.ToTable("Courses");

        }

        private static Course[] LoadCourses()
        {
            return new Course[] {
                new Course { Id = 1, Name = "Mathematics", Price = 1000.00m },
                new Course { Id = 2, Name = "Physics", Price = 2000.00m },
                new Course { Id = 3, Name = "Chemistry", Price = 1500.00m },
                new Course { Id = 4, Name = "Biology", Price = 1200.00m },
                new Course { Id = 5, Name = "Computer Science", Price = 3000.00m }
                };
        }
    }
}
