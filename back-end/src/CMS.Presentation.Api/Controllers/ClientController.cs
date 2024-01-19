using CMS.Application.Clients.Commands;
using CMS.Application.Clients.Dtos;
using CMS.Domain.Shared;
using CMS.Presentation.Api.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Api.Controllers;

public class ClientController : ApiController
{
    private readonly ILogger<ClientController> _logger;
    
    public ClientController(ISender sender, ILogger<ClientController> logger) : base(sender)
    {
        _logger = logger;
    }

    public async Task<ActionResult<Result<ClientDto>>> CreateClient(CreateClientRequest createClientRequest, 
        CancellationToken cancellationToken)
    {
        var command = createClientRequest.ToCommand();
        
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Created("", Result.Success(result.Value.ToString()));
    }
}
