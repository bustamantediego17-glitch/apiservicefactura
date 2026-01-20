using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace api.service.factura.infrastructure.context;

public sealed class FacturaDbContextFactory : IDesignTimeDbContextFactory<FacturaDbContext>
{
    public FacturaDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connection = config.GetConnectionString("DefaultConnection")
            ?? config["ConnectionStrings:DefaultConnection"]
            ?? string.Empty;

        var optionsBuilder = new DbContextOptionsBuilder<FacturaDbContext>();
        optionsBuilder.UseNpgsql(connection);

        return new FacturaDbContext(optionsBuilder.Options);
    }
}
