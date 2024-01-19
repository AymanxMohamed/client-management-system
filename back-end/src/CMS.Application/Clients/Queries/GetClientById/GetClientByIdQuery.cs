namespace CMS.Application.Clients.Queries.GetClientById;

public record GetClientByIdQuery(Guid ClientId) : IQuery<Client>;
