using Common.Core._08.Domain.Enumerado;
using Common.Core._08.Domain.Model;

namespace API.Exemple.Core._08.Feature.Domain.Exemple.Models;

public class ExempleQueryModel : BaseQueryModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EGender Gender { get; set; }
    public ENotificationType Notification { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    /// <summary>
    /// ERole.cs
    /// RoleConstants.cs
    /// </summary>
    public List<string> Role { get; set; } = new List<string>();
}
