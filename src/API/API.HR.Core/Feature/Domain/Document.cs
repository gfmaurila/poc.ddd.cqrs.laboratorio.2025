namespace API.HR.Core.Feature.Domain;

public class Document
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[] FileData { get; set; }
    public DateTime UploadedAt { get; set; }
}
