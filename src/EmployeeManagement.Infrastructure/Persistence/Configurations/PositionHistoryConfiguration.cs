using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Persistence.Configurations;

public class PositionHistoryConfiguration : IEntityTypeConfiguration<PositionHistory>
{
    public void Configure(EntityTypeBuilder<PositionHistory> builder)
    {
        builder.ToTable("PositionHistories");

        builder.HasKey(ph => ph.Id);

        builder.Property(ph => ph.Position)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(ph => ph.StartDate)
               .IsRequired();

        builder.Property(ph => ph.EndDate);

        builder.HasOne(ph => ph.Employee)
               .WithMany(e => e.PositionHistories)
               .HasForeignKey(ph => ph.EmployeeId);
    }
}