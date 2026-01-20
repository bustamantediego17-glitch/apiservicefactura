using api.service.factura.application.commons.dtos;
using api.service.factura.application.commons.mappings;
using api.service.factura.application.ifeatures;
using api.service.factura.infrastructure.context.pedido;

namespace api.service.factura.application.features;

public class PedidoHandler : IPedidoHandler
{
    private readonly Mappings _mapper;
    private readonly IPedidoContext _context;

    public PedidoHandler(IPedidoContext context)
    {
        _mapper = new Mappings();
        _context = context;
    }

    public async Task<PedidoResponseDto?> Insert(PedidoRequestDto pedidoRequest)
    {
        var pedido = _mapper.ToRequestDto(pedidoRequest);
        
        var pedidoResponse = await _context.InsertAsync(pedido);

        return pedidoResponse != null ? _mapper.ToResponseDto(pedidoResponse) : null;
    }
}