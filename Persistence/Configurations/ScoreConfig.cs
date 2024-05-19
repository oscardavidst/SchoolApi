using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ScoreConfig : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Scores");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.Value)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(s => s.CreatedBy)
                .HasMaxLength(30);

            builder.Property(s => s.LastModifiedBy)
                .HasMaxLength(30);
        }
    }
}
