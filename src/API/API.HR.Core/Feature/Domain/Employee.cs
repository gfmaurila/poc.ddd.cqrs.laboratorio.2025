namespace API.HR.Core.Feature.Domain;

public class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Address { get; set; }

    // Relacionamentos
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    public Guid PositionId { get; set; }
    public Position Position { get; set; }

    public ICollection<Benefit> Benefits { get; set; }
    public ICollection<PerformanceReview> PerformanceReviews { get; set; }
    public ICollection<LeaveRequest> LeaveRequests { get; set; }
    public ICollection<Attendance> Attendances { get; set; }
}
