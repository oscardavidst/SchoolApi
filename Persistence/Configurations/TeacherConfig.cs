using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(t => t.Id);
            builder.HasMany(t => t.Scores).WithOne().HasForeignKey(t => t.IdTeacher);

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.CreatedBy)
                .HasMaxLength(30);

            builder.Property(t => t.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
