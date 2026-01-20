using Microsoft.EntityFrameworkCore;
using api.service.factura.domain.clases;

namespace api.service.factura.infrastructure.context;

public partial class FacturaDbContext(DbContextOptions<FacturaDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<PedidoDetalle> PedidoDetalles { get; set; }

    public DbSet<Producto> Productos { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Pago> Pagos { get; set; }

    private static readonly string[] _aalLevel = ["aal1", "aal2", "aal3"];
    private static readonly string[] _codeChallengeMethod = ["s256", "plain"];
    private static readonly string[] _factorStatus = ["unverified", "verified"];
    private static readonly string[] _factorType = ["totp", "webauthn", "phone"];
    private static readonly string[] _oauthAuthorizationStatus = ["pending", "approved", "denied", "expired"];
    private static readonly string[] _oauthClientType = ["public", "confidential"];
    private static readonly string[] _oauthRegistrationType = ["dynamic", "manual"];
    private static readonly string[] _oauthResponseType = ["code"];
    private static readonly string[] _oneTimeTokenType = ["confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token"];
    private static readonly string[] _action = ["INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR"];
    private static readonly string[] _equalityOp = ["eq", "neq", "lt", "lte", "gt", "gte", "in"];
    private static readonly string[] _buckettype = ["STANDARD", "ANALYTICS", "VECTOR"];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", _aalLevel)
            .HasPostgresEnum("auth", "code_challenge_method", _codeChallengeMethod)
            .HasPostgresEnum("auth", "factor_status", _factorStatus)
            .HasPostgresEnum("auth", "factor_type", _factorType)
            .HasPostgresEnum("auth", "oauth_authorization_status", _oauthAuthorizationStatus)
            .HasPostgresEnum("auth", "oauth_client_type", _oauthClientType)
            .HasPostgresEnum("auth", "oauth_registration_type", _oauthRegistrationType)
            .HasPostgresEnum("auth", "oauth_response_type", _oauthResponseType)
            .HasPostgresEnum("auth", "one_time_token_type", _oneTimeTokenType)
            .HasPostgresEnum("realtime", "action", _action)
            .HasPostgresEnum("realtime", "equality_op", _equalityOp)
            .HasPostgresEnum("storage", "buckettype", _buckettype)
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("clientes_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.PedidoId).HasName("pedidos_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Fecha).HasDefaultValueSql("now()");
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
            entity.Property(e => e.Total)
                  .HasDefaultValueSql("0")
                  .HasPrecision(12, 2);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedido_cliente");

            entity.HasOne(d => d.Pago)
                .WithOne(p => p.Pedido)
                .HasForeignKey<Pago>(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_pago_pedido");
        });

        modelBuilder.Entity<PedidoDetalle>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("pedido_detalle_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
            entity.Property(e => e.Subtotal)
                  .HasComputedColumnSql("((cantidad)::numeric * precio_unitario)", true)
                  .HasPrecision(12, 2);

            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2);

            entity.HasOne(d => d.Pedido).WithMany(p => p.PedidoDetalles).HasConstraintName("fk_detalle_pedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.PedidoDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("productos_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
            entity.Property(e => e.Precio)
                  .HasPrecision(10, 2);

            entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_producto_categoria");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("categorias_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("pagos_pkey");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaInsert).HasDefaultValueSql("now()");
            entity.Property(e => e.Monto).HasPrecision(12, 2);

            entity.HasIndex(e => e.PedidoId).IsUnique();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
