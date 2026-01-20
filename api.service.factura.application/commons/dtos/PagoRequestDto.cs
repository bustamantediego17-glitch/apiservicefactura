using System.ComponentModel.DataAnnotations;

namespace api.service.factura.application.commons.dtos;

public sealed record PagoRequestDto(
    [property: Range(1, int.MaxValue)] int PedidoId,
    [property: Required, StringLength(30)] string Metodo,
    [property: Range(0.01, 999999999)] decimal Monto
);
