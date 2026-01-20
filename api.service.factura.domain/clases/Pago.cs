using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("pagos", Schema = "poo")]
public partial class Pago : BaseEntity
{
    [Key]
    [Column("pago_id")]
    public int PagoId { get; set; }

    [Column("pedido_id")]
    public int PedidoId { get; set; }

    [Column("metodo")]
    [StringLength(30)]
    public string Metodo { get; set; } = null!;

    [Column("monto")]
    public decimal Monto { get; set; }

    [ForeignKey("PedidoId")]
    [InverseProperty("Pago")]
    public virtual Pedido Pedido { get; set; } = null!;
}
