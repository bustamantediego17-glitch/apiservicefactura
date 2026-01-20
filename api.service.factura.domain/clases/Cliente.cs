using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

[Table("clientes", Schema = "poo")]
public partial class Cliente : BaseEntity
{
    [Key]
    [Column("cliente_id")]
    public int ClienteId { get; set; }

    [Column("nombre")]
    [StringLength(150)]
    public string Nombre { get; set; } = null!;

    [Column("direccion")]
    [StringLength(200)]
    public string? Direccion { get; set; }

    [Column("telefono")]
    [StringLength(20)]
    public string? Telefono { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
