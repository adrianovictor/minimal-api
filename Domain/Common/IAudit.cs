namespace minimal_api.Domain.Common;

public interface IAudit
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
