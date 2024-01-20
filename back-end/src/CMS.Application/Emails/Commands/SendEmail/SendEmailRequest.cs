namespace CMS.Application.Emails.Commands.SendEmail;

public sealed record SendEmailRequest(string ReceiverEmail, string Subject, string Body)
{
    public SendEmailCommand ToCommand() => new (ReceiverEmail, Subject, Body);
}