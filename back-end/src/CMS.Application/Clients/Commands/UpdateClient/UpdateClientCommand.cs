namespace CMS.Application.Clients.Commands.UpdateClient;

public record UpdateClientCommand(Guid Id,
    string Name, string EmailAddress, string PhoneNumber, string HomeAddress) : ICommand<Client>
{
    public Client ToClient() => Client.Create(Id, Name, EmailAddress, PhoneNumber, HomeAddress);
}
