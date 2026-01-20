using System.ComponentModel.DataAnnotations;

namespace api.service.factura.application.commons.dtos;

public sealed record PedidoRequestDto(
    [property: Range(1, int.MaxValue)] int ClienteId,
    DateTime? Fecha,
    [property: Required, MinLength(1)] List<PedidoDetalleRequestDto> PedidoDetalles
);
