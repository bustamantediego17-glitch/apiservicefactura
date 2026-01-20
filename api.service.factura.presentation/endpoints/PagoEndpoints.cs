using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class PagoEndpoints
{
    public static RouteGroupBuilder MapPago(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll)
            .WithTags("Pagos")
            .WithSummary("Lista todos los pagos")
            .WithDescription("Devuelve los registros de pagos asociados a pedidos.");

        builder.MapGet("/{id:int}", GetById)
            .WithTags("Pagos")
            .WithSummary("Obtiene un pago por id");

        builder.MapPost("/", Insert)
            .WithTags("Pagos")
            .WithSummary("Registra un pago")
            .WithDescription("Registra un pago para un pedido. Un pedido solo puede tener un pago.");

        return builder;
    }

    static async Task<Results<Ok<List<PagoResponseDto>>, ProblemHttpResult>> GetAll(IPagoHandler pagoHandler)
    {
        return TypedResults.Ok(await pagoHandler.GetAll());
    }

    static async Task<Results<Ok<PagoResponseDto>, NotFound<string>, ProblemHttpResult>> GetById(
        [FromRoute] int id,
        IPagoHandler pagoHandler)
    {
        var pago = await pagoHandler.GetById(id);
        if (pago.PagoId == 0)
        {
            return TypedResults.NotFound("No encontrado");
        }

        return TypedResults.Ok(pago);
    }

    static async Task<Results<Created<PagoResponseDto>, ValidationProblem, ProblemHttpResult>> Insert(
        [FromBody] PagoRequestDto pagoRequest,
        IValidator<PagoRequestDto> validator,
        IPagoHandler pagoHandler)
    {
        var validation = await validator.ValidateAsync(pagoRequest);
        if (!validation.IsValid)
        {
            return TypedResults.ValidationProblem(validation.ToDictionary());
        }

        var pago = await pagoHandler.Insert(pagoRequest);
        return TypedResults.Created($"/v1/pago/{pago.PagoId}", pago);
    }
}
