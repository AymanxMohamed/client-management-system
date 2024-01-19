namespace CMS.Application.Clients.Commands.UpdateClient;

public class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand, Client>
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Client>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = request.ToClient();

        _clientRepository.UpdateClient(client, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return client;
    }
}

