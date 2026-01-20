using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context.pedido;

public class PedidoContext : IPedidoContext
{ 
    private readonly IContextGeneral<Pedido> _context;
    private readonly IContextGeneral<Cliente> _contextCliente;
    private readonly IContextGeneral<Producto> _contextProducto;

    public PedidoContext(IContextGeneral<Pedido> context,
                         IContextGeneral<Cliente> contextCliente,
                         IContextGeneral<Producto> contextProducto)
    {
        _context = context;
        _contextCliente = contextCliente;
        _contextProducto = contextProducto;
    }

    public async Task<Pedido?> InsertAsync(Pedido pedido)
    { 
        Console.WriteLine(pedido.Fecha);

        var cliente = await _contextCliente.GetById(pedido.ClienteId);

        if (cliente == null)
        {
            return null;
        }

        foreach (var pedidoDetalle in pedido.PedidoDetalles)
        { 
            var producto = await _contextProducto.GetById(pedidoDetalle.ProductoId);

            if (producto == null)
            {
                return null;
            }
        }

        return await _context.Add(pedido);
    }
}