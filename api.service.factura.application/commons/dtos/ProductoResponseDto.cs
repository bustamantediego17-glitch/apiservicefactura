namespace api.service.factura.application.commons.dtos;

public sealed record ProductoResponseDto(
    int ProductoId,
    string Nombre,
    decimal Precio,
    int CategoriaId
);
