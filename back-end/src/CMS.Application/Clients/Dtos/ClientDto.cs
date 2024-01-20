namespace CMS.Application.Clients.Dtos;

public sealed record ClientDto(string Id, string Name, string EmailAddress, string PhoneNumber,
    string HomeAddress)
{
    public static ClientDto Create(Client client) => new(
        client.Id.ToString(), 
        client.Name, 
        client.EmailAddress, 
        client.PhoneNumber, 
        client.HomeAddress);
}
