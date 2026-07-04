using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Infrastructure.Persistence.Context;

namespace EmployeeManagement.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (context.Departments.Any())
            return;

        // Departments
        var it = new Department
        {
            Name = "IT"
        };

        var hr = new Department
        {
            Name = "Human Resources"
        };

        var finance = new Department
        {
            Name = "Finance"
        };

        context.Departments.AddRange(it, hr, finance);

        // Projects
        var erp = new Project
        {
            Name = "ERP"
        };

        var crm = new Project
        {
            Name = "CRM"
        };

        var payroll = new Project
        {
            Name = "Payroll"
        };

        context.Projects.AddRange(erp, crm, payroll);

        // Employees
        var employee1 = new Employee
        {
            Name = "John Doe",
            Salary = 5000,
            CurrentPosition = PositionType.Developer,
            Department = it
        };

        var employee2 = new Employee
        {
            Name = "Jane Smith",
            Salary = 7000,
            CurrentPosition = PositionType.Manager,
            Department = hr
        };

        context.Employees.AddRange(employee1, employee2);

        // Guardar para generar los IDs
        await context.SaveChangesAsync();

        // Employee - Projects
        context.EmployeeProjects.AddRange(
            new EmployeeProject
            {
                EmployeeId = employee1.Id,
                ProjectId = erp.Id
            },
            new EmployeeProject
            {
                EmployeeId = employee1.Id,
                ProjectId = crm.Id
            },
            new EmployeeProject
            {
                EmployeeId = employee2.Id,
                ProjectId = payroll.Id
            });

        // Position History
        context.PositionHistories.AddRange(
            new PositionHistory
            {
                EmployeeId = employee1.Id,
                Position = "Junior Developer",
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2024, 1, 31)
            },
            new PositionHistory
            {
                EmployeeId = employee1.Id,
                Position = "Developer",
                StartDate = new DateTime(2024, 2, 1),
                EndDate = null
            },
            new PositionHistory
            {
                EmployeeId = employee2.Id,
                Position = "Manager",
                StartDate = new DateTime(2022, 6, 1),
                EndDate = null
            });

        await context.SaveChangesAsync();
    }
}