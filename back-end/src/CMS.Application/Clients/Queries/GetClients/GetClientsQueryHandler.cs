﻿namespace CMS.Application.Clients.Queries.GetClients;

public class GetClientsQueryHandler : IQueryHandler<GetClientsQuery, List<Client>>
{
    private readonly IClientRepository _clientRepository;

    public GetClientsQueryHandler(IClientRepository clientRepository) => _clientRepository = clientRepository;

    public Task<Result<List<Client>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Success(_clientRepository.GetClients()));
    }
}