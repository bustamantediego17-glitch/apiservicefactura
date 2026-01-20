namespace api.service.factura.application.commons.dtos;

public sealed record PagoResponseDto(
    int PagoId,
    int PedidoId,
    string Metodo,
    decimal Monto
);
