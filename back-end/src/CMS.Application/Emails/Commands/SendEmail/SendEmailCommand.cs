namespace CMS.Application.Emails.Commands.SendEmail;

public record SendEmailCommand(string ReceiverEmail, string Subject, string Body) : ICommand;
