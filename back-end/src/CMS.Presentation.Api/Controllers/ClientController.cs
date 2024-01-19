using System.Net;
using CMS.Application.Clients.Commands.CreateClient;
using CMS.Application.Clients.Commands.DeleteClient;
using CMS.Application.Clients.Commands.UpdateClient;
using CMS.Application.Clients.Dtos;
using CMS.Application.Clients.Queries.GetClientById;
using CMS.Application.Clients.Queries.GetClients;
using CMS.Domain.Errors;
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

    [HttpDelete("DeleteClient/{clientId:guid}", Name = nameof(DeleteClient))]
    [ProducesResponseType(typeof(Result<Result>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result>> DeleteClient(Guid clientId, CancellationToken cancellationToken)
    {
        var command = new DeleteClientCommand(clientId);
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
    
    [HttpDelete("UpdateClient", Name = nameof(UpdateClient))]
    [ProducesResponseType(typeof(Result<Result>), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult> UpdateClient(UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return NoContent();
    }
    

    [HttpGet("GetClientById/{clientId:guid}", Name = nameof(GetClientById))]
    [ProducesResponseType(typeof(Result<ClientDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<ClientDto>>> GetClientById(Guid? clientId, 
        CancellationToken cancellationToken)
    {
        if (clientId is null)
            return NotFound(Result.Failure<ClientDto>(DomainErrors.Client.InvalidId));
        
        var query = new GetClientByIdQuery(clientId.Value);

        var result = await Sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet(nameof(GetClients), Name = nameof(GetClients))]
    [ProducesResponseType(typeof(Result<List<ClientDto>>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result<List<ClientDto>>>> GetClients(CancellationToken cancellationToken)
    {
        var query = new GetClientsQuery();

        var result = await Sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
    
}
