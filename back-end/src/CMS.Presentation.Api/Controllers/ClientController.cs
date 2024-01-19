using CMS.Presentation.Api.Abstraction;
using MediatR;

namespace CMS.Presentation.Api.Controllers;

public class ClientController : ApiController
{
    private readonly ILogger<ClientController> _logger;
    
    public ClientController(ISender sender, ILogger<ClientController> logger) : base(sender)
    {
        _logger = logger;
    }
}
