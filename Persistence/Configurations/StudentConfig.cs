using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Scores).WithOne().HasForeignKey(s => s.IdStudent);

            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.CreatedBy)
                .HasMaxLength(30);

            builder.Property(s => s.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
