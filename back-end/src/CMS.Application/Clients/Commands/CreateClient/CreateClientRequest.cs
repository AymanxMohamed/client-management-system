namespace CMS.Application.Clients.Commands.CreateClient;

public sealed record CreateClientRequest(string Name, string EmailAddress, string PhoneNumber, string HomeAddress)
{
    public CreateClientCommand ToCommand() => new CreateClientCommand(Name, EmailAddress, PhoneNumber, HomeAddress);
}