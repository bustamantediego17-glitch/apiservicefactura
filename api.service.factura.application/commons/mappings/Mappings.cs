using api.service.factura.application.commons.dtos;
using api.service.factura.domain.clases;
using Riok.Mapperly.Abstractions;

namespace api.service.factura.application.commons.mappings;

[Mapper]
public partial class Mappings
{
    public partial ClienteResponseDto ToResponseDto(Cliente cliente);
    public partial List<ClienteResponseDto> ToResponseDto(List<Cliente> clientes);
    public partial ProductoResponseDto ToResponseDto(Producto produto);
    public partial List<ProductoResponseDto> ToResponseDto(List<Producto> productos);
    public partial CategoriaResponseDto ToResponseDto(Categoria categoria);
    public partial List<CategoriaResponseDto> ToResponseDto(List<Categoria> categorias);
    public partial PedidoResponseDto ToResponseDto(Pedido pedido);
    public partial PedidoDetalleResponseDto ToResponseDto(PedidoDetalle pedidoDetalle);
    public partial PagoResponseDto ToResponseDto(Pago pago);
    public partial List<PagoResponseDto> ToResponseDto(List<Pago> pagos);


    public partial Cliente ToRequestDto(ClienteRequestDto clienteRequestDto);
    public partial Producto ToRequestDto(ProductoRequestDto productoRequestDto);
    public partial Categoria ToRequestDto(CategoriaRequestDto categoriaRequestDto);
    public partial Pedido ToRequestDto(PedidoRequestDto pedidoRequestDto);
    public partial Pago ToRequestDto(PagoRequestDto pagoRequestDto);

    private static void AfterMapping(PedidoRequestDto source, Pedido target)
    {
        target.Total = source.PedidoDetalles.Sum(x => x.Cantidad * x.PrecioUnitario);
    }

    public partial PedidoDetalle ToRequestDto(PedidoDetalleRequestDto pedidoDetalleRequestDto);

    private static void AfterMapping(PedidoDetalleRequestDto source, PedidoDetalle target)
    { 
        target.Subtotal = source.Cantidad * source.PrecioUnitario;
    }
}