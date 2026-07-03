using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(e => e.CurrentPosition)
               .IsRequired();

        builder.Property(e => e.Salary)
               .HasPrecision(18, 2);

        builder.HasOne(e => e.Department)
               .WithMany(d => d.Employees)
               .HasForeignKey(e => e.DepartmentId);

        builder.HasMany(e => e.PositionHistories)
               .WithOne(ph => ph.Employee)
               .HasForeignKey(ph => ph.EmployeeId);

        builder.HasMany(e => e.EmployeeProjects)
               .WithOne(ep => ep.Employee)
               .HasForeignKey(ep => ep.EmployeeId);
    }
}