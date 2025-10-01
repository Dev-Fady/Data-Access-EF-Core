using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace S1EFDay3.Model.Config
{
    public class DepartmentProjectConfig : IEntityTypeConfiguration<DepartmentProject>
    {
        public void Configure(EntityTypeBuilder<DepartmentProject> builder)
        {
            builder.HasKey(dp => new { dp.DepartmentId, dp.ProjectId });


           builder.HasOne(dp=>dp.Department)
                .WithMany(d=>d.DepartmentProjects)
                .HasForeignKey(dp=>dp.DepartmentId);

            builder.HasOne(dp=>dp.Project)
                .WithMany(p=>p.DepartmentProjects)
                .HasForeignKey(dp=>dp.ProjectId);
        }
    }
}
