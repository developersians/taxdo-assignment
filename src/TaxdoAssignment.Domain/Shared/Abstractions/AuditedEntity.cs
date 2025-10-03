namespace TaxdoAssignment.Domain.Shared;

public class AuditedEntity : Entity
{
    public AuditedEntity()
    {
        CreatedAt = DateTime.UtcNow;
        UpdateTimestamp();
    }

    public DateTime CreatedAt { get; private set; }
    public DateTime LastUpdatedAt { get; private set; }

    public void UpdateTimestamp()
    {
        LastUpdatedAt = DateTime.UtcNow;
    }
}
