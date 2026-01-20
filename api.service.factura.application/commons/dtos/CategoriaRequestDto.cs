using System.ComponentModel.DataAnnotations;

namespace api.service.factura.application.commons.dtos;

public sealed record CategoriaRequestDto(
    [property: Required, StringLength(80)] string Nombre
);
