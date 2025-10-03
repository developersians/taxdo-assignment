namespace TaxdoAssignment.Application.Shared;

public interface IEmailSender
{
    Task SendWelcomeEmailAsync(
        string userName,
        string receiver, 
        CancellationToken cancellationToken = default);

    //...
}
