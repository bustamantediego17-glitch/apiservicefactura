using System.ComponentModel.DataAnnotations;

namespace api.service.factura.application.commons.dtos;

public sealed record ClienteRequestDto(
    [property: Required, StringLength(150)] string Nombre,
    [property: StringLength(200)] string? Direccion,
    [property: StringLength(20)] string? Telefono
);
