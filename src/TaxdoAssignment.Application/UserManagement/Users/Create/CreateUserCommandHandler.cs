using MediatR;
using TaxdoAssignment.Application.Shared;
using TaxdoAssignment.Domain;
using TaxdoAssignment.Domain.Shared;

namespace TaxdoAssignment.Application;

internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository,
    IGuidGenerator guidGenerator,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        bool isEmailExists = await userRepository.ExistsAsync(
            predicate: p => p.Email.Value.ToLower() == command.Email.ToLower(),
            cancellationToken: cancellationToken);

        var newId = guidGenerator.Generate();

        UserEntity entity = UserEntity.Create(
            id: newId,
            name: command.Name,
            email: command.Email,
            passwordHash: passwordHasher.Hash(command.Password),
            isEmailUnique: !isEmailExists
        );

        await userRepository.AddAsync(entity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return newId;
    }
}
