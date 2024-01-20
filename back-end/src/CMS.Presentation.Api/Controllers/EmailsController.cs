using System.Net;
using CMS.Application.Emails.Commands.SendEmail;
using CMS.Domain.Shared;
using CMS.Presentation.Api.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Api.Controllers;

public class EmailsController : ApiController
{
    private readonly ILogger<EmailsController> _logger;
    
    public EmailsController(ISender sender, ILogger<EmailsController> logger) : base(sender)
    {
        _logger = logger;
    }
    
    [HttpPost(nameof(SendEmail), Name = nameof(SendEmail))]
    [ProducesResponseType(typeof(Result), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Result>> SendEmail([FromBody]SendEmailRequest sendEmailRequest, 
        CancellationToken cancellationToken)
    {
        var command = sendEmailRequest.ToCommand();
        
        var result = await Sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}