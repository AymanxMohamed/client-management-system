using CMS.Application.Abstractions.Services;

namespace CMS.Application.Emails.Commands.SendEmail;

public class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
{
    private readonly IEmailService _emailService;
    public SendEmailCommandHandler(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public async Task<Result> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        await _emailService.SendEmailAsync(request.ReceiverEmail, request.Subject, request.Body);
        return Result.Success();
    }
}

