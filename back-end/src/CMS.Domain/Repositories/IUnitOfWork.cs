namespace CMS.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}