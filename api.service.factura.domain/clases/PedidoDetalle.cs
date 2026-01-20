using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("pedido_detalle", Schema = "poo")]
public partial class PedidoDetalle : BaseEntity
{
    [Key]
    [Column("detalle_id")]
    public int DetalleId { get; set; }

    [Column("pedido_id")]
    public int PedidoId { get; set; }

    [Column("producto_id")]
    public int ProductoId { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [Column("precio_unitario")]
    public decimal PrecioUnitario { get; set; }

    [Column("subtotal")]
    public decimal? Subtotal { get; set; }

    [ForeignKey("PedidoId")]
    [InverseProperty("PedidoDetalles")]
    public virtual Pedido Pedido { get; set; } = null!;

    [ForeignKey("ProductoId")]
    [InverseProperty("PedidoDetalles")]
    public virtual Producto Producto { get; set; } = null!;
}
