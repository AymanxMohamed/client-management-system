

namespace CMS.Domain.Repositories;

public interface IClientRepository
{
    Task<Client> CreateClientAsync(Client client, CancellationToken cancellationToken);
    List<Client> GetClients();
    Task<Client> GetClientByIdAsync(Guid? id, CancellationToken cancellationToken);
    Task DeleteClientAsync(Guid? id, CancellationToken cancellationToken);
    void UpdateClient(Client client, CancellationToken cancellationToken);
}