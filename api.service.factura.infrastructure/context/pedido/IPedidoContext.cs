using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.pedido;

public interface IPedidoContext
{
    Task<Pedido?> InsertAsync(Pedido pedido);
}