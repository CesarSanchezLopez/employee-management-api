using EmployeeManagement.Application.Services.Bonus.Strategies;
using EmployeeManagement.Application.Services.Bonus.Interfaces;
using EmployeeManagement.Domain.Enums;

namespace EmployeeManagement.Application.Services.Bonus;

public class BonusStrategyFactory
{
    public IBonusStrategy Create(PositionType position)
    {
        return position switch
        {
            PositionType.Manager => new ManagerBonusStrategy(),
            _ => new RegularEmployeeBonusStrategy()
        };
    }
}