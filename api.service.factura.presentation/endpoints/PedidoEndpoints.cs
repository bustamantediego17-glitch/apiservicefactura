using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class PedidoEndpoints
{
    public static RouteGroupBuilder MapPedido(this RouteGroupBuilder builder)
    {
        builder.MapPost("/", Insert)
            .WithTags("Pedidos")
            .WithSummary("Crea un pedido")
            .WithDescription("Crea un pedido con sus detalles. El total se calcula a partir de los detalles.");
        return builder;
    }

    static async Task<Results<Created<PedidoResponseDto>, ValidationProblem, BadRequest, ProblemHttpResult>> Insert(
        [FromBody] PedidoRequestDto pedidoRequest,
        IValidator<PedidoRequestDto> validator,
        IPedidoHandler pedidoHandler)
    { 
        var validation = await validator.ValidateAsync(pedidoRequest);
        if (!validation.IsValid)
        {
            return TypedResults.ValidationProblem(validation.ToDictionary());
        }

        var pedido = await pedidoHandler.Insert(pedidoRequest);

        if (pedido == null)
        {
            return TypedResults.BadRequest();
        }

        return TypedResults.Created($"/v1/pedido/{pedido.PedidoId}", pedido);
    }
}