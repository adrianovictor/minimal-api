using minimal_api.Domain.Common;

namespace minimal_api.Domain.Entities;

public class User : Entity<User>
{
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Email { get; set; } = default!;
    public Role Role { get;  set; } = default!;
    public int RoleId { get; set; }

    // protected User() { }

    // public User(string username, string passwordHash, string email, Role role)
    // {
    //     Username = username;
    //     PasswordHash = passwordHash;
    //     Email = email;
    //     Role = role;
    //     RoleId = role.Id;
    // }

    // public static User Create(string username, string password, string email, Role role) =>
    //     new(username, password, email, role);

}
