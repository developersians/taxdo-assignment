namespace TaxdoAssignment.Domain;

public sealed class UserEntity : AuditedEntity, IAggregateRoot
{
    private UserEntity() { }

    private UserEntity(
        Guid id,
        Name name,
        Email email,
        string passwordHash,
        bool isEmailUnique)
    {
        Id = id;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }

    public static UserEntity Create(
        Guid id,
        string name,
        string email,
        string passwordHash,
        bool isEmailUnique)
    {
        Name validName = new(name);
        Email validEmail = new(email, isEmailUnique);

        UserEntity entity = new(
            id,
            validName,
            validEmail,
            passwordHash,
            isEmailUnique);

        entity.AddDomainEvent(new UserCreatedEvent(name, validEmail));

        return entity;
    }
}
