using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class LogConfig : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Date)
                .IsRequired();

            builder.Property(s => s.Level)
                .HasMaxLength(100);

            builder.Property(s => s.Message)
                .HasColumnType("nvarchar(max)");

            builder.Property(s => s.Logger)
                .HasMaxLength(300);
        }
    }
}
