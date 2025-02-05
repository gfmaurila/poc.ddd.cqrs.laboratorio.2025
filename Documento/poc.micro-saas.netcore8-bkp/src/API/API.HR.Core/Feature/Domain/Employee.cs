using Common.Core._08.Domain;
using Common.Core._08.Domain.Interface;

namespace API.HR.Core.Feature.Domain;

public class Employee : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime? TerminationDate { get; set; }
    public decimal CurrentSalary { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
    public List<SalaryHistory> SalaryHistories { get; set; } = new();
    public List<Promotion> Promotions { get; set; } = new();
    public List<Address> Addresses { get; set; } = new();
}

public class Department : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public Guid ManagerId { get; set; }
    public Employee Manager { get; set; }
    public List<Employee> Employees { get; set; } = new();
}

public class SalaryHistory : BaseEntity, IAggregateRoot
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public decimal Salary { get; set; }
    public DateTime EffectiveDate { get; set; }
    public SalaryChangeType ChangeType { get; set; }
}

public class Promotion : BaseEntity, IAggregateRoot
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string NewTitle { get; set; }
    public decimal NewSalary { get; set; }
    public DateTime PromotionDate { get; set; }
    public string Reason { get; set; }
}

public class Address : BaseEntity, IAggregateRoot
{
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string Type { get; set; } // Residencial, Comercial
    public string Street { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}

public class FinancialControl : BaseEntity, IAggregateRoot
{
    public DateTime MonthReference { get; set; }
    public decimal TotalPayroll { get; set; }
    public decimal Taxes { get; set; }
    public decimal Benefits { get; set; }
    public decimal Adjustments { get; set; }
}

public enum SalaryChangeType
{
    Adjustment,
    Promotion,
    CollectiveIncrease
}
