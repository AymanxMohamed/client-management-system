using CMS.Application.Clients.Dtos;

namespace CMS.Application.Clients.Extensions;

public static class ClientExtensions
{
    public static ClientDto ToClientDto(this Client client) => ClientDto.Create(client);
}