using api.service.factura.application.features;
using api.service.factura.application.ifeatures;
using api.service.factura.application.validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace api.service.factura.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteHandler, ClienteHandler>();
        services.AddScoped<ICategoriaHandler, CategoriaHandler>();
        services.AddScoped<IProductoHandler, ProductoHandler>();
        services.AddScoped<IPedidoHandler, PedidoHandler>();
        services.AddScoped<IPagoHandler, PagoHandler>();

        services.AddScoped<IValidator<commons.dtos.ClienteRequestDto>, ClienteRequestDtoValidator>();
        services.AddScoped<IValidator<commons.dtos.CategoriaRequestDto>, CategoriaRequestDtoValidator>();
        services.AddScoped<IValidator<commons.dtos.ProductoRequestDto>, ProductoRequestDtoValidator>();
        services.AddScoped<IValidator<commons.dtos.PedidoRequestDto>, PedidoRequestDtoValidator>();
        services.AddScoped<IValidator<commons.dtos.PedidoDetalleRequestDto>, PedidoDetalleRequestDtoValidator>();
        services.AddScoped<IValidator<commons.dtos.PagoRequestDto>, PagoRequestDtoValidator>();

        return services;
    }
}