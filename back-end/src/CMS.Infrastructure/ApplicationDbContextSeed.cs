using System.Collections;
using System.Reflection;
using System.Text.Json;
using CMS.Domain.Entities;
using CMS.Infrastructure.Persistence;

namespace CMS.Infrastructure;

public static class ApplicationDbContextSeed
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        var index = path?.IndexOf(@"\CMS", StringComparison.OrdinalIgnoreCase);

        if (index is not null && index != -1)
        {
            path = path?[..index.Value];
            path = @$"{path}\CMS.Infrastructure\Persistence\Data\clients.json";
        }
        
        if (!context.Clients.Any())
        {
            var clientsData = await File.ReadAllTextAsync(path!);
            var clients = JsonSerializer.Deserialize<List<Client>>(clientsData);
            if (clients != null)
                await context.Clients.AddRangeAsync(clients);

            if (context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}