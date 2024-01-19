using System.Data.Entity;
using CMS.Domain.Entities;
using CMS.Domain.Repositories;

namespace CMS.Infrastructure.Persistence.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context) => _context = context;
    
    public async Task<Client> CreateClientAsync(Client client, CancellationToken cancellationToken)
    {
        return (await _context.Clients.AddAsync(client, cancellationToken)).Entity;
    }

    public List<Client> GetClients()
    {
        return _context.Clients.ToList();
    }

    public Task<Client> GetClientByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id), "Client Id cannot be null.");

        var client = _context.Clients.FirstOrDefault(x => x.Id == id)!;
        
        return Task.FromResult(client);
    }

    public async Task DeleteClientAsync(Guid? id, CancellationToken cancellationToken)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id), "Client Id cannot be null.");
        }

        var clientToDelete = await _context.Clients
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (clientToDelete != null)
        {
            _context.Clients.Remove(clientToDelete);
        }
    }

    public void UpdateClient(Client client, CancellationToken cancellationToken)
    {
        _context.Clients.Update(client);
    }
}