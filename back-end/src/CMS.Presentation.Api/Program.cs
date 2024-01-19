using CMS.Infrastructure;
using CMS.Infrastructure.Persistence;
using CMS.Presentation.Api.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

{
    app.UseCors("CorsPolicy");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

#region Database Seed
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        await context.Database.MigrateAsync();
        await ApplicationDbContextSeed.SeedAsync(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An Error occured during migration");
    }
}
#endregion

app.Run();