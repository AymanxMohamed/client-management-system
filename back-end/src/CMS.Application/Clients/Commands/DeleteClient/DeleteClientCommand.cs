namespace CMS.Application.Clients.Commands.DeleteClient;

public record DeleteClientCommand(Guid Id) : ICommand;