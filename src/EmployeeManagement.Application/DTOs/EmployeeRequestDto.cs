using EmployeeManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs;

    public class EmployeeRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public PositionType CurrentPosition { get; set; }

        public decimal Salary { get; set; }
    }

