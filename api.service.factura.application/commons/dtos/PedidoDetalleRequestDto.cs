using System.ComponentModel.DataAnnotations;

namespace api.service.factura.application.commons.dtos;

public sealed record PedidoDetalleRequestDto(
    [property: Range(1, int.MaxValue)] int ProductoId,
    [property: Range(1, int.MaxValue)] int Cantidad,
    [property: Range(0.01, 999999999)] decimal PrecioUnitario
);
