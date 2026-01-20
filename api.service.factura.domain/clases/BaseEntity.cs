using System.ComponentModel.DataAnnotations.Schema;

namespace api.service.factura.domain.clases;

public abstract class BaseEntity
{
    [Column("estado")]
    public bool? Estado { get; set; }

    [Column("fecha_insert", TypeName = "timestamp without time zone")]
    public DateTime? FechaInsert { get; set; }

    [Column("fecha_update", TypeName = "timestamp without time zone")]
    public DateTime? FechaUpdate { get; set; }
}
