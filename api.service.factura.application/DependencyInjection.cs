using api.service.factura.application.commons.dtos;
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

        services.AddScoped<IValidator<ClienteRequestDto>, ClienteRequestDtoValidator>();
        services.AddScoped<IValidator<CategoriaRequestDto>, CategoriaRequestDtoValidator>();
        services.AddScoped<IValidator<ProductoRequestDto>, ProductoRequestDtoValidator>();
        services.AddScoped<IValidator<PedidoRequestDto>, PedidoRequestDtoValidator>();
        services.AddScoped<IValidator<PedidoDetalleRequestDto>, PedidoDetalleRequestDtoValidator>();
        services.AddScoped<IValidator<PagoRequestDto>, PagoRequestDtoValidator>();

        return services;
    }
}