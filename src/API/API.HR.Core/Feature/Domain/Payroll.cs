namespace API.HR.Core.Feature.Domain;

public class Payroll
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public DateTime PaymentDate { get; set; }
    public decimal GrossSalary { get; set; }
    public decimal NetSalary { get; set; }
    public decimal Deductions { get; set; }
    public string Notes { get; set; }
}
