namespace API.HR.Core.Feature.Domain;

public class PerformanceReview
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public DateTime ReviewDate { get; set; }
    public string Reviewer { get; set; }
    public string Comments { get; set; }
    public int Rating { get; set; } // Exemplo: 1 a 5
}