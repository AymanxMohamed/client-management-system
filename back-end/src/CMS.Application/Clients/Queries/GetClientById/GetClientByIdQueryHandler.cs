namespace CMS.Application.Clients.Queries.GetClientById;

public class GetClientByIdQueryHandler : IQueryHandler<GetClientByIdQuery, Client>
{
    private readonly IClientRepository _clientRepository;

    public GetClientByIdQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Result<Client>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _clientRepository.GetClientByIdAsync(request.ClientId, cancellationToken);
    }
}