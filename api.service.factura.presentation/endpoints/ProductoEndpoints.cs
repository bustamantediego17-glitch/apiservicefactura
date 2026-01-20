using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class ProductoEndpoints
{
    public static RouteGroupBuilder MapProducto(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll)
            .WithTags("Productos")
            .WithSummary("Lista productos")
            .WithDescription("Devuelve el catálogo de productos.");

        builder.MapGet("/{id:int}", GetById)
            .WithTags("Productos")
            .WithSummary("Obtiene un producto por id");

        builder.MapPost("/", Insert)
            .WithTags("Productos")
            .WithSummary("Crea un producto")
            .WithDescription("Crea un producto. Nombre, precio y categoriaId son obligatorios.");
        return builder;
    }

    static async Task<Results<Ok<List<ProductoResponseDto>>, 
                              ProblemHttpResult>> GetAll(IProductoHandler productoHandler)
    {
        return TypedResults.Ok(await productoHandler.GetAll());
    }

    static async Task<Results<Ok<ProductoResponseDto>, 
                              NotFound<string>,
                              ProblemHttpResult>> GetById([FromRoute] int id, 
                                                          IProductoHandler productoHandler)
    {
        var producto = await productoHandler.GetById(id);

        if (producto.ProductoId == 0)
        {
            return TypedResults.NotFound("No encontrado");
        }

        return TypedResults.Ok(producto);
    }

    static async Task<Results<Created<ProductoResponseDto>, ValidationProblem, ProblemHttpResult>> Insert(
        [FromBody] ProductoRequestDto productoRequest,
        IValidator<ProductoRequestDto> validator,
        IProductoHandler productoHandler)
    {
        var validation = await validator.ValidateAsync(productoRequest);
        if (!validation.IsValid)
        {
            return TypedResults.ValidationProblem(validation.ToDictionary());
        }

        var producto = await productoHandler.Insert(productoRequest);
        return TypedResults.Created($"/v1/producto/{producto.ProductoId}", producto);
    }
}