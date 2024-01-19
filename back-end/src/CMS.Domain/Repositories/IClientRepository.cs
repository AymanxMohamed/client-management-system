

namespace CMS.Domain.Repositories;

public interface IClientRepository
{
    Task<Client> CreateClientAsync(Client client, CancellationToken cancellationToken);
    Task<List<Client>> GetClientsAsync(CancellationToken cancellationToken);
    Task<Client> GetClientByIdAsync(Guid? id, CancellationToken cancellationToken);
    Task DeleteClientAsync(Guid? id, CancellationToken cancellationToken);
    Task UpdateClientAsync(Client client, CancellationToken cancellationToken);
}