using MediatR;
using TaxdoAssignment.Application.Shared;
using TaxdoAssignment.Domain;

namespace TaxdoAssignment.Application;

public class UserCreatedEventHandler(IEmailSender emailSender)
    : INotificationHandler<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        await emailSender.SendWelcomeEmailAsync(
            userName: notification.Name,
            receiver: notification.Email,
            cancellationToken: cancellationToken);
    }
}
