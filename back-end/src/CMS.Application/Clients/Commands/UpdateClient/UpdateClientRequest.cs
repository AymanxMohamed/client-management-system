namespace CMS.Application.Clients.Commands.UpdateClient;

public sealed record UpdateClientRequest(Guid Id, string Name, string EmailAddress, string PhoneNumber, string HomeAddress)
{
    public UpdateClientCommand ToCommand() => new (Id, Name, EmailAddress, PhoneNumber, HomeAddress);
}