using System.ComponentModel.DataAnnotations;

namespace api.service.factura.application.commons.dtos;

public sealed record ProductoRequestDto(
    [property: Required, StringLength(100)] string Nombre,
    [property: Range(0.01, 999999999)] decimal Precio,
    [property: Range(1, int.MaxValue)] int CategoriaId
);
