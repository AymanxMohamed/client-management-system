using CMS.Application.Clients.Dtos;
using CMS.Application.Clients.Extensions;

namespace CMS.Application.Clients.Commands;

public class CreateClientCommandHandler : ICommandHandler<CreateClientCommand, Client>
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Client>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = request.ToClient();

        var createdClient = await _clientRepository.CreateClientAsync(client, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return createdClient;
    }
}