namespace api.service.factura.application.commons.dtos;

public sealed record PedidoResponseDto(
    int PedidoId,
    int ClienteId,
    DateTime? Fecha,
    decimal? Total,
    List<PedidoDetalleResponseDto> PedidoDetalles
);
