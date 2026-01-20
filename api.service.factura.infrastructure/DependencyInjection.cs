using api.service.factura.infrastructure.context;
using api.service.factura.infrastructure.context.cliente;
using api.service.factura.infrastructure.context.categoria;
using api.service.factura.infrastructure.context.pedido;
using api.service.factura.infrastructure.context.pago;
using api.service.factura.infrastructure.context.producto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.factura.infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, 
                                                    IConfiguration configuration)
    {
        services.AddDbContext<FacturaDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                              builder => builder.MigrationsAssembly(typeof(FacturaDbContext).Assembly.FullName)
                                                .EnableRetryOnFailure(
                                                    maxRetryCount: 5,
                                                    maxRetryDelay: TimeSpan.FromSeconds(10),
                                                    errorCodesToAdd: null
                                                ))
        );

        services.AddScoped(typeof(IContextGeneral<>), typeof(ContextGeneral<>));
        services.AddScoped<IClienteContext, ClienteContext>();
        services.AddScoped<ICategoriaContext, CategoriaContext>();
        services.AddScoped<IProductoContext, ProductoContext>();
        services.AddScoped<IPedidoContext, PedidoContext>();
        services.AddScoped<IPagoContext, PagoContext>();

        return services;
    }
}