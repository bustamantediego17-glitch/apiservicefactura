using api.service.factura.application.commons.dtos;
using api.service.factura.application.ifeatures;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.service.factura.presentation.endpoints;

public static class CategoriaEndpoints
{
    public static RouteGroupBuilder MapCategoria(this RouteGroupBuilder builder)
    {
        builder.MapGet("/", GetAll)
            .WithTags("Categorias")
            .WithSummary("Lista todas las categorías")
            .WithDescription("Devuelve las categorías disponibles para clasificar productos.");

        builder.MapGet("/{id:int}", GetById)
            .WithTags("Categorias")
            .WithSummary("Obtiene una categoría por id");

        builder.MapPost("/", Insert)
            .WithTags("Categorias")
            .WithSummary("Crea una categoría")
            .WithDescription("Crea una nueva categoría. El nombre es obligatorio.");

        return builder;
    }

    static async Task<Results<Ok<List<CategoriaResponseDto>>, ProblemHttpResult>> GetAll(ICategoriaHandler categoriaHandler)
    {
        return TypedResults.Ok(await categoriaHandler.GetAll());
    }

    static async Task<Results<Ok<CategoriaResponseDto>, NotFound<string>, ProblemHttpResult>> GetById(
        [FromRoute] int id,
        ICategoriaHandler categoriaHandler)
    {
        var categoria = await categoriaHandler.GetById(id);
        if (categoria.CategoriaId == 0)
        {
            return TypedResults.NotFound("No encontrado");
        }

        return TypedResults.Ok(categoria);
    }

    static async Task<Results<Created<CategoriaResponseDto>, ValidationProblem, ProblemHttpResult>> Insert(
        [FromBody] CategoriaRequestDto categoriaRequest,
        IValidator<CategoriaRequestDto> validator,
        ICategoriaHandler categoriaHandler)
    {
        var validation = await validator.ValidateAsync(categoriaRequest);
        if (!validation.IsValid)
        {
            return TypedResults.ValidationProblem(validation.ToDictionary());
        }

        var categoria = await categoriaHandler.Insert(categoriaRequest);
        return TypedResults.Created($"/v1/categoria/{categoria.CategoriaId}", categoria);
    }
}
