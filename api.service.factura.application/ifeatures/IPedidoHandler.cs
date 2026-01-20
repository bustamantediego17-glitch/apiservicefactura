using api.service.factura.application.commons.dtos;

namespace api.service.factura.application.ifeatures;

public interface IPedidoHandler
{
    Task<PedidoResponseDto?> Insert(PedidoRequestDto pedidoRequest);
}