using System.Net;
using CMS.Application.Clients.Dtos;
using CMS.Domain.Entities;
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

    [HttpPost(nameof(CreateClient), Name = nameof(CreateClient))]
    [ProducesResponseType(typeof(Result<ClientDto>), (int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<ClientDto>>> CreateClient(CreateClientRequest createClientRequest, 
        CancellationToken cancellationToken)
    {
        var command = createClientRequest.ToCommand();
        
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return CreatedAtRoute(nameof(GetClientById), new { clientId = result.Value.Id },
            Result.Success(result.Value));
    }

    [HttpGet("GetClientById/{clientId:guid}", Name = nameof(GetClientById))]
    [ProducesResponseType(typeof(Result<ClientDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Result<ClientDto>>> GetClientById(Guid? clientId, CancellationToken cancellationToken)
    {
        return Result.Failure<ClientDto>(Error.None);
    }
}
