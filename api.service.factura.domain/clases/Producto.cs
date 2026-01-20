using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("productos", Schema = "poo")]
public partial class Producto : BaseEntity
{
    [Key]
    [Column("producto_id")]
    public int ProductoId { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("precio")]
    public decimal Precio { get; set; }

    [Column("categoria_id")]
    public int CategoriaId { get; set; }

    [ForeignKey("CategoriaId")]
    public virtual Categoria Categoria { get; set; } = null!;

    [InverseProperty("Producto")]
    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; } = new List<PedidoDetalle>();
}
