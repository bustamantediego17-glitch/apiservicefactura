using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("pedidos", Schema = "poo")]
public partial class Pedido : BaseEntity
{
    [Key]
    [Column("pedido_id")]
    public int PedidoId { get; set; }

    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("fecha", TypeName = "timestamp with time zone")]
    public DateTime? Fecha { get; set; }

    [Column("total")]
    public decimal? Total { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Pedidos")]
    public virtual Cliente Cliente { get; set; } = null!;

    [InverseProperty("Pedido")]
    public virtual Pago? Pago { get; set; }

    [InverseProperty("Pedido")]
    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
