using EF_Migration.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Migration.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Name).HasMaxLength(255); // nvarchar(255)
            builder.Property(x => x.Name)
                .HasColumnType("VarChar")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(x => x.course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseId)
                .IsRequired();

            builder.HasOne(x => x.instructor)
              .WithMany(x => x.Sections)
              .HasForeignKey(x=>x.InstructorId)
              .IsRequired(false);

            builder.HasOne(x=>x.schedule)
                .WithMany(x=>x.Sections)
                .HasForeignKey(x => x.ScheduleId)
                .IsRequired();

            //builder.HasMany(c => c.schedules)
            //    .WithMany(x => x.Sections)
            //    .UsingEntity<SectionSchedule>();

            builder.HasMany(c => c.students)
               .WithMany(x => x.sections)
               .UsingEntity<Enrollment>();

            builder.HasData(LoadSections());

            builder.ToTable("Sections");

        }

        private static Section[] LoadSections()
        {
            return new Section[]
            {
        new Section { Id = 1,  Name = "S_MA1", CourseId = 1, InstructorId = 1 , ScheduleId = 1, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00") },
        new Section { Id = 2,  Name = "S_MA2", CourseId = 1, InstructorId = 2 , ScheduleId = 3, StartTime = TimeSpan.Parse("14:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
        new Section { Id = 3,  Name = "S_PH1", CourseId = 2, InstructorId = 1 , ScheduleId = 4, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("15:00:00") },
        new Section { Id = 4,  Name = "S_PH2", CourseId = 2, InstructorId = 3 , ScheduleId = 1, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("12:00:00") },
        new Section { Id = 5,  Name = "S_CH1", CourseId = 3, InstructorId = 2 , ScheduleId = 1, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
        new Section { Id = 6,  Name = "S_CH2", CourseId = 3, InstructorId = 3 , ScheduleId = 2, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00") },
        new Section { Id = 7,  Name = "S_BI1", CourseId = 4, InstructorId = 4 , ScheduleId = 3, StartTime = TimeSpan.Parse("11:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
        new Section { Id = 8,  Name = "S_BI2", CourseId = 4, InstructorId = 5 , ScheduleId = 4, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
        new Section { Id = 9,  Name = "S_CS1", CourseId = 5, InstructorId = 4 , ScheduleId = 4, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
        new Section { Id = 10, Name = "S_CS2", CourseId = 5, InstructorId = 5 , ScheduleId = 3, StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("15:00:00") },
        new Section { Id = 11, Name = "S_CS3", CourseId = 5, InstructorId = 4 , ScheduleId = 5, StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("11:00:00") }
            };
        }

    }
}
