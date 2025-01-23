namespace API.Auth.Net08.Domain.User.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; set; }
    public string Password { get; set; }
}
