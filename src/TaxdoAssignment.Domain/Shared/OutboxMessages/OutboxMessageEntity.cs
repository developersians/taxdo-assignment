namespace TaxdoAssignment.Domain.Shared;

public class OutboxMessageEntity
{
    private OutboxMessageEntity() { }

    public OutboxMessageEntity(
        string type,
        string content,
        DateTime occurredOn)
    {
        Id = Guid.NewGuid();
        Type = type;
        Content = content;
        OccurredOn = occurredOn;
    }

    public Guid Id { get; private set; }
    public string Type { get; private set; }
    public string Content { get; private set; }
    public DateTime OccurredOn { get; private set; }
    public DateTime? ProcessedOn { get; private set; }
    public string? Error { get; private set; }

    public void MarkAsProcessed()
    {
        ProcessedOn = DateTime.UtcNow;
    }

    public void MarkAsFailed(string error)
    {
        Error = error;
    }
}
