using EmployeeManagement.Application.Services.Bonus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services.Bonus.Strategies;

    public class RegularEmployeeBonusStrategy : IBonusStrategy
    {
        public decimal CalculateBonus(decimal salary)
        {
            return salary * 0.10m;
        }
    }

