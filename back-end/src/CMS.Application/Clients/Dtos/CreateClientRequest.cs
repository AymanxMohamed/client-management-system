using CMS.Application.Clients.Commands;

namespace CMS.Application.Clients.Dtos;

public sealed record CreateClientRequest(string Name, string EmailAddress, string PhoneNumber, string HomeAddress)
{
    public CreateClientCommand ToCommand() => new CreateClientCommand(Name, EmailAddress, PhoneNumber, HomeAddress);
}