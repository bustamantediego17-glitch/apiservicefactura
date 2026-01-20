using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("categorias", Schema = "poo")]
public partial class Categoria : BaseEntity
{
    [Key]
    [Column("categoria_id")]
    public int CategoriaId { get; set; }

    [Column("nombre")]
    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
