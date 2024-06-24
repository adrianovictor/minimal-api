using minimal_api.Domain.Common;

namespace minimal_api.Domain.Entities;

public class Role : Entity<Role>
{
    public string Name { get; set; } = default!;
    public string Description { get; set;} = default!;
    public virtual ICollection<User> Users { get; protected set; } = new List<User>();

    // protected Role() {}

    // public Role(string name, string description)
    // {
    //     Name = name;
    //     Description = description;
    // }    

    // public static Role Create(string name, string description) =>
    //     new(name, description);
}
