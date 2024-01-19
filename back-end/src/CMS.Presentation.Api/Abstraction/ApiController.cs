using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Presentation.Api.Abstraction;

[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    protected readonly ISender Sender;
    public ApiController(ISender sender) => Sender = sender;
}