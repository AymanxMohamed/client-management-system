namespace CMS.Application.Clients.Commands;

public record CreateClientCommand(
    string Name, string EmailAddress, string PhoneNumber, string HomeAddress) : ICommand<Client>
{
    public Client ToClient() => Client.Create(Name, EmailAddress, PhoneNumber, HomeAddress);
}
