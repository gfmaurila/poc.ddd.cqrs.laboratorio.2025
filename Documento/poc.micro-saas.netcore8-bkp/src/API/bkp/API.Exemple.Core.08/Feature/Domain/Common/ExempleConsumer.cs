using Common.Core._08.Domain.Enumerado;

namespace API.Exemple.Core._08.Feature.Domain.Common;

public class ExempleConsumer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EGender Gender { get; set; }
    public ENotificationType Notification { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<string> Role { get; set; } = new List<string>();
    public bool Status { get; set; } = true;
    public DateTime? DtInsert { get; set; } = DateTime.UtcNow;
    public Guid? DtInsertId { get; set; }
    public DateTime? DtUpdate { get; set; }
    public Guid? DtUpdateId { get; set; }
    public DateTime? DtDelete { get; set; }
    public Guid? DtDeleteId { get; set; }
}