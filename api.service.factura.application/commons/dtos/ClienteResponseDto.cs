namespace api.service.factura.application.commons.dtos;

public sealed record ClienteResponseDto(
    int ClienteId,
    string Nombre,
    string? Direccion,
    string? Telefono
);
